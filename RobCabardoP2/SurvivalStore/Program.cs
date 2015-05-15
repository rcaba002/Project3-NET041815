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
        static void Main(string[] args)
        {
            Menu();

            Console.ReadLine();
        }

        private static void Menu()
        {
            Console.WriteLine("THE SURVIVAL STORE");
            Console.WriteLine("------------------");
            Console.WriteLine("Menu");
            Console.WriteLine("A - See All Products");
            Console.WriteLine("C - See Products By Category");
            Console.WriteLine("S - View Shopping Cart");
            Console.WriteLine("W - View Wallet");
            Console.WriteLine("E - Exit Program");
            Console.WriteLine();
            Console.Write("What would you like to do? ");

            string menuOption = Console.ReadLine().ToUpper();

            if (menuOption == "A")
                Products.seeAllProducts();
            else if (menuOption == "E")
                Environment.Exit(0);
            else
            {
                Console.WriteLine();
                Console.WriteLine("-- I did not understand your input.");
                Console.WriteLine();
                Menu();
            }
        }

        public static void GoBack()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("R - Return To Main Menu");
            Console.WriteLine("E - Exit Program");
            Console.WriteLine();
            Console.Write("What would you like to do? ");
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "R")
            {
                Console.WriteLine();
                Menu();
            }
            else if (userInput == "E")
                Environment.Exit(0);
            else
            {
                Console.WriteLine();
                Console.WriteLine("-- I did not understand your input.");
                Console.WriteLine();
                GoBack();
            }
        }
    }

    public class Products
    {
        //public string category { get; set; }
        //public string name { get; set; }
        //public double price { get; set; }
        //public int num_in_stock { get; set; }

        public static void seeAllProducts()
        {
            string pathToExcelFile = "" + @"C:\Work\Claim\Project3-NET041815\resources\survival_store_inventory.xlsx";

            string sheetName = "survival_store_inventory";

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var productList = from a in excelFile.Worksheet(sheetName) select a;

            Console.WriteLine();

            foreach (var a in productList)
            {
                Console.WriteLine("Name: {0}", a["name"]);
                Console.WriteLine("Category: {0}", a["category"]);
                Console.WriteLine("Price: ${0}", a["price"]);
                Console.WriteLine("Stock Number: {0}", a["num_in_stock"]);
                Console.WriteLine();
            }

            Program.GoBack();
        }
    }
}