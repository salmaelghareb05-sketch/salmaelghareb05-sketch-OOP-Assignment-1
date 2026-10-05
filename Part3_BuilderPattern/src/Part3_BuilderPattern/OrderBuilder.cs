using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern
{
    public class OrderBuilder
    {

        private DateTime? _orderDate;
        private string? _paymentMethod;
        private string? _currency;
        private decimal? _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;

        public OrderBuilder SetOrderDate(DateTime orderDate)
        {
            _orderDate = orderDate;
            return this;
        }

        public OrderBuilder SetPaymentMethod(string paymentMethod)
        {
            _paymentMethod = paymentMethod;
            return this;
        }

        public OrderBuilder SetCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public OrderBuilder SetSubTotal(decimal subTotal)
        {
            _subTotal = subTotal;
            return this;
        }

        public OrderBuilder SetDiscountAmount(decimal discountAmount)
        {
            _discountAmount = discountAmount;
            return this;
        }

        public OrderBuilder SetTaxAmount(decimal taxAmount)
        {
            _taxAmount = taxAmount;
            return this;
        }

        public Order Build()
        {
            if (!_orderDate.HasValue)
                throw new InvalidOperationException("Order date is required.");

            if (string.IsNullOrWhiteSpace(_paymentMethod))
                throw new InvalidOperationException("Payment method is required.");

            if (string.IsNullOrWhiteSpace(_currency))
                throw new InvalidOperationException("Currency is required.");

            if (!_subTotal.HasValue)
                throw new InvalidOperationException("Subtotal is required.");

            if (_subTotal.Value < 0)
                throw new ArgumentException("Subtotal cannot be negative.");

            if (_discountAmount < 0)
                throw new ArgumentException("Discount cannot be negative.");

            if (_taxAmount < 0)
                throw new ArgumentException("Tax cannot be negative.");

            return new Order(
                _orderDate.Value,
                _paymentMethod,
                _currency,
                _subTotal.Value,
                _discountAmount,
                _taxAmount);
        }
    }
}
