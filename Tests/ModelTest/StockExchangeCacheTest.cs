using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIGCollector.Model;

namespace Tests.ModelTest
{
    [TestClass]
    public class StockExchangeCacheTest
    {
        [TestMethod]
        public void FirstCachedValueMeansThatItChangedSinceLastTime()
        {
            StockExchangeRate firstCachedRate = new StockExchangeRate();
            firstCachedRate.Name = "WIG";
            firstCachedRate.Timestamp = DateTime.Now;
            firstCachedRate.Value = 1;
            StockExchangeCache cache = StockExchangeCache.Instance;
            bool hasChanged = cache.HasChangedSinceLastTime(firstCachedRate);
            Assert.IsTrue(hasChanged);
        }

        [TestMethod]
        public void RateHasNotBeenChangedSinceLastTime()
        {
            const double notChaningValue = 5;
            StockExchangeRate rate = new StockExchangeRate();
            rate.Name = "WIG";
            rate.Timestamp = DateTime.Now;
            rate.Value = notChaningValue;
            StockExchangeCache cache = StockExchangeCache.Instance;
            cache.HasChangedSinceLastTime(rate);
            StockExchangeRate newRateWithTheSameValue = new StockExchangeRate();
            newRateWithTheSameValue.Name = "WIG";
            newRateWithTheSameValue.Timestamp = DateTime.Now;
            newRateWithTheSameValue.Value = notChaningValue;
            bool hasChanged = cache.HasChangedSinceLastTime(newRateWithTheSameValue);
            Assert.IsFalse(hasChanged);
        }

        [TestMethod]
        public void RateHasBeenChangedSinceLastTime()
        {
            StockExchangeRate rate = new StockExchangeRate();
            rate.Name = "WIG";
            rate.Timestamp = DateTime.Now;
            rate.Value = 2;
            StockExchangeCache cache = StockExchangeCache.Instance;
            cache.HasChangedSinceLastTime(rate);
            StockExchangeRate newRate = new StockExchangeRate();
            newRate.Name = "WIG";
            newRate.Timestamp = DateTime.Now;
            newRate.Value = 3;
            bool hasChanged = cache.HasChangedSinceLastTime(newRate);
            Assert.IsTrue(hasChanged);
        }
    }
}
