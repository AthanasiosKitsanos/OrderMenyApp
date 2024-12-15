using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Pizza : ProductOrder
{
    public Pizza()
    {
        TypeOfProduct = new Dictionary<string, double>
        {
            {"Margarita", 7.4},
            {"BBQ Chicken", 9.9},
            {"Ceasar's", 9.9},
            {"Mexicana", 9.3},
            {"Siciliana", 7.9}
        };
    }

    public override Dictionary<string, double> ShowListOfSelection()
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Pizza)}");
        table.AddColumn("Prices");
        foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
        {
            number++;
            table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
        }
        AnsiConsole.Write(table);
        Console.WriteLine($"Select the type of {nameof(Pizza)}.");
        return this.TypeOfProduct;
    }
}

