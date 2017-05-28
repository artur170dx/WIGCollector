using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIGCollector.Model;
using WIGCollector.Database;
using WIGCollector.Html;

namespace WIGCollector
{
    class Factory
    {
        public static IStockExchangeDatabase GetDataBase()
        {
            return new FileDatabase();
        }

        public static IStockExchangeRateDownloader GetDownloader()
        {
            return new StockRateFromHtml();
        }
    }
}
