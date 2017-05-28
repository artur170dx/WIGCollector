using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIGCollector.Model
{
    public interface IStockExchangeDatabase
    {
        void AddRate(StockExchangeRate rate);
    }
}
