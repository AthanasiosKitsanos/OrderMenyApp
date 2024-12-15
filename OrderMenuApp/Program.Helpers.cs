using OrderMenuApp.Models;
using Spectre.Console;
using System;
using System.IO;

namespace OrderMenuApp;

partial class MainProgram
{
    private static void CreateTable(Table table)
    {
        table.AddColumn(new TableColumn("[Yellow]List Menu[/]"));
        table.AddRow($"1. {nameof(Pizza)}");
        table.AddRow($"2. {nameof(Burger)}");
        table.AddRow($"3. {nameof(Pasta)}");
        table.AddRow($"4. {nameof(Salad)}");
        table.AddRow($"5. {nameof(Sushi)}");
    }

    private static bool CheckUserInput(ConsoleKey number)
    {
        if (number != ConsoleKey.D1 && number != ConsoleKey.NumPad1 &&
                   number != ConsoleKey.D2 && number != ConsoleKey.NumPad2 &&
                   number != ConsoleKey.D3 && number != ConsoleKey.NumPad3 &&
                   number != ConsoleKey.D4 && number != ConsoleKey.NumPad4 &&
                   number != ConsoleKey.D5 && number != ConsoleKey.NumPad5)
        {
            return false;
        }
        return true;
    }

    private static void DictionaryInfo(Dictionary<string, double> dictionary)
    {
        foreach(KeyValuePair<string, double> kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key}:  ${kvp.Value:F2}\n");
        }
    }

    private static void FinalReceipt(Dictionary<string, double> someDict)
    {
        DateTime dateTime = DateTime.Now;
        Console.WriteLine("Receipt:");
        DictionaryInfo(someDict);
        Console.WriteLine($"Total Amount: {OrderDish.PriceList.Sum():C}");
        Console.WriteLine($"{dateTime:HH:mm:ss dd/MM/yyyy}");
    }

    private static Dictionary<string, double> ReturnDictionary(ConsoleKey num, Dictionary<string, double> dictionary)
    {
        dictionary = num switch
        {
            ConsoleKey.D1 or ConsoleKey.NumPad1 => pizza.ShowListOfSelection(),
            ConsoleKey.D2 or ConsoleKey.NumPad2 => burger.ShowListOfSelection(),
            ConsoleKey.D3 or ConsoleKey.NumPad3 => pasta.ShowListOfSelection(),
            ConsoleKey.D4 or ConsoleKey.NumPad4 => salad.ShowListOfSelection(),
            ConsoleKey.D5 or ConsoleKey.NumPad5 => sushi.ShowListOfSelection()
        };
        return dictionary;
    }

    private static int ReturnChoiceToInt(ConsoleKey num, int userChoice)
    {
        userChoice = num switch
        {
            ConsoleKey.D1 or ConsoleKey.NumPad1 => 1,
            ConsoleKey.D2 or ConsoleKey.NumPad2 => 2,
            ConsoleKey.D3 or ConsoleKey.NumPad3 => 3,
            ConsoleKey.D4 or ConsoleKey.NumPad4 => 4,
            ConsoleKey.D5 or ConsoleKey.NumPad5 => 5,
        };
        return userChoice;
    }
}

