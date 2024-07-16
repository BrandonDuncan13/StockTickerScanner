using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLoadTest
{
    internal class SS_MarketQuote : IComparable
    {
        public int RecordId { get; set; }
        public DateTime QuoteDateTime { get; set; }
        public DateTime QuoteUTCDateTime { get; set; }
        public decimal Velocity { get; set; }
        public char PeakValleyState { get; set; } = 'I';
        // capture former states if quote gets replaced
        public char ResetPeakState { get; set; }
        public int ResetPeakIndex { get; set; } = -1;
        public char ResetValleyState { get; set; }
        public int ResetValleyIndex { get; set; } = -1;

        private long quoteTicks;

        public long QuoteTicks
        {
            get { return quoteTicks; }
            set
            {
                // we need to test the tick value because we either get milliseconds ticks or nanosecond ticks
                if (value > 1000000000000000000) // 1x10 to the 18th
                {
                    TimeSpan time = TimeSpan.FromTicks(value / 100);    // nanoseconds past 1/1/1970
                    DateTime startDate = new DateTime(1970, 1, 1) + time;
                    QuoteUTCDateTime = startDate;
                    QuoteDateTime = startDate.ToLocalTime();
                }
                else
                {
                    quoteTicks = value;     // milliseconds past 1/1/1970
                    TimeSpan time = TimeSpan.FromMilliseconds(quoteTicks);
                    DateTime startDate = new DateTime(1970, 1, 1) + time;
                    QuoteUTCDateTime = startDate;
                    QuoteDateTime = startDate.ToLocalTime();
                }
            }

        }
        public SS_MarketQuote()
        {
        }

        public DateTime TicksToLocalDate(long ticks)
        {
            TimeSpan time;
            DateTime startDate = new DateTime(1970, 1, 1);

            if (ticks > 1000000000000000000) // 1x10 to the 18th
            {
                time = TimeSpan.FromTicks(ticks / 100);
                startDate += time;
                QuoteUTCDateTime = startDate;
            }
            else
            {
                time = TimeSpan.FromMilliseconds(ticks);
                startDate += time;
                QuoteUTCDateTime = startDate;
            }
            QuoteUTCDateTime = startDate;
            DateTime QuoteDate = startDate.ToLocalTime();
            return QuoteDate;
        }
        public long LocalDateToTicks(DateTime theDate)
        {
            DateTime univDate = theDate.ToUniversalTime();
            DateTime startDate = new DateTime(1970, 1, 1);
            TimeSpan ts = univDate - startDate;
            return (long)ts.TotalMilliseconds;
        }

        public decimal DayQuote_c { get; set; }
        public decimal DayQuote_h { get; set; }
        public decimal DayQuote_l { get; set; }
        public decimal DayQuote_o { get; set; }
        public decimal DayQuote_v { get; set; }
        public decimal DayQuote_vw { get; set; }

        public decimal LastQuote_P { get; set; }
        public int LastQuote_S { get; set; }
        public decimal LastQuote_lp { get; set; }
        public int LastQuote_ls { get; set; }
        public long LastQuote_t { get; set; }

        public List<int> LastTrade_c { get; set; }
        public string LastTrade_i { get; set; }
        public decimal LastTrade_p { get; set; }
        public int LastTrade_s { get; set; }
        public long LastTrade_t { get; set; }
        public int LastTrade_x { get; set; }

        public decimal MinQuote_av { get; set; }
        public decimal MinQuote_c { get; set; }
        public decimal MinQuote_h { get; set; }
        public decimal MinQuote_l { get; set; }
        public decimal MinQuote_o { get; set; }
        public decimal MinQuote_v { get; set; }
        public decimal MinQuote_vw { get; set; }

        public decimal PrevDayQuote_c { get; set; }
        public decimal PrevDayQuote_h { get; set; }
        public decimal PrevDayQuote_l { get; set; }
        public decimal PrevDayQuote_o { get; set; }
        public decimal PrevDayQuote_v { get; set; }
        public decimal PrevDayQuote_vw { get; set; }

        public string ticker { get; set; }
        public decimal todaysChange { get; set; }
        public decimal todaysChangePerc { get; set; }
        public long updated
        {
            get { return quoteTicks; }
            set
            {
                quoteTicks = value;     // nanoseconds past 1/1/1970
                DateTime epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime result = epochTime.AddTicks(quoteTicks / 100);
                QuoteDateTime = result.ToLocalTime();
                QuoteUTCDateTime = result;
            }
        }
        public override string ToString()
        {
            return ticker;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            SS_MarketQuote p = obj as SS_MarketQuote;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ticker == p.ticker) && (QuoteDateTime == p.QuoteDateTime);
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 486187739;
                hash = hash * 23 + ticker.GetHashCode();
                hash += hash * 23 + QuoteDateTime.GetHashCode();
                return hash;
            }
        }

        public int Compare(SS_MarketQuote x, SS_MarketQuote y)
        {
            if (x.ticker.CompareTo(y.ticker) != 0)
            {
                return x.ticker.CompareTo(y.ticker);
            }
            else if (x.QuoteDateTime.CompareTo(y.QuoteDateTime) != 0)
            {
                return x.QuoteDateTime.CompareTo(y.QuoteDateTime);
            }
            else
            {
                return 0;
            }
        }

        int IComparable.CompareTo(object obj)
        {
            SS_MarketQuote mq = (SS_MarketQuote)obj;
            if (this.ticker.CompareTo(mq.ticker) != 0)
            {
                return this.ticker.CompareTo(mq.ticker);
            }
            else if (this.QuoteDateTime.CompareTo(mq.QuoteDateTime) != 0)
            {
                return this.QuoteDateTime.CompareTo(mq.QuoteDateTime);
            }
            else
            {
                return 0;
            }
        }
    }
}
