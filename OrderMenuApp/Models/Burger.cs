using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Burger : ProductOrder
{
    public Burger()
    {
        TypeOfProduct = new Dictionary<string, double>
        {
            {"Humburger", 4.8},
            {"Cheeseburger", 5.6},
            {"Bacon Dream", 6.4},
            {"Smokey BBQ", 6.4},
            {"Chicken Avocado", 7.5}
        };
    }

    public override Dictionary<string, double> ShowListOfSelection() 
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Burger)}");
        table.AddColumn("Prices");
        foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
        {
            number++;
            table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
        }
        AnsiConsole.Write(table);
        Console.WriteLine($"Select the type of {nameof(Burger)}.");
        return this.TypeOfProduct;
    }
}

