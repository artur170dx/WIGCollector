using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIGCollector.Html
{
    class StockHtmlNode
    {
        public string Name { get; private set; }
        public string HtmlNode { get; private set; }

        public StockHtmlNode(string name, string htmlNode)
        {
            Name = name;
            HtmlNode = htmlNode;
        }
    }
}
