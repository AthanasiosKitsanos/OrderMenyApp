using OrderMenuApp.Models;
using Spectre.Console;
using System;

namespace OrderMenuApp;

partial class MainProgram
{
    private static void Createtable(Table table)
    {
        table.AddColumn(new TableColumn("[Yellow]List Menu[/]"));
        table.AddRow($"1. {nameof(Pizza)}");
        table.AddRow($"2. {nameof(Burger)}");
        table.AddRow($"3. {nameof(Pasta)}");
        table.AddRow($"4. {nameof(Salad)}");
        table.AddRow($"5. {nameof(Sushi)}");
    }
}

