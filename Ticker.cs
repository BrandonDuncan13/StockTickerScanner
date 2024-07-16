using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLoadTest
{
    internal class Ticker
    {
        internal SS_DayQuote? day { get; set; }
        public SS_LastQuote? lastQuote { get; set; }
        public SS_LastTrade? lastTrade { get; set; }
        public SS_MinQuote? min { get; set; }
        public SS_PrevDayQuote? prevDay { get; set; }
        public string? ticker { get; set; }
        public decimal todaysChange { get; set; }
        public decimal todaysChangePerc { get; set; }
        public long updated { get; set; }
    }
}
