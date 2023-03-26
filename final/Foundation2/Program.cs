using System;

class Program
{
    static void Main(string[] args)
    {
        // create two customers
        Address usaAddress = new Address("123 Main St.", "Parkland", "FL", "USA");
        Customer customer1 = new Customer("Sariah Michel", usaAddress);
        Address nonUsaAddress = new Address("456 High St.", "New York City", "NY", "USA");
        Customer customer2 = new Customer("Johnathan Steinkamp", nonUsaAddress);

        // create some products
        Product product1 = new Product("3090 Ti Founders Edition", "W1", 2499.99, 1);
        Product product2 = new Product("G-Pro Wireless", "G1", 109.99, 1);
        Product product3 = new Product("Private Item", "T1", 14.99, 1);

        // create two orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // display the packing label, shipping label, and total price for each order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: {order1.CalculateTotalPrice():C}");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: {order2.CalculateTotalPrice():C}");
    }
}

class Order
{
    private Customer customer;
    private Product[] products;
    private int numProducts;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new Product[10];
        numProducts = 0;
    }

    public void AddProduct(Product product)
    {
        products[numProducts] = product;
        numProducts++;
    }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (Product product in products)
        {
            if (product != null)
            {
                totalPrice += product.Price * product.Quantity;
            }
        }

        if (customer.IsInUSA())
        {
            totalPrice += 5.0;
        }
        else
        {
            totalPrice += 35.0;
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in products)
        {
            if (product != null)
            {
                label += $"{product.Name} ({product.Id})\n";
            }
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"{customer.Name}\n{customer.Address.GetFullAddress()}";
    }
}

class Product
{
    private string name;
    private string id;
    private double price;
    private int quantity;

    public Product(string name, string id, double price, int quantity)
    {
        this.name = name;
        this.id = id;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name { get { return name; } }
    public string Id { get { return id; } }
    public double Price { get { return price; } }
    public int Quantity { get { return quantity; } }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name { get { return name; } }
    public Address Address { get { return address; } }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string Street { get { return street; } }
    public string City { get { return city; } }
    public string State { get { return state; } }
    public string Country { get { return country; } }

    public bool IsInUSA()
    {
        return country.Equals("USA");
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state} {country}";
    }
}
