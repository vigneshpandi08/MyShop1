﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop1.Core.ViewModel
{
    public class BasketItemViewModel
    {
        public string Id { get; set; }
        public int Qantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
