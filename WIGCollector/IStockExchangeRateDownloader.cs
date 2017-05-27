﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIGCollector
{
    public interface IStockExchangeRateDownloader
    {
        List<StockExchangeRate> GetActualRatings(List<string> wigNames);
    }
}