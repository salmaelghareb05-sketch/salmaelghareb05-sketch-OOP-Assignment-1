using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    internal class OrderSystem
    {
        public List<Customer> Customers { get; set; }
        public List<product> Products { get; set; }
        public List<Order> Orders { get; set; }

        public OrderSystem()
        {
            Customers = new List<Customer>();
            Products = new List<product>();
            Orders = new List<Order>();
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
        public void AddProduct(product product)
        {
            Products.Add(product);
        }
        public Customer FindCustomerById(int id)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }

        public product FindProductById(int id)
        {
            foreach (product product in Products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }
        public Order FindOrderById(int id)
        {
            foreach (Order order in Orders)
            {
                if (order.Id == id)
                    return order;
            }

            return null;
        }

        public void CreateOrder(int orderId, int customerId, string date)
        {
            if (FindOrderById(orderId) != null)
            {
                Console.WriteLine("ERROR: order id already exists.");
                return;
            }

            Customer customer = FindCustomerById(customerId);

            if (customer == null)
            {
                Console.WriteLine("ERROR: customer not found.");
                return;
            }

            Order order = new Order
            {
                Id = orderId,
                Customer = customer,
                Date = date
            };

            Orders.Add(order);
        }

            public void AddLineToOrder(int orderId, int productId, int quantity)
        {
            Order order = FindOrderById(orderId);

            if (order == null)
            {
                Console.WriteLine("ERROR: order not found.");
                return;
            }

            if (order.IsPaid)
            {
                Console.WriteLine("ERROR: cannot change a paid order.");
                return;
            }

            product product = FindProductById(productId);

            if (product == null)
            {
                Console.WriteLine("ERROR: product not found.");
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("ERROR: quantity must be positive.");
                return;
            }

            if (product.Stock < quantity)
            {
                Console.WriteLine("ERROR: not enough stock.");
                return;
            }

            product.Stock -= quantity;

            OrderLine line = new OrderLine
            {
                Product = product,
                Quantity = quantity
            };

            order.AddLine(line);
        }
        public void MarkOrderPaid(int orderId)
        {
            Order order = FindOrderById(orderId);

            if (order == null)
            {
                Console.WriteLine("ERROR: order not found.");
                return;
            }

            order.MarkAsPaid();
        }
        public double TotalSalesPaidOnly()
        {
            double total = 0;

            foreach (Order order in Orders)
            {
                if (order.IsPaid)
                {
                    total += order.CalculateTotal();
                }
            }

            return total;
        }



    }
}
