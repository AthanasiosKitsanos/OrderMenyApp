using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Salad : ProductOrder
{
    public Salad()
    {
        TypeOfProduct = new Dictionary<string, double>
        {
            {"Asian", 7.5},
            {"American", 6.9},
            {"Chicken Ceasar's", 6.4},
            {"Vegetable Cobb", 7.5},
            {"Chef", 6.1}
        };
    }

    public override Dictionary<string, double> ShowListOfSelection()
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Salad)}");
        table.AddColumn("Prices");
        foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
        {
            number++;
            table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
        }
        AnsiConsole.Write(table);
        Console.WriteLine($"Select the type of {nameof(Salad)}.");
        return this.TypeOfProduct;
    }
}

