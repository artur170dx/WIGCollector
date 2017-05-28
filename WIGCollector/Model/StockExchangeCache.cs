using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIGCollector.Model
{
    sealed class StockExchangeCache
    {
        private static readonly StockExchangeCache instance = new StockExchangeCache();
        private static Dictionary<string, double> cachedRates = new Dictionary<string, double>();
        private StockExchangeRate newRateToCache = new StockExchangeRate();
        private StockExchangeCache(){}

        public static StockExchangeCache Instance
        {
            get
            {
                return instance;
            }
        }

        public bool HasChangedSinceLastTime(StockExchangeRate newRate)
        {
            newRateToCache = newRate;
            if (NotInCache())
            {
                AddToCache();
                return true;
            }
            else if (ValueChangedSinceLastTime())
            {
                UpdateCache();
                return true;
            }

            return false;   
        }

        private bool NotInCache()
        {
            return !cachedRates.ContainsKey(newRateToCache.Name);
        }

        private void AddToCache()
        {
            cachedRates.Add(newRateToCache.Name, newRateToCache.Value);
        }

        private bool ValueChangedSinceLastTime()
        {
            return cachedRates[newRateToCache.Name] != newRateToCache.Value;
        }

        private void UpdateCache()
        {
            cachedRates[newRateToCache.Name] = newRateToCache.Value;
        }
    }        
}
