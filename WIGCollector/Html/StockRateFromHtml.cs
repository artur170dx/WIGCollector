﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIGCollector.Html
{
    public class StockRateFromHtml : IStockExchangeRateDownloader
    {
        private class StockHtmlNode
        {
            public string Name { get; private set; }
            public string HtmlNode { get; private set; }

            public StockHtmlNode(string name, string htmlNode)
            {
                Name = name;
                HtmlNode = htmlNode;
            }
        }

        private const string webPage = "https://stooq.pl/";

        private List<StockHtmlNode> wigs;

        public StockRateFromHtml()
        {
            wigs = new List<StockHtmlNode>();
            wigs.Add(new StockHtmlNode("WIG", "aq_wig_c2"));
            wigs.Add(new StockHtmlNode("WIG20", "aq_wig20_c2"));
            wigs.Add(new StockHtmlNode("WIG20 Fut", "aq_fw20_c0"));
            wigs.Add(new StockHtmlNode("mWIG40", "aq_mwig40_c2"));
            wigs.Add(new StockHtmlNode("sWIG80", "aq_swig80_c2"));
        }

        public List<StockExchangeRate> GetActualRatings()
        {
            string Url = webPage;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);
            List<StockExchangeRate> actualRates = new List<StockExchangeRate>();
            foreach (StockHtmlNode wig in wigs)
	        {
		        HtmlNode node = doc.GetElementbyId(wig.HtmlNode);
                StockExchangeRate actualRate = new StockExchangeRate();
                actualRate.Name = wig.Name;
                actualRate.Value = Convert.ToDouble(node.InnerText);
                actualRate.Timestamp = DateTime.Now;
                actualRates.Add(actualRate);
	        }
            return actualRates;
        } 
    }


}
