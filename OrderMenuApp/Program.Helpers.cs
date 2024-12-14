using OrderMenuApp.Models;
using Spectre.Console;
using System;

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
}

