using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLoadTest
{
    internal class MarketSnapshot
    {
        public delegate void delDataSaved(bool result);
        public event delDataSaved? OnDataSaved;

        public List<Ticker>? tickers { get; set; }  // original ticker information here
        public List<SS_MarketQuote> allQuotes = new List<SS_MarketQuote>(); // updated quote summaries here
    }
}
