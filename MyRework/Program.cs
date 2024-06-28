using System;
using System.Collections.Generic;
using System.Linq;

abstract class Delivery
{
    public string Address; // Base delivery class
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; } // Address properties
    public string PostalCode { get; set; }
}

class HomeDelivery : Delivery
{
    public string CourierName { get; set; } // Courier's name
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; } // Product name, price
}

class OrderItem
{
    public Product Product { get; set; } // Additional product properties (quantity, promotions)
    public int Quantity { get; set; }
}

class PickPointDelivery : Delivery
{
    public string PickPointId { get; set; } // Other delivery properties
}

class ShopDelivery : Delivery
{
    public string ShopName { get; set; } // Shop delivery properties
}

class Order<TDelivery> where TDelivery : Delivery
{
    public TDelivery Delivery { get; set; }
    public int OrderNumber { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Display delivery address.
    /// </summary>
    public void DisplayDeliveryAddress()
    {
        Console.WriteLine(Delivery.Address);
    }

    /// <summary>
    /// Add an order item to the order.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <param name="quantity">The quantity of the product.</param>
    public void AddOrderItem(Product product, int quantity)
    {
        OrderItems.Add(new OrderItem { Product = product, Quantity = quantity });
    }

    /// <summary>
    /// Calculate the total amount of the order.
    /// </summary>
    public void CalculateTotalAmount()
    {
        TotalAmount = OrderItems.Sum(item => item.Product.Price * item.Quantity);
    }
}
