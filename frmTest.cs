using System.Collections.Concurrent;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StockLoadTest
{
    public partial class frmTest : Form
    {
        List<string> _filenames = new List<string>(); // array of file names in import folder
        int _fileIndex = 0; // current file name index

        // Set a few vars for working with minsElapsed
        DateTime marketOpenTime = DateTime.Today.Add(new TimeSpan(2, 0, 0)); // 2:00 AM MT
        DateTime marketCloseTime = DateTime.Today.Add(new TimeSpan(18, 0, 0)); // 6:00 PM MT
        DateTime lastResetTime = DateTime.Today.Add(new TimeSpan(18, 0, 0)); // Initial reset at 6:00 PM MT
        int minElapsed = 0; // Initialize minutes elapsed variable

        // list to hold all of the desired ticker data
        List<TickerInfo> tickerInfoList = new List<TickerInfo>();
        List<TickerInfo> topTenStocks = new List<TickerInfo>();
        List<TickerInfo> bottomTenStocks = new List<TickerInfo>();
        List<TickerInfo> highestRelativeVolume = new List<TickerInfo>();

        public frmTest()
        {
            InitializeComponent();
        }

        private void btnTestLoad_Click(object sender, EventArgs e)
        {
            // Step 1 - Load all the files from your directory into an array
            // call async function inside of event to ensure nothing weird happens
            handleSnapshots();
        }

        private async void handleSnapshots() // function that asynchronously handles the stock market snapshots
        {
            try
            {
                await Task.Run(() => // run asynchronously so there's no blocking on UI thread
                {
                    LoadFiles();
                    if (_filenames.Count == 0)
                    {
                        MessageBox.Show("No files found. Check your folder.");
                        return;
                    }

                    for (int i = 0; i < _filenames.Count; i++) // load data from each snapshot until all snapshots have been read
                    {
                        string filename = _filenames[_fileIndex];
                        GetSingleFileSnapshot(filename);
                        _fileIndex++;
                        if (_fileIndex == _filenames.Count)
                        {
                            Debug.WriteLine("Simulation Complete");
                            return;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void LoadFiles() // load the files from your directory if they exist
        {
            string startDir = txtPath.Text;
            if (!Directory.Exists(startDir))
            {
                MessageBox.Show("Directory does not exist.");
                return;
            }
            DirectoryInfo di = new DirectoryInfo(startDir);
            // assume any file in this folder is a json quote
            FileInfo[] files = di.GetFiles("*.json");
            // sort oldest to youngest
            Array.Sort(files, (x, y) => StringComparer.OrdinalIgnoreCase.Compare(x.CreationTime, y.CreationTime));
            foreach (FileInfo file in files)
                _filenames.Add(file.FullName);
            _fileIndex = 0;
        }

        private void GetSingleFileSnapshot(string filename) // aggregates through a single snapshot and displays the stock data to UI
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            MarketSnapshot? mss = LoadSnapshot(filename);

            //Debug.WriteLine("Total time after load: {0}ms", stopwatch.ElapsedMilliseconds);
            if (mss != null && mss.tickers != null)
            {
                // aggregate here
                // Calculate the minutes elapsed since market open
                DateTime currentSnapshotTime = GetSnapshotTime(filename);
                minElapsed = CalculateMinutesElapsed(currentSnapshotTime);

                // Create a list of TickerInfo objects based on ticker data
                tickerInfoList = FilterAndMapTickers(mss.tickers, minElapsed, filename);
            }
            // Display the current snapshot data to the UI
            // Create lists of stocks with interesting data by sorting based on certain values
            topTenStocks = tickerInfoList.OrderByDescending(t => t.percentGap).Take(10).ToList();
            bottomTenStocks = tickerInfoList.OrderBy(t => t.percentGap).Take(10).ToList();
            highestRelativeVolume = tickerInfoList.OrderByDescending(t => t.relativeVolume).Take(10).ToList();
            // Ensure UI updates are done on the UI thread
            BindDataGridView(topTenDataGridView, topTenStocks);
            BindDataGridView(bottomTenDataGridView, bottomTenStocks);
            BindDataGridView(highestRelativeVolumeDataGridView, highestRelativeVolume);

            // Update UI time
            Debug.WriteLine("Total time elapsed: {0}ms", stopwatch.ElapsedMilliseconds);
        }

        private List<TickerInfo> FilterAndMapTickers(List<Ticker> tickers, int minElapsed, string filename) // Filters and maps tickers in a snapshot
        {
            List<TickerInfo> filteredTickers = new List<TickerInfo>();

            foreach (var ticker in tickers)
            {
                if (ticker.lastQuote?.P >= 1 && ticker.min?.av >= 10000) // Only add tickers over $1 and under 10000 volume
                {
                    decimal averageVolume = CalculateAvgVol(ticker, minElapsed);

                    TickerInfo tickerInfo = new TickerInfo
                    {
                        tickerSymbol = ticker.ticker,
                        lastTradePrice = ticker.lastQuote?.P ?? 0,
                        percentGap = ticker.todaysChangePerc,
                        averageVolume = averageVolume,
                        totalMinVolume = ticker.min?.v ?? 0,
                        aggregateVolume = ticker.min?.av ?? 0,
                        relativeVolume = CalculateRelativeVol(ticker, minElapsed, averageVolume),
                        fileName = filename
                    };

                    filteredTickers.Add(tickerInfo);
                }
            }

            return filteredTickers;
        }

        private MarketSnapshot? LoadSnapshot(string fullPath) // Load a single snapshot from a file by deserializing the file and displaying the time
        {
            string? dirName = Path.GetDirectoryName(fullPath);
            string dateName = new DirectoryInfo(dirName).Name;
            // you can pull the date/time stamp from the name
            int iYear = Convert.ToInt32(dateName.Substring(0, 4));
            int iMonth = Convert.ToInt32(dateName.Substring(5, 2));
            int iDay = Convert.ToInt32(dateName.Substring(8, 2));
            DateTime startDate = new DateTime(iYear, iMonth, iDay);

            // get date/time for display - note these files are currently mountime
            // TODO - convert to UTC
            DateTime testTime = startDate;
            string filename = Path.GetFileNameWithoutExtension(fullPath);
            testTime = testTime.AddHours(Convert.ToInt32(filename.Substring(0, 2)));
            testTime = testTime.AddMinutes(Convert.ToInt32(filename.Substring(3, 2)));
            testTime = testTime.AddSeconds(Convert.ToInt32(filename.Substring(6, 2)));

            // convert MT to UTC time but add 1 extra hour due to incorrect conversions
            DateTime utcTime = testTime.ToUniversalTime().AddHours(1);

            lblStatus.Text = "Loading: " + testTime.ToLongTimeString() + " Mountain Time (" + utcTime.ToLongTimeString() + " UTC)";
            // Application.DoEvents(); // this keeps UI from locking up, but will slow things down once you start doing a lot
            // deserialize file
            string content = File.ReadAllText(fullPath);
            MarketSnapshot? mss;
            try
            {
                mss = JsonSerializer.Deserialize<MarketSnapshot>(content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                mss = null;
            }
            return mss;
        }

        private DateTime GetSnapshotTime(string filename) // Extract time information from the filename and convert it to a DateTime object
        {
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            int hours = Convert.ToInt32(filenameWithoutExtension.Substring(0, 2));
            int minutes = Convert.ToInt32(filenameWithoutExtension.Substring(3, 2));
            int seconds = Convert.ToInt32(filenameWithoutExtension.Substring(6, 2));

            DateTime snapshotTime = DateTime.Today.Add(new TimeSpan(hours, minutes, seconds));

            return snapshotTime;
        }

        private int CalculateMinutesElapsed(DateTime currentSnapshotTime) // Check if the current time is after the last reset time and before the market close time
        {
            if (currentSnapshotTime >= lastResetTime && currentSnapshotTime < marketCloseTime)
            {
                // Calculate the minutes elapsed
                return (int)(currentSnapshotTime - marketOpenTime).TotalMinutes;
            }
            else
            {
                // Reset the minutes elapsed to 0 if it's after the market close time
                lastResetTime = marketCloseTime;
                return 0;
            }
        }

        private decimal CalculateAvgVol(Ticker t, int minsElapsed) // Calculate average volume for a given stock
        {
            if (t.min != null && t.min.v > 0)
            {
                // average volume = (aggregate volume / num mins since open - 1)
                if (minsElapsed <= 2)
                {
                    return (t.min.av / 1);
                }
                else
                {
                    return (t.min.av / minsElapsed + 1);
                }
            }

            return 0;
        }

        private decimal CalculateRelativeVol(Ticker t, int minsElapsed, decimal averageVolume)
        {
            if (t.min != null && (t.min.av / t.min.v) > 0)
            {
                return t.min.v / (averageVolume);
            }

            return 0;
        }

        private void BindDataGridView(DataGridView dataGridView, List<TickerInfo> data) // add stock data to the DataGridView
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action(() => BindDataGridView(dataGridView, data)));
            }
            else
            {
                // Clear existing rows and reset data source
                dataGridView.Rows.Clear();
                dataGridView.DataSource = null;

                foreach (var tickerInfo in data)
                {
                    // Add a new row to the DataGridView
                    int rowIndex = dataGridView.Rows.Add(
                        tickerInfo.tickerSymbol,
                        tickerInfo.lastTradePrice,
                        tickerInfo.percentGap,
                        tickerInfo.averageVolume,
                        tickerInfo.totalMinVolume,
                        tickerInfo.relativeVolume
                    );
                }
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            dlgPath.InitialDirectory = Application.StartupPath;
            if (dlgPath.ShowDialog() != DialogResult.Cancel)
                txtPath.Text = dlgPath.SelectedPath;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTest_Load(object sender, EventArgs e)
        {

        }
    }
}