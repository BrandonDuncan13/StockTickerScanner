using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLoadTest
{
    internal class TickerInfo
    {
        public string fileName { get; set; }
        public string? tickerSymbol { get; set; }
        public decimal openPrice { get; set; }
        public decimal lastTradePrice { get; set; }
        public decimal percentGap { get; set; } // calculated
        public decimal averageVolume { get; set; } // calculated
        public decimal totalMinVolume { get; set; }
        public decimal relativeVolume { get; set; } // calculated
        public decimal aggregateVolume { get; set; }

        public TickerInfo() // constructor to set
        {
            averageVolume = 0;
            openPrice = 0;
        }
    }
}
