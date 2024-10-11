using System;
using System.Collections.Generic;

namespace MarvelOrderSystem
{
    public class Product
    {
        private string _Name;
        private string _ProductID;
        private double _Price;
        private int _Quantity;
        private double _Discount;

        public Product(string name, string productID, double price, int quantity, double discount = 0)
        {
            _Name = name;
            _ProductID = productID;
            _Price = price;
            _Quantity = quantity;
            _Discount = discount;
        }

        public double GetTotalCost()
        {
            return (_Price * _Quantity) * (1 - (_Discount / 100));
        }

        public string GetPackingLabel()
        {
            return $"{_Name} (ID: {_ProductID})";
        }

        public double GetDiscount()
        {
            return _Discount;
        }
    }

    public class Address
    {
        private string _Street;
        private string _City;
        private string _State;
        private string _Country;

        public Address(string street, string city, string state, string country)
        {
            _Street = street;
            _City = city;
            _State = state;
            _Country = country;
        }

        public bool IsInUSA()
        {
            return _Country == "USA";
        }

        public string GetFullAddress()
        {
            return $"{_Street}\n{_City}, {_State}\n{_Country}";
        }
    }

    public class Customer
    {
        private string _Name;
        private Address _Address;

        public Customer(string name, Address address)
        {
            _Name = name;
            _Address = address;
        }

        public bool IsInUSA()
        {
            return _Address.IsInUSA();
        }

        public string GetShippingLabel()
        {
            return $"{_Name}\n{_Address.GetFullAddress()}";
        }
    }

    public class Order
    {
        private List<Product> _Products = new List<Product>();
        private Customer _Customer;

        public Order(Customer customer)
        {
            _Customer = customer;
        }

        public void AddProduct(Product product)
        {
            _Products.Add(product);
        }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var product in _Products)
            {
                total += product.GetTotalCost();
            }

            double shippingCost = _Customer.IsInUSA() ? 5.0 : 35.0;
            return total + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in _Products)
            {
                label += $"{product.GetPackingLabel()}\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{_Customer.GetShippingLabel()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address starkAddress = new Address("10880 Malibu Point", "Malibu", "CA", "USA");
            Customer tonyStark = new Customer("Tony Stark", starkAddress);

            Address wakandaAddress = new Address("Golden City", "Birnin Zana", "Wakanda", "Wakanda");
            Customer tChalla = new Customer("T'Challa", wakandaAddress);

            Product ironManSuit = new Product("Iron Man Suit", "MK-50", 3500000.99, 1);
            Product vibraniumShield = new Product("Vibranium Shield", "SHIELD-001", 1500000.75, 1);
            Product arcReactor = new Product("Arc Reactor", "ARC-002", 2500000.50, 1);

            Order order1 = new Order(tonyStark);
            order1.AddProduct(ironManSuit);
            order1.AddProduct(arcReactor);

            Order order2 = new Order(tChalla);
            order2.AddProduct(vibraniumShield);

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: {order1.GetTotalPrice():C}");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: {order2.GetTotalPrice():C}");
        }
    }
}
