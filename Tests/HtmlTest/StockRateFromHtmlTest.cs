using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIGCollector.Html;
using System.Collections.Generic;
using WIGCollector;

namespace Tests
{
    [TestClass]
    public class StockRateFromHtmlTest
    {
        [TestMethod]
        public void ReturnSomeValuesTest()
        {
            StockRateFromHtml stock = new StockRateFromHtml();

            List<StockExchangeRate> rates = stock.GetActualRatings();

            Assert.IsTrue(rates.Count != 0);

            foreach (StockExchangeRate item in rates)
            {
                Assert.IsNotNull(item.Value);
            }
        }

        [TestMethod]
        public void ReturnValuesNotOlderThanOneMinuteTest()
        {
            StockRateFromHtml stock = new StockRateFromHtml();
            List<StockExchangeRate> rates = stock.GetActualRatings();

            Assert.IsTrue(rates.Count != 0);
            foreach (StockExchangeRate item in rates)
            {
                Assert.IsTrue(item.Timestamp > DateTime.Now.AddMinutes(-1));
            }
        }

        [TestMethod]
        public void ReturnValuesNotFromFutureTest()
        {
            StockRateFromHtml stock = new StockRateFromHtml();
            List<StockExchangeRate> rates = stock.GetActualRatings();

            Assert.IsTrue(rates.Count != 0);
            foreach (StockExchangeRate item in rates)
            {
                Assert.IsTrue(item.Timestamp < DateTime.Now.AddMinutes(1));
            }
        }

    }
}
