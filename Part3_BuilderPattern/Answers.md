# Part 3 - Builder Pattern

# Task 3.1 - Why Are 20-Parameter Constructors a Problem?

# 1. Why is a single 20-parameter constructor a problem?

A constructor with 20 parameters is hard to read and use. It is easy to pass values in the wrong order, especially when they have the same type like string or decimal.

Also, if we add another optional property, the constructor becomes even longer and harder to maintain.

# 2. Is it only because the constructor is too long?

No. The class itself has too many different responsibilities

For example, address information and order/payment information are different concepts. Putting everything in one class makes the design harder to understand and maintain.

---

# Task 3.2 - Builder Redesign

The Builder Pattern makes creating a complex object easier and more readable.

Instead of passing many parameters to the constructor, we can set the properties step by step and then call Build()

Some properties should be mandatory, such as:

* InvoiceId
* CustomerName
* CustomerEmail
* BillingAddress
* ShippingAddress
* PaymentMethod
* Currency
* SubTotal

Other properties can be optional, such as:

* CustomerPhone
* DiscountAmount
* TaxAmount

The Build() method should check the required properties and throw an exception if something is missing.

---

## Task 3.3 - Smaller Composed Builders

We can split the builder into:

* AddressBuilder for address information.
* OrderBuilder for order and payment information.
* InvoiceBuilder to combine everything.

### Why is this better?

**Single Responsibility:**
Each builder has one clear responsibility.

**Independent Validation:**
`AddressBuilder` can validate the address by itself.

**Reuse:**
The same `AddressBuilder` can be used for both billing and shipping addresses.

**Readability:**
The code is easier to understand because the builder structure matches the actual groups of the invoice data.
