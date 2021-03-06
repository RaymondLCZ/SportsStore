﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal Total { get {return (Product.Price * Quantity); } }

        public CartLine (Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}
