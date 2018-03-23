﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop1.Core.ViewModel
{
    public class BasketSummaryViewModel
    {
        public int BasketCount { get; set; }
        public decimal BasketTotal { get; set; }

        public BasketSummaryViewModel()
        {

        }

        public BasketSummaryViewModel(int basketCount, decimal basketTotal)
        {
            this.BasketCount = basketCount;
            this.BasketTotal = basketTotal;
        }

    }
}
