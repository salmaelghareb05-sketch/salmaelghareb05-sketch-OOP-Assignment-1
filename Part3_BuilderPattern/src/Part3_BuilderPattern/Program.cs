namespace Part3_BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Address billingAddress = new AddressBuilder()
               .SetStreet("Main Street")
               .SetCity("Cairo")
               .SetState("Cairo")
               .SetZipCode("11511")
               .SetCountry("Egypt")
               .Build();

            Address shippingAddress = new AddressBuilder()
                .SetStreet("Nile Street")
                .SetCity("Giza")
                .SetState("Giza")
                .SetZipCode("12511")
                .SetCountry("Egypt")
                .Build();

            Order order = new OrderBuilder()
                .SetOrderDate(DateTime.Now)
                .SetPaymentMethod("Credit Card")
                .SetCurrency("EGP")
                .SetSubTotal(1000m)
                .SetDiscountAmount(100m)
                .SetTaxAmount(90m)
                .Build();

            Invoice invoice = new InvoiceBuilder()
                .SetInvoiceId(1001)
                .SetCustomerName("Mona Ahmed")
                .SetCustomerEmail("mona@example.com")
                .SetCustomerPhone("01012345678")
                .SetBillingAddress(billingAddress)
                .SetShippingAddress(shippingAddress)
                .SetOrder(order)
                .Build();

            Console.WriteLine("Invoice created successfully.");
            Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
            Console.WriteLine($"Customer: {invoice.CustomerName}");
            Console.WriteLine($"Email: {invoice.CustomerEmail}");

            Console.WriteLine();
            Console.WriteLine("Billing Address:");
            Console.WriteLine(
                $"{invoice.BillingAddress.Street}, " +
                $"{invoice.BillingAddress.City}, " +
                $"{invoice.BillingAddress.Country}");

            Console.WriteLine();
            Console.WriteLine("Shipping Address:");
            Console.WriteLine(
                $"{invoice.ShippingAddress.Street}, " +
                $"{invoice.ShippingAddress.City}, " +
                $"{invoice.ShippingAddress.Country}");

            Console.WriteLine();
            Console.WriteLine("Order Information:");
            Console.WriteLine($"Payment Method: {invoice.Order.PaymentMethod}");
            Console.WriteLine($"Currency: {invoice.Order.Currency}");
            Console.WriteLine($"Subtotal: {invoice.Order.SubTotal}");
            Console.WriteLine($"Discount: {invoice.Order.DiscountAmount}");
            Console.WriteLine($"Tax: {invoice.Order.TaxAmount}");
            Console.WriteLine($"Total: {invoice.Order.TotalAmount}");

        }
    }
}
