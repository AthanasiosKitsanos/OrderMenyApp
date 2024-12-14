using System;
using OrderMenuApp.Models;
using Spectre.Console;
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
        Createtable(table);

        AnsiConsole.Write(table);

        Console.WriteLine("\nSelect an item.");
        ConsoleKey number;
        do
        {
            number = Console.ReadKey(intercept: true).Key;
            
        } while(number != ConsoleKey.D1 && number != ConsoleKey.NumPad1 &&
                number != ConsoleKey.D2 && number != ConsoleKey.NumPad2 &&
                number != ConsoleKey.D3 && number != ConsoleKey.NumPad3 &&
                number != ConsoleKey.D4 && number != ConsoleKey.NumPad4 &&
                number != ConsoleKey.D5 && number != ConsoleKey.NumPad5);

        AnsiConsole.Clear();

        Dictionary<string, double> newList = number switch
        {
            ConsoleKey.D1 or ConsoleKey.NumPad1 => pizza.ShowListOfSelection(),
            ConsoleKey.D2 or ConsoleKey.NumPad2 => burger.ShowListOfSelection(),
            ConsoleKey.D3 or ConsoleKey.NumPad3 => pasta.ShowListOfSelection(),
            ConsoleKey.D4 or ConsoleKey.NumPad4 => salad.ShowListOfSelection(),
            ConsoleKey.D5 or ConsoleKey.NumPad5 => sushi.ShowListOfSelection(),
        };
        


    }
}