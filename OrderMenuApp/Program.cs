using System;
using System.Runtime.CompilerServices;
using OrderMenuApp.Models;
using Spectre.Console;
using Spectre.Console.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderMenuApp;


partial class MainProgram
{
    private static Pizza pizza = new();
    private static Burger burger = new();
    private static Pasta pasta = new();
    private static Salad salad = new();
    private static Sushi sushi = new();
    static void Main(string[] args)
    {
        ConfigureConsole();


        Table table = new();
        CreateTable(table);

        while (true)
        {
            AnsiConsole.Write(table);

            Console.WriteLine("\nSelect an item by pressing 1 to 5.");
            ConsoleKey number;
            do
            {
                number = Console.ReadKey(intercept: true).Key;

            }while(!CheckUserInput(number));

            AnsiConsole.Clear();
            Dictionary<string, double> orderTypeDictionary = new();
            orderTypeDictionary = ReturnDictionary(number, orderTypeDictionary);
            
            do
            {
                number = Console.ReadKey(intercept: true).Key;

            } while (!CheckUserInput(number));

            int userChoice = 0; 
            userChoice = ReturnChoiceToInt(number, userChoice);
            

            // This method takes the user's choice and adds it as a key in the dictionary, but if the key exists, it replaces it and updates the value.
            Dictionary<string, double> ListOfOrderedDishes = OrderDish.BuildReceipt(userChoice, orderTypeDictionary);

            Console.WriteLine("Running Order:");
            DictionaryInfo(ListOfOrderedDishes);


            // This method takes the user's choice, uses it as a value for the Dictionary and then add that value in a double type List
            OrderDish.AddPriceToList(userChoice, orderTypeDictionary);
            Console.WriteLine($"Total Amount: {OrderDish.PriceList.Sum():C}");

            Console.WriteLine("Press Any Key to continue ordering or ESC to stop ordering.");
            number = Console.ReadKey(intercept: true).Key;
            if (number == ConsoleKey.Escape)
            {
                Console.Clear();
                FinalReceipt(ListOfOrderedDishes);
                break;
            }
            Console.Clear();
        }

    }
}
