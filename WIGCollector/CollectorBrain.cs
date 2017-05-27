using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WIGCollector.Database;
using WIGCollector.Html;

namespace WIGCollector
{
    public class CollectorBrain
    {
        private TimeSpan defaultInterval = new TimeSpan(0, 1, 0);
        private Timer timer;
        private TimeSpan interval;

        public CollectorBrain()
        {
            interval = defaultInterval;
        }

        public void Run()
        {
            TimerCallback tmCallback = callback;
            timer = new Timer(tmCallback, "", interval, interval);
        }

        public void ChangeInterval(TimeSpan requestedInterval)
        {
            bool timerSuccessfullyChanged = timer.Change(requestedInterval, requestedInterval);
            if (timerSuccessfullyChanged)
            {
                interval = requestedInterval;
            }
                
        }

        private void callback(object objectInfo)
        {

        }

        private void Do()
        {
            IStockExchangeRateDownloader downloader = new StockRateFromHtml();
            List<StockExchangeRate> actualRates = downloader.GetActualRatings();

            IStockExchangeDatabase db = new FileDatabase();
            foreach (StockExchangeRate actualRate in actualRates)
            {
                if (StockExchangeCache.HasChangedSinceLastTime(actualRate))
                {
                    db.AddRate(actualRate);
                }
            }
        }
    }
}
