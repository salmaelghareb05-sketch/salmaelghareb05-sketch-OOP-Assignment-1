using System.Xml.Linq;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderSystem system = new OrderSystem();

            system.AddCustomer(new Customer
            {
                Id = 1, 
                Name = "Mona Ali",           
                Email = "mona@example.com",
                City = "Cairo",
                IsVip = true
            }
            );

            system.AddCustomer(new Customer
            {
                Id = 2,
                Name = "Omar Hassan",
                Email = "omar@example.com",
                City = "Alexandria",
                IsVip = false
            }
            );

            system.AddCustomer(new Customer
            {
                Id = 3,
                Name = "Sara Nabil",
                Email = "sara@example.com",
                City = "Giza",
                IsVip = false
            }
            );
            system.AddProduct(new product
            {
                Id = 101,
                Name = "USB Cable",
                Price = 50.0,
                Stock = 100
            });

            system.AddProduct(new product
            {
                Id = 102,
                Name = "Wireless Mouse",
                Price = 250.0,
                Stock = 40
            });

            system.AddProduct(new product
            {
                Id = 103,
                Name = "Mechanical Keyboard",
                Price = 1200.0,
                Stock = 15
            });

            system.AddProduct(new product
            {
                Id = 104,
                Name = "Laptop Stand",
                Price = 400.0,
                Stock = 25
            });




            // Create Order 1001
            system.CreateOrder(1001, 1, "2026-09-15");
            system.AddLineToOrder(1001, 101, 2);
            system.AddLineToOrder(1001, 102, 1);
            system.MarkOrderPaid(1001);

            // Create Order 1002
            system.CreateOrder(1002, 2, "2026-09-15");
            system.AddLineToOrder(1002, 103, 1);
            system.AddLineToOrder(1002, 104, 1);

            // Create Order 1003
            system.CreateOrder(1003, 3, "2026-09-16");
            system.AddLineToOrder(1003, 101, 5);
            system.MarkOrderPaid(1003);


            Console.WriteLine("=== CUSTOMERS ===");

            foreach (Customer customer in system.Customers)
            {
                Console.WriteLine(
                    $"#{customer.Id}  {customer.Name}  <{customer.Email}>  {customer.City}  vip={(customer.IsVip ? "yes" : "no")}"
                );
            }

            Console.WriteLine("\n=== PRODUCTS ===");

            foreach (product product in system.Products)
            {
                Console.WriteLine(
                    $"#{product.Id}  {product.Name}  price={product.Price:F2}  stock={product.Stock}"
                );
            }

            Console.WriteLine("\n=== ALL ORDERS ===");

            foreach (Order order in system.Orders)
            {
                Console.WriteLine($"\n=== ORDER #{order.Id} ===");
                Console.WriteLine($"Date: {order.Date}");
                Console.WriteLine($"Customer: {order.Customer.Name} (#{order.Customer.Id})");
                Console.WriteLine($"Paid: {(order.IsPaid ? "yes" : "no")}");

                Console.WriteLine("Lines:");

                foreach (OrderLine line in order.OrderLines)
                {
                    double lineTotal = line.CalculateLineTotal();

                    Console.WriteLine(
                        $"  - {line.Product.Name}  x{line.Quantity}  @{line.Product.Price:F2}  = {lineTotal:F2}"
                    );
                }

                Console.WriteLine($"TOTAL: {order.CalculateTotal():F2}");
            }
            Console.WriteLine(
                $"\nPaid sales total: {system.TotalSalesPaidOnly():F2}"
             );

            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("\n---------- MENU ----------");
                Console.WriteLine("1) Print customers");
                Console.WriteLine("2) Print products");
                Console.WriteLine("3) Print all orders");
                Console.WriteLine("4) Print one order by id");
                Console.WriteLine("5) Create order");
                Console.WriteLine("6) Add line to order");
                Console.WriteLine("7) Mark order paid");
                Console.WriteLine("8) Show paid sales total");
                Console.WriteLine("0) Exit");

                Console.Write("Choice: ");
                choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n=== CUSTOMERS ===");

                        foreach (Customer customer in system.Customers)
                        {
                            Console.WriteLine(
                                $"#{customer.Id}  {customer.Name}  <{customer.Email}>  {customer.City}  vip={(customer.IsVip ? "yes" : "no")}"
                            );
                        }

                        break;

                    case 2:
                        Console.WriteLine("\n=== PRODUCTS ===");

                        foreach (product product in system.Products)
                        {
                            Console.WriteLine(
                                $"#{product.Id}  {product.Name}  price={product.Price:F2}  stock={product.Stock}"
                            );
                        }

                        break;

                    case 3:
                        Console.WriteLine("\n=== ALL ORDERS ===");

                        foreach (Order order in system.Orders)
                        {
                            Console.WriteLine($"\n=== ORDER #{order.Id} ===");
                            Console.WriteLine($"Date: {order.Date}");
                            Console.WriteLine(
                                $"Customer: {order.Customer.Name} (#{order.Customer.Id})"
                            );
                            Console.WriteLine(
                                $"Paid: {(order.IsPaid ? "yes" : "no")}"
                            );

                            Console.WriteLine("Lines:");

                            foreach (OrderLine line in order.OrderLines)
                            {
                                double lineTotal = line.CalculateLineTotal();

                                Console.WriteLine(
                                    $"  - {line.Product.Name}  x{line.Quantity}  @{line.Product.Price:F2}  = {lineTotal:F2}"
                                );
                            }

                            Console.WriteLine(
                                $"TOTAL: {order.CalculateTotal():F2}"
                            );
                        }

                        break;

                    case 4:
                        Console.Write("Order id: ");
                        int orderId = int.Parse(Console.ReadLine()!);

                        Order orderToPrint = system.FindOrderById(orderId);

                        if (orderToPrint == null)
                        {
                            Console.WriteLine("ERROR: order not found.");
                            break;
                        }

                        Console.WriteLine($"\n=== ORDER #{orderToPrint.Id} ===");
                        Console.WriteLine($"Date: {orderToPrint.Date}");
                        Console.WriteLine(
                            $"Customer: {orderToPrint.Customer.Name} (#{orderToPrint.Customer.Id})"
                        );
                        Console.WriteLine(
                            $"Paid: {(orderToPrint.IsPaid ? "yes" : "no")}"
                        );

                        Console.WriteLine("Lines:");

                        foreach (OrderLine line in orderToPrint.OrderLines)
                        {
                            double lineTotal = line.CalculateLineTotal();

                            Console.WriteLine(
                                $"  - {line.Product.Name}  x{line.Quantity}  @{line.Product.Price:F2}  = {lineTotal:F2}"
                            );
                        }

                        Console.WriteLine(
                            $"TOTAL: {orderToPrint.CalculateTotal():F2}"
                        );

                        break;

                    case 5:
                        Console.Write("Order id: ");
                        int newOrderId = int.Parse(Console.ReadLine()!);

                        Console.Write("Customer id: ");
                        int customerId = int.Parse(Console.ReadLine()!);

                        Console.Write("Date (YYYY-MM-DD): ");
                        string date = Console.ReadLine()!;

                        system.CreateOrder(
                            newOrderId,
                            customerId,
                            date
                        );

                        break;

                    case 6:
                        Console.Write("Order id: ");
                        int lineOrderId = int.Parse(Console.ReadLine()!);

                        Console.Write("Product id: ");
                        int productId = int.Parse(Console.ReadLine()!);

                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine()!);

                        system.AddLineToOrder(
                            lineOrderId,
                            productId,
                            quantity
                        );

                        break;

                    case 7:
                        Console.Write("Order id: ");
                        int paidOrderId = int.Parse(Console.ReadLine()!);

                        system.MarkOrderPaid(paidOrderId);

                        break;

                    case 8:
                        Console.WriteLine(
                            $"Paid sales total: {system.TotalSalesPaidOnly():F2}"
                        );

                        break;

                    case 0:
                        Console.WriteLine("Bye.");
                        break;

                    default:
                        Console.WriteLine("Unknown choice.");
                        break;
                }
            }





        }
    }
}
