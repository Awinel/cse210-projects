using System;

class Program
{
    static void Main(string[] args)
    {

        Address address1 = new Address("421 Main St", "Utah", "UT", "USA");
        Customer customer1 = new Customer("Ivo Mac", address1);
        Order order1 = new Order(customer1);

        Product product1 = new Product("Wireless Headphones", "ZY-701", 79.99, 2);
        Product product2 = new Product("Phone Case", "AA-3335", 15.50, 1);
        Product product3 = new Product("USB Cable", "CC-120", 12.99, 3);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        Address address2 = new Address("456 Maple Avenue", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sarah Johnson", address2);
        Order order2 = new Order(customer2);

        Product product4 = new Product("Bluetooth Speaker", "A-31", 45.00, 1);
        Product product5 = new Product("Screen Protector", "WW-150", 8.99, 2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Address address3 = new Address("4th Street", "Santiago", "RM", "Chile");
        Customer customer3 = new Customer("Benjamin Huerta", address3);
        Order order3 = new Order(customer3);

        Product product6 = new Product("Laptop", "AMD-210", 800, 1);

        order3.AddProduct(product6);

        
        Console.WriteLine("ORDER 1:");
        Console.WriteLine("========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        
        Console.WriteLine("ORDER 2:");
        Console.WriteLine("========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");

        Console.WriteLine("ORDER 3:");
        Console.WriteLine("========");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order3.CalculateTotalCost():F2}");
    }
}