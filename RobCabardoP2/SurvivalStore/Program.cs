﻿using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalStore
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<ShoppingCart> cart = new List<ShoppingCart>();

            MainMenu(ref cart);
        }

        public static void MainMenu(ref List<ShoppingCart> cart)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("------------------");
            Console.WriteLine("V - View Products");
            Console.WriteLine("S - View Shopping Cart");
            Console.WriteLine("W - View Wallet");
            Console.WriteLine("E - Exit Program");
            Console.WriteLine();
            Console.Write("C:\\> ");

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userInput == "V")
            {
                Console.Clear();
                Products.Menu(ref cart);
            }
            else if (userInput == "S")
            {
                Console.Clear();
                ShoppingCart.Menu(ref cart);
            }
            else if (userInput == "W")
            {
                Console.Clear();
                Wallet.Menu(ref cart);
            }
            else if (userInput == "E")
                Environment.Exit(0);
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                MainMenu(ref cart);
            }
        }
    }

    class Products
    {
        public string category { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int num_in_stock { get; set; }
        public int product_ID { get; set; }

        public static string additionalFilter;

        public static void Menu(ref List<ShoppingCart> cart)
        {
            Console.WriteLine("Product Menu");
            Console.WriteLine("------------------");
            Console.WriteLine("V - View All Products");
            Console.WriteLine("N - Sort By Name");
            Console.WriteLine("C - Sort By Category");
            Console.WriteLine("P - Sort By Price");
            Console.WriteLine("A - Add To Cart");
            Console.WriteLine("M - Main Menu");
            Console.WriteLine();
            Console.Write("C:\\> ");
            
            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userInput == "V")
            {
                Console.Clear();
                sortByAll(ref cart);
            }
            else if (userInput == "N")
            {
                Console.Clear();
                sortByName(ref cart);
            }
            else if (userInput == "C")
            {
                Console.Clear();
                CategoryMenu(ref cart);
            }
            else if (userInput == "P")
            {
                Console.Clear();
                sortByPrice(ref cart);
            }
            else if (userInput == "A")
            {
                ShoppingCart.addProductMenu(ref cart);
            }
            else if (userInput == "M")
            {
                Console.Clear();
                Program.MainMenu(ref cart);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                Menu(ref cart);
            }
        }

        public static void CategoryMenu(ref List<ShoppingCart> cart)
        {
            Console.WriteLine("Product Sort Menu");
            Console.WriteLine("------------------");
            Console.WriteLine("F - Food                         T - Tools and Supplies");
            Console.WriteLine("M - First Aid and Medical        W - Warmth and Shelter");
            Console.WriteLine("C - Clothing                     O - Cooking and Fuel");
            Console.WriteLine("H - Sanitation and Hygiene       S - Survival Kits");
            Console.WriteLine("L - Light and Communication      B - Backpacks");
            Console.WriteLine("E - Emergency Power              G - Go Back");
            Console.WriteLine();
            Console.Write("C:\\> ");

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userInput == "F")
            {
                Console.Clear();
                additionalFilter = "F";
                sortByCategory("food", ref cart);
            }
            else if (userInput == "T")
            {
                Console.Clear();
                additionalFilter = "T";
                sortByCategory("tools and supplies", ref cart);
            }
            else if (userInput == "M")
            {
                Console.Clear();
                additionalFilter = "M";
                sortByCategory("first aid and medical", ref cart);
            }
            else if (userInput == "W")
            {
                Console.Clear();
                additionalFilter = "W";
                sortByCategory("warmth and shelter", ref cart);
            }
            else if (userInput == "C")
            {
                Console.Clear();
                additionalFilter = "C";
                sortByCategory("clothing", ref cart);
            }
            else if (userInput == "O")
            {
                Console.Clear();
                additionalFilter = "O";
                sortByCategory("cooking and fuel", ref cart);
            }
            else if (userInput == "H")
            {
                Console.Clear();
                additionalFilter = "H";
                sortByCategory("sanitation and hygiene", ref cart);
            }
            else if (userInput == "S")
            {
                Console.Clear();
                additionalFilter = "S";
                sortByCategory("survival kits", ref cart);
            }
            else if (userInput == "L")
            {
                Console.Clear();
                additionalFilter = "L";
                sortByCategory("light and communication", ref cart);
            }
            else if (userInput == "B")
            {
                Console.Clear();
                additionalFilter = "B";
                sortByCategory("backpacks", ref cart);
            }
            else if (userInput == "E")
            {
                Console.Clear();
                additionalFilter = "E";
                sortByCategory("emergency power", ref cart);
            }
            else if (userInput == "G")
            {
                Console.Clear();
                Menu(ref cart);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                CategoryMenu(ref cart);
            }
        }

        public static void additionalSortMenu(ref List<ShoppingCart> cart)
        {
            Console.WriteLine("Additional Sort");
            Console.WriteLine("------------------");
            Console.WriteLine("N - Sort By Name");
            Console.WriteLine("P - Sort By Price");
            Console.WriteLine("A - Add To Cart");
            Console.WriteLine("G - Go Back");
            Console.WriteLine();
            Console.Write("C:\\> ");

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userInput == "N")
            {
                if (additionalFilter == "F")
                {
                    Console.Clear();
                    sortByCategoryWithName("food", ref cart);
                }
                else if (additionalFilter == "T")
                {
                    Console.Clear();
                    sortByCategoryWithName("tools and supplies", ref cart);
                }
                else if (additionalFilter == "M")
                {
                    Console.Clear();
                    sortByCategoryWithName("first aid and medical", ref cart);
                }
                else if (additionalFilter == "W")
                {
                    Console.Clear();
                    sortByCategoryWithName("warmth and shelter", ref cart);
                }
                else if (additionalFilter == "C")
                {
                    Console.Clear();
                    sortByCategoryWithName("clothing", ref cart);
                }
                else if (additionalFilter == "O")
                {
                    Console.Clear();
                    sortByCategoryWithName("cooking and fuel", ref cart);
                }
                else if (additionalFilter == "H")
                {
                    Console.Clear();
                    sortByCategoryWithName("sanitation and hygiene", ref cart);
                }
                else if (additionalFilter == "S")
                {
                    Console.Clear();
                    sortByCategoryWithName("survival kits", ref cart);
                }
                else if (additionalFilter == "L")
                {
                    Console.Clear();
                    sortByCategoryWithName("light and communication", ref cart);
                }
                else if (additionalFilter == "B")
                {
                    Console.Clear();
                    sortByCategoryWithName("backpack", ref cart);
                }
                else if (additionalFilter == "E")
                {
                    Console.Clear();
                    sortByCategoryWithName("emergency power", ref cart);
                }
            }
            else if (userInput == "P")
            {
                if (additionalFilter == "F")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("food", ref cart);
                }
                else if (additionalFilter == "T")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("tools and supplies", ref cart);
                }
                else if (additionalFilter == "M")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("first aid and medical", ref cart);
                }
                else if (additionalFilter == "W")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("warmth and shelter", ref cart);
                }
                else if (additionalFilter == "C")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("clothing", ref cart);
                }
                else if (additionalFilter == "O")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("cooking and fuel", ref cart);
                }
                else if (additionalFilter == "H")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("sanitation and hygiene", ref cart);
                }
                else if (additionalFilter == "S")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("survival kits", ref cart);
                }
                else if (additionalFilter == "L")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("light and communication", ref cart);
                }
                else if (additionalFilter == "B")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("backpack", ref cart);
                }
                else if (additionalFilter == "E")
                {
                    Console.Clear();
                    sortByCategoryWithPrice("emergency power", ref cart);
                }
            }
            else if (userInput == "A")
                ShoppingCart.addProductMenu(ref cart);
            else if (userInput == "G")
            {
                Console.Clear();
                Menu(ref cart);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                additionalSortMenu(ref cart);
            }
        }

        public static void sortByAll(ref List<ShoppingCart> cart)
        {
            var excelFile = new ExcelQueryFactory("" + @"C:\Work\Claim\Project3-NET041815\resources\survival_store_inventory.xlsx");
            var productList = from a in excelFile.Worksheet<Products>("survival_store_inventory") select a;

            foreach (var a in productList)
            {
                Console.WriteLine("Name: {0}", a.name);
                Console.WriteLine("Product ID: {0}", Convert.ToInt32(a.product_ID));

                if (Convert.ToInt32(a.num_in_stock) != 0)
                    Console.WriteLine("Item In Stock");

                Console.WriteLine();
            }

            Menu(ref cart);
        }

        public static void sortByName(ref List<ShoppingCart> cart)
        {
            var excelFile = new ExcelQueryFactory("" + @"C:\Work\Claim\Project3-NET041815\resources\survival_store_inventory.xlsx");
            var productList = from a in excelFile.Worksheet<Products>("survival_store_inventory").OrderBy(x => x.name).ToList() select a;

            foreach (var a in productList)
            {
                Console.Write("Name: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0}", a.name);
                Console.ResetColor();
                Console.WriteLine("Product ID: {0}", Convert.ToInt32(a.product_ID));

                if (Convert.ToInt32(a.num_in_stock) != 0)
                    Console.WriteLine("Item In Stock");

                Console.WriteLine();
            }

            Menu(ref cart);
        }

        public static void sortByPrice(ref List<ShoppingCart> cart)
        {
            var excelFile = new ExcelQueryFactory("" + @"C:\Work\Claim\Project3-NET041815\resources\survival_store_inventory.xlsx");
            var productList = from a in excelFile.Worksheet<Products>("survival_store_inventory").OrderBy(x => x.price).ToList() select a;

            foreach (var a in productList)
            {
                Console.WriteLine("Name: {0}", a.name);
                Console.WriteLine("Product ID: {0}", Convert.ToInt32(a.product_ID));
                Console.Write("Price: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0:C2}", Convert.ToDouble(a.price));
                Console.ResetColor();

                if (Convert.ToInt32(a.num_in_stock) != 0)
                    Console.WriteLine("Item In Stock");

                Console.WriteLine();
            }

            Menu(ref cart);
        }

        public static void sortByCategory(string input, ref List<ShoppingCart> cart)
        {
            var excelFile = new ExcelQueryFactory("" + @"C:\Work\Claim\Project3-NET041815\resources\survival_store_inventory.xlsx");
            var productList = from a in excelFile.Worksheet<Products>("survival_store_inventory") select a;

            foreach (var a in productList)
            {
                if (a.category == input)
                {
                    Console.WriteLine("Name: {0}", a.name);
                    Console.WriteLine("Product ID: {0}", Convert.ToInt32(a.product_ID));
                    Console.Write("Category: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("{0}", a.category);
                    Console.ResetColor();
                    Console.WriteLine("Price: {0:C2}", Convert.ToDouble(a.price));

                    if (Convert.ToInt32(a.num_in_stock) != 0)
                        Console.WriteLine("Item In Stock");

                    Console.WriteLine();
                }
            }

            additionalSortMenu(ref cart);
        }

        public static void sortByCategoryWithName(string input, ref List<ShoppingCart> cart)
        {
            var excelFile = new ExcelQueryFactory("" + @"C:\Work\Claim\Project3-NET041815\resources\survival_store_inventory.xlsx");
            var productList = from a in excelFile.Worksheet<Products>("survival_store_inventory").OrderBy(x => x.name).ToList() select a;

            foreach (var a in productList)
            {
                if (a.category == input)
                {
                    Console.Write("Name: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("{0}", a.name);
                    Console.ResetColor();
                    Console.WriteLine("Product ID: {0}", Convert.ToInt32(a.product_ID));
                    Console.WriteLine("Price: {0:C2}", Convert.ToDouble(a.price));

                    if (Convert.ToInt32(a.num_in_stock) != 0)
                        Console.WriteLine("Item In Stock");

                    Console.WriteLine();
                }
            }

            Menu(ref cart);
        }

        public static void sortByCategoryWithPrice(string input, ref List<ShoppingCart> cart)
        {
            var excelFile = new ExcelQueryFactory("" + @"C:\Work\Claim\Project3-NET041815\resources\survival_store_inventory.xlsx");
            var productList = from a in excelFile.Worksheet<Products>("survival_store_inventory").OrderBy(x => x.price).ToList() select a;

            foreach (var a in productList)
            {
                if (a.category == input)
                {
                    Console.WriteLine("Name: {0}", a.name);
                    Console.WriteLine("Product ID: {0}", Convert.ToInt32(a.product_ID));
                    Console.Write("Price: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("{0:C2}", Convert.ToDouble(a.price));
                    Console.ResetColor();

                    if (Convert.ToInt32(a.num_in_stock) != 0)
                        Console.WriteLine("Item In Stock");

                    Console.WriteLine();
                }
            }

            Menu(ref cart);
        }
    }

    class Wallet
    {
        public static void Menu(ref List<ShoppingCart> cart)
        {
            Random rand = new Random();
            int balance = rand.Next(500,2000);

            Console.WriteLine("BofA Core Checking - 4419");
            Console.WriteLine("{0:C2}", balance);
            Console.WriteLine();

            Program.MainMenu(ref cart);
        }
    }

    class ShoppingCart
    {
        public string name { get; set; }
        public int product_ID { get; set; }
        public double price { get; set; }

        public ShoppingCart(string Name, int Product_ID, double Price)
        {
            name = Name;
            product_ID = Product_ID;
            price = Price;
        }

        public static void Menu(ref List<ShoppingCart> cart)
        {
            string itemsInCart = null;

            foreach (ShoppingCart item in cart)
            {
                itemsInCart = "found";

                Console.Write("Name:");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0}", item.name);
                Console.ResetColor();
                Console.WriteLine("Product ID: {0}", item.product_ID);
                Console.WriteLine("Price: {0:C2}", item.price);
                Console.WriteLine();
            }

            if (itemsInCart == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Cart is empty.");
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine("Cart Menu");
            Console.WriteLine("------------------");
            if (itemsInCart == null)
                Console.WriteLine("S - Shop Products");
            else
            {
                Console.WriteLine("C - Continue Shopping");
                Console.WriteLine("R - Remove Product");
            }
            Console.WriteLine("M - Main Menu");
            Console.WriteLine();
            Console.Write("C:\\> ");

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userInput == "S" || userInput == "C")
            {
                Console.Clear();
                Products.Menu(ref cart);
            }
            else if (userInput == "R")
            {
                removeProductMenu(ref cart);
            }
            else if (userInput == "M")
            {
                Console.Clear();
                Program.MainMenu(ref cart);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                Menu(ref cart);
            }
        }

        public static void addProductMenu(ref List<ShoppingCart> cart)
        {
            Console.WriteLine("Add Product Menu");
            Console.WriteLine("------------------");
            Console.WriteLine("E - Enter Product ID");
            Console.WriteLine("G - Go Back");
            Console.WriteLine();
            Console.Write("C:\\> ");

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userInput == "E")
                addProduct(ref cart);
            else if (userInput == "G")
            {
                Console.Clear();
                Products.Menu(ref cart);
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                addProductMenu(ref cart);
            }
        }

        public static void removeProductMenu(ref List<ShoppingCart> cart)
        {
            Console.WriteLine("Remove Product Menu");
            Console.WriteLine("------------------");
            Console.WriteLine("E - Enter Product ID");
            Console.WriteLine("G - Go Back");
            Console.WriteLine();
            Console.Write("C:\\> ");

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userInput == "E")
                removeProduct(ref cart);
            else if (userInput == "G")
            {
                Console.Clear();
                Menu(ref cart);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                removeProductMenu(ref cart);
            }
        }

        public static void addProduct(ref List<ShoppingCart> cart)
        {
            string itemFound = null;

            Console.Write("C:\\> Product ID: ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            var excelFile = new ExcelQueryFactory("" + @"C:\Work\Claim\Project3-NET041815\resources\survival_store_inventory.xlsx");
            var productList = from a in excelFile.Worksheet<Products>("survival_store_inventory") select a;

            foreach (var a in productList)
            {
                if (userInput == Convert.ToString(a.product_ID))
                {
                    if (Convert.ToInt32(a.num_in_stock) != 0)
                    {
                        itemFound = "found";
                        string Name = a.name;
                        int Product_ID = a.product_ID;
                        double Price = Convert.ToDouble(a.price);
                        ShoppingCart newItem = new ShoppingCart(Name, Product_ID, Price);
                        cart.Add(newItem);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(Name + " added to cart.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Program.MainMenu(ref cart);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Item not in stock.");
                        Console.ResetColor();
                        Console.WriteLine();
                        addProductMenu(ref cart);
                    }

                    break;
                }
            }

            if (itemFound == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Item not found.");
                Console.ResetColor();
                Console.WriteLine();
                addProductMenu(ref cart);
            }
        }

        public static void removeProduct(ref List<ShoppingCart> cart)
        {
            Console.Write("C:\\> Product ID: ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            foreach (ShoppingCart item in cart)
            {
                if (userInput == Convert.ToString(item.product_ID))
                {
                    cart.Remove(item);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(item.name + " removed from cart.");
                    Console.ResetColor();
                    Console.WriteLine();

                    ShoppingCart.Menu(ref cart);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Item not found.");
                    Console.ResetColor();
                    Console.WriteLine();
                    removeProductMenu(ref cart);
                }
            }

            Program.MainMenu(ref cart);
        }
    }
}