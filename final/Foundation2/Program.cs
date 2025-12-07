class Program
{
    static void Main(string[] args)
    {
        Address a1 = new Address("123 Apple St", "Boise", "ID", "USA");
        Customer c1 = new Customer("John Smith", a1);

        Order o1 = new Order(c1);
        o1.AddProduct(new Product("Keyboard", "K001", 25.00, 2));
        o1.AddProduct(new Product("Mouse", "M210", 15.00, 1));

        Address a2 = new Address("55 Ocean Road", "Sydney", "NSW", "Australia");
        Customer c2 = new Customer("Emily Clark", a2);

        Order o2 = new Order(c2);
        o2.AddProduct(new Product("Laptop", "L900", 900.00, 1));
        o2.AddProduct(new Product("Headphones", "H150", 75.00, 2));

        List<Order> orders = new List<Order>() { o1, o2 };

        foreach (Order o in orders)
        {
            Console.WriteLine(o.GetPackingLabel());
            Console.WriteLine(o.GetShippingLabel());
            Console.WriteLine($"Total Price: ${o.GetTotalCost()}");
            Console.WriteLine();
        }
    }
}
