using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    internal class OrderLine
    {
        public product Product { get; set; }
        public int Quantity { get; set; }

        public double CalculateLineTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
