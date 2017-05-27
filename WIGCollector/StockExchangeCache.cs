using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIGCollector
{
    static class StockExchangeCache
    {
        private static List<StockExchangeRate> cachedRates = new List<StockExchangeRate>();

        public static bool HasChangedSinceLastTime(StockExchangeRate newRate)
        {
            return true;
        }

    }
}
