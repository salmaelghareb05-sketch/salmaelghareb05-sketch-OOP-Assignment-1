using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    internal class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public string Date { get; set; }
        public bool IsPaid { get; private set; }

        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public void AddLine(OrderLine line)
        {
            OrderLines.Add(line);
        }

        public double CalculateTotal()
        {
            double total = 0;

            foreach (OrderLine line in OrderLines)
            {
                total += line.CalculateLineTotal();
            }

            if (Customer.IsVip)
            {
                total *= 0.90;
            }

            return total;
        }

        public void MarkAsPaid()
        {
            if (OrderLines.Count == 0)
            {
                Console.WriteLine("ERROR: cannot pay an empty order.");
                return;
            }

            IsPaid = true;
        }

    }
}
