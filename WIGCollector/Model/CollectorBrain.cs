using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WIGCollector.Model
{
    public class CollectorBrain
    {
        private IStockExchangeRateDownloader Downloader { get; set; }
        private IStockExchangeDatabase Database { get; set; }
        private StockExchangeCache Cache { get; set; }

        public CollectorBrain(IStockExchangeRateDownloader downloader, IStockExchangeDatabase db)
        {
            if (downloader == null)
                throw new ArgumentNullException("Argument of type IStockExchangeRateDownloader can't be null");
            if (db == null)
                throw new ArgumentNullException("Argument of type IStockExchangeDatabase can't be null");
            
            Downloader = downloader;
            Database = db;
            Cache = StockExchangeCache.Instance;
        }

        public void Do()
        {
            List<StockExchangeRate> actualRates = Downloader.GetActualRatings();
            foreach (StockExchangeRate actualRate in actualRates)
            {
                if (Cache.HasChangedSinceLastTime(actualRate))
                {
                    Database.AddRate(actualRate);
                }
            }
        }
    }
}
