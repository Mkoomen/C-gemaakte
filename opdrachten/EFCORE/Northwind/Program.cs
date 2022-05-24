using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Northwind.Data
{
    public class Program
    {
        private static string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Northwind";
        
        static void Main(string[] args)
        {
            int orderID = HaalOrderID();
            ToonOrder(orderID);

            //ToonCategories();
            //ToonSuppliers();
            //ToonProducts2();
            //ToonProducts();

        }

        private static void ToonCategories()
        {
            var db = new NorthwindDbContext(_connectionString);
            var categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                Console.Write($"{category.CategoryID}: ");
                Console.WriteLine(category.CategoryName);
            }
            Console.WriteLine();
        }
        public static void ToonSuppliers()
        {
            var db = new NorthwindDbContext(_connectionString);
            var suppliers = db.Suppliers.ToList();
            foreach ( var supplier in suppliers)
            {
                Console.Write($"{supplier.SupplierID}: ");
                Console.WriteLine(supplier.CompanyName);
            }
            Console.WriteLine();
        }
        public static void ToonProducts2()
        {
            int invoer = 0;
            bool validInput = false;

            while (validInput == false)
            {
                try
                {
                    Console.WriteLine("Van welke supplier wilt u de producten zien?");
                    invoer = int.Parse(Console.ReadLine());
                    validInput = true;
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Voer a.u.b. een nummer in.");
                }
            }

            var db = new NorthwindDbContext(_connectionString);
            var products = db.Products.Where(s => s.SupplierID == invoer)
                                      .Include(p => p.Category)
                                      .Include(p => p.Supplier)
                                      .OrderBy(o => o.Category.CategoryName);

            int productCounter = 1;

            foreach ( var product in products)
            {
                Console.Write($"{productCounter++}, ");
                Console.Write($"{product.ProductName}, ");
                Console.Write($"{product.Supplier.CompanyName}, ");
                Console.Write($"{product.Category.CategoryName}");
                Console.WriteLine();
            } 
        }
        public static void ToonProducts()
        {
            int invoer = 0;
            bool validInput = false;

            while (validInput == false)
            {
                try
                {
                    Console.WriteLine("Van welk categorie wilt u de producten zien?");
                    invoer = int.Parse(Console.ReadLine());
                    validInput = true;
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Voer a.u.b. een nummer in.");
                }
            }

            var db = new NorthwindDbContext(_connectionString);

            var products = db.Products.Where(c => c.CategoryID == invoer).Include(p => p.Category).ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.Category.CategoryName);
                Console.Write($"{product.ProductID}: ");
                Console.Write($"{product.ProductName}, ");
                Console.WriteLine($"{product.UnitPrice} euro");
                Console.WriteLine();
            }
        }
        public static int HaalOrderID()
        {
            Console.WriteLine("Type hier uw OrderID in!");
            int orderID = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return orderID;
        }
        public static void ToonOrder(int orderID)
        {
            Console.Clear();

            OrderHeader(orderID);

            OrderDetails(orderID);
        }
        private static void OrderHeader(int orderID)
        {
            var db = new NorthwindDbContext(_connectionString);

            var orders = db.Orders.Where(o => o.OrderID == orderID).Include(c => c.Customer).ToList();

            
            foreach (var items in orders)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(items.Customer.CompanyName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(items.Customer.ContactName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(items.Customer.Address);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(items.Customer.City);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Order:{items.OrderID}    Date:{items.OrderDate}");
                Console.WriteLine();
            }
        }
        private static void OrderDetails(int orderID)
        {
            var db = new NorthwindDbContext(_connectionString);
            var order = db.OrderDetails.Where(o => o.OrderID == orderID)
                                       .Include(p => p.Product)
                                       .ThenInclude(c => c.Category)
                                       .OrderBy(o => o.Product.Category.CategoryName);

            

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0, -20} {1, -35} {2, -15} {3, -15} {4, 5:N2}", "Categorie", "Product", "UnitPrice", "Quantity", "Total");
            foreach (var item in order)
            {
                var total = item.UnitPrice * item.Quantity;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0, -20} {1, -35} {2, -15:N2} {3, -15} {4, 5:N2}", item.Product.Category.CategoryName, item.Product.ProductName, item.UnitPrice, item.Quantity, total);
                Console.ResetColor();
            }
        }

    }
}