using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIGCollector
{
    interface IStockExchangeDataBase
    {
        void AddRate(StockExchangeRate rate);
    }
}
