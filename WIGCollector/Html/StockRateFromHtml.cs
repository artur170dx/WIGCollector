using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIGCollector.Html
{
    public class StockRateFromHtml : IStockExchangeRateDownloader
    {
        const string webPage = "https://stooq.pl/";

        public List<StockExchangeRate> GetActualRatings(List<string> wigNames)
        {
            string Url = webPage;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);
            HtmlNode node = doc.GetElementbyId("aq_wig20_c2");

            return new List<StockExchangeRate>();
        }
    }
}
