using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockLoadTest
{
    internal class SS_PrevDayQuote
    {
        public decimal c { get; set; } // close
        public decimal h { get; set; } // high
        public decimal l { get; set; } // low
        public decimal o { get; set; } // open
        public decimal v { get; set; } // volume
        public decimal vw { get; set; }
    }
}
