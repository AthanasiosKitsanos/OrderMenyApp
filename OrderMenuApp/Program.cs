﻿using System;
using System.Runtime.CompilerServices;
using OrderMenuApp.Models;
using Spectre.Console;
using Spectre.Console.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderMenuApp;


partial class MainProgram
{
    static void Main(string[] args)
    {
        ConfigureConsole();

        Pizza pizza = new();
        Burger burger = new();
        Pasta pasta = new();
        Salad salad = new();
        Sushi sushi = new();

        pizza.AddToDict();
        burger.AddToDict();
        pasta.AddToDict();
        salad.AddToDict();
        sushi.AddToDict();

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

            Dictionary<string, double> orderTypeDictionary = number switch
            {
                ConsoleKey.D1 or ConsoleKey.NumPad1 => pizza.ShowListOfSelection(),
                ConsoleKey.D2 or ConsoleKey.NumPad2 => burger.ShowListOfSelection(),
                ConsoleKey.D3 or ConsoleKey.NumPad3 => pasta.ShowListOfSelection(),
                ConsoleKey.D4 or ConsoleKey.NumPad4 => salad.ShowListOfSelection(),
                ConsoleKey.D5 or ConsoleKey.NumPad5 => sushi.ShowListOfSelection(),
            };

            do
            {
                number = Console.ReadKey(intercept: true).Key;

            } while (!CheckUserInput(number));

            int userChoice = number switch
            {
                ConsoleKey.D1 or ConsoleKey.NumPad1 => 1,
                ConsoleKey.D2 or ConsoleKey.NumPad2 => 2,
                ConsoleKey.D3 or ConsoleKey.NumPad3 => 3,
                ConsoleKey.D4 or ConsoleKey.NumPad4 => 4,
                ConsoleKey.D5 or ConsoleKey.NumPad5 => 5,
            };

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