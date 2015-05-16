using LinqToExcel;
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("THE SURVIVAL STORE");
            Console.WriteLine();
            Console.ResetColor();

            MainMenu();
        }

        public static void MainMenu()
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
                Products.Menu();
            else if (userInput == "S")
                ShoppingCart.Menu();
            else if (userInput == "W")
                Wallet.Menu();
            else if (userInput == "E")
                Environment.Exit(0);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                MainMenu();
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

        public static void Menu()
        {
            Console.WriteLine("Product Menu");
            Console.WriteLine("------------------");
            Console.WriteLine("V - View All Products");
            Console.WriteLine("N - Sort By Name");
            Console.WriteLine("C - Sort By Category");
            Console.WriteLine("P - Sort By Price");
            Console.WriteLine("M - Main Menu");
            Console.WriteLine();
            Console.Write("C:\\> ");
            
            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userInput == "V")
                sortByAll();
            else if (userInput == "N")
                sortByName();
            else if (userInput == "C")
                sortByCategory();
            else if (userInput == "P")
                sortByPrice();
            else if (userInput == "M")
            {
                Program.MainMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                Menu();
            }
        }

        public static void sortByAll()
        {
            Console.Clear();

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

            Menu();
        }

        public static void sortByName()
        {
            Console.Clear();

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

            Menu();
        }

        public static string subMenuName;

        public static void sortByCategory()
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
                subMenuName = "F";
                sortBySpecific("food");
            }
            else if (userInput == "T")
            {
                subMenuName = "T";
                sortBySpecific("tools and supplies");
            }
            else if (userInput == "M")
            {
                subMenuName = "M";
                sortBySpecific("first aid and medical");
            }
            else if (userInput == "W")
            {
                subMenuName = "W";
                sortBySpecific("warmth and shelter");
            }
            else if (userInput == "C")
            {
                subMenuName = "C";
                sortBySpecific("clothing");
            }
            else if (userInput == "O")
            {
                subMenuName = "O";
                sortBySpecific("cooking and fuel");
            }
            else if (userInput == "H")
            {
                subMenuName = "H";
                sortBySpecific("sanitation and hygiene");
            }
            else if (userInput == "S")
            {
                subMenuName = "S";
                sortBySpecific("survival kits");
            }
            else if (userInput == "L")
            {
                subMenuName = "L";
                sortBySpecific("light and communication");
            }
            else if (userInput == "B")
            {
                subMenuName = "B";
                sortBySpecific("backpacks");
            }
            else if (userInput == "E")
            {
                subMenuName = "E";
                sortBySpecific("emergency power");
            }
            else if (userInput == "G")
            {
                Menu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                sortByCategory();
            }
        }

        public static void sortByPrice()
        {
            Console.Clear();

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

            Menu();
        }

        public static void sortAdditionalMenu()
        {
            Console.WriteLine("Additional Sort");
            Console.WriteLine("------------------");
            Console.WriteLine("N - Sort By Name");
            Console.WriteLine("P - Sort By Price");
            Console.WriteLine("G - Go Back");
            Console.WriteLine();
            Console.Write("C:\\> ");

            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "N")
            {
                if (subMenuName == "F")
                    sortBySpecificWithName("food");
                else if (subMenuName == "T")
                    sortBySpecificWithName("tools and supplies");
                else if (subMenuName == "M")
                    sortBySpecificWithName("first aid and medical");
                else if (subMenuName == "W")
                    sortBySpecificWithName("warmth and shelter");
                else if (subMenuName == "C")
                    sortBySpecificWithName("clothing");
                else if (subMenuName == "O")
                    sortBySpecificWithName("cooking and fuel");
                else if (subMenuName == "H")
                    sortBySpecificWithName("sanitation and hygiene");
                else if (subMenuName == "S")
                    sortBySpecificWithName("survival kits");
                else if (subMenuName == "L")
                    sortBySpecificWithName("light and communication");
                else if (subMenuName == "B")
                    sortBySpecificWithName("backpack");
                else if (subMenuName == "E")
                    sortBySpecificWithName("emergency power");
            }
            else if (userInput == "P")
            {
                if (subMenuName == "F")
                    sortBySpecificWithPrice("food");
                else if (subMenuName == "T")
                    sortBySpecificWithPrice("tools and supplies");
                else if (subMenuName == "M")
                    sortBySpecificWithPrice("first aid and medical");
                else if (subMenuName == "W")
                    sortBySpecificWithPrice("warmth and shelter");
                else if (subMenuName == "C")
                    sortBySpecificWithPrice("clothing");
                else if (subMenuName == "O")
                    sortBySpecificWithPrice("cooking and fuel");
                else if (subMenuName == "H")
                    sortBySpecificWithPrice("sanitation and hygiene");
                else if (subMenuName == "S")
                    sortBySpecificWithPrice("survival kits");
                else if (subMenuName == "L")
                    sortBySpecificWithPrice("light and communication");
                else if (subMenuName == "B")
                    sortBySpecificWithPrice("backpack");
                else if (subMenuName == "E")
                    sortBySpecificWithPrice("emergency power");
            }
            else if (userInput == "G")
            {
                Console.WriteLine();
                Menu();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The term '" + userInput + "' is not recognized.");
                Console.ResetColor();
                Console.WriteLine();
                sortAdditionalMenu();
            }
        }

        public static void sortBySpecific(string input)
        {
            Console.Clear();

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

            sortAdditionalMenu();
        }

        public static void sortBySpecificWithName(string input)
        {
            Console.Clear();

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

            Menu();
        }

        public static void sortBySpecificWithPrice(string input)
        {
            Console.Clear();

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

            Menu();
        }
    }

    class Wallet
    {
        public static void Menu()
        {
            Random rand = new Random();
            int balance = rand.Next(500,2000);

            Console.WriteLine("BofA Core Checking - 4419");
            Console.WriteLine("{0:C2}", balance);

            Console.ReadLine();
        }
    }

    class ShoppingCart
    {
        public static void Menu()
        {
        }
    }
}