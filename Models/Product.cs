using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4.Models
{
    internal class Product
    {
        // func 1: name, func 2: name+price, func3: name+price+quantity

        public int Quantity { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public bool Stock { get; set; }

        static List<Product> products = new List<Product>();

        public static void getProduct(string name)
        {
            Console.WriteLine($"Product Name: {name}");
        }

        public static void getProduct(string name, int price)
        {
            Console.WriteLine($"Product Name: {name} | Price: {price}$");
        }

        public static void getProduct(string name, int price, int quantity)
        {
            Console.WriteLine($"Product Name: {name} | Price: {price}$ | Total Price: {(price * quantity)}$");
        }

        public static bool setStock(int quantity)
        {
            if(quantity <= 0)
            {
                return false;
            }else
            {
                return true;
            }
        }
        public string checkStock()
        {
            if (Stock)
            {
                return "Product is in stock.";
            }
            else
            {
                return "Product is out of stock.";
            }
        }

        public void getProduct()
        {
            Console.WriteLine($"Product Name: {Name} | Price: {Price}$ | Total Price: {(Price * Quantity)}$ | {this.checkStock()}");
        }

        static void addProduct(string name, int price, int quantity)
        {
            products.Add(new Product { Name = name, Price = price, Quantity = quantity, Stock = setStock(quantity)});
        }

        public static void addMultiProducts()
        {
            Console.WriteLine("Enter the number of products you would like to add:");
            Console.WriteLine("---------------------------------------------------");
            int numProd = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numProd; i++)
            {
                Console.WriteLine($"Please enter the name of product {i + 1}:");
                string name = Console.ReadLine();
                Console.WriteLine($"Please enter the price of product {i + 1}");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Please enter the quantity of product {i + 1}");
                int quantity = Convert.ToInt32(Console.ReadLine());

                addProduct(name, price, quantity);
                Console.WriteLine($"Product {i+1} successfully added.\n");
            }
        }

        public static void displayAllProducts()
        {
            foreach (var product in products)
            {
                product.getProduct();
            }

            Console.WriteLine("---------------------------------------------------");
            checkAllStock();
        }

        public static void checkAllStock()
        {
            int inStock = 0;
            foreach (var product in products)
            {
                

                if (product.Stock)
                {
                    inStock++;
                }
            }

            Console.WriteLine($"Total products in stock: {inStock} | Total products out of stock {products.Count - inStock}");
        }
    }
}
