using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    
    public List<Product> GetProducts()
    {
        return _products;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    
    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
    public double CalculateTotalCost()
    {
        double totalProductCost = 0;
        
        foreach (Product product in _products)
        {
            totalProductCost += product.GetTotalCost();
        }

        
        double shippingCost = _customer.LivesInUSA() ? 5.00 : 35.00;
        
        return totalProductCost + shippingCost;
    }

    
    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL:\n";
        packingLabel += "=============\n";
        
        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        
        return packingLabel;
    }

    
    public string GetShippingLabel()
    {
        string shippingLabel = "SHIPPING LABEL:\n";
        shippingLabel += "===============\n";
        shippingLabel += $"Customer: {_customer.GetName()}\n";
        shippingLabel += $"Address:\n{_customer.GetAddress().GetFullAddress()}\n";
        
        return shippingLabel;
    }
}