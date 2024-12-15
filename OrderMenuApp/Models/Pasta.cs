using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Pasta : ProductOrder
{
    public Pasta()
    {
        TypeOfProduct = new Dictionary<string, double>
        {
            {"Linguine Tartufata", 9.5},
            {"Linguine Carbonara", 6.7},
            {"Linguine Arrabbiata", 8.4},
            {"Linguine Al Pesto", 8.5},
            {"Linguine Con Pollo a la Creme", 7.8}
        };
    }
 
    public override Dictionary<string, double> ShowListOfSelection()
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Pasta)}");
        table.AddColumn("Prices");
        foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
        {
            number++;
            table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
        }
        AnsiConsole.Write(table);
        Console.WriteLine($"Select the type of {nameof(Pasta)}.");
        return this.TypeOfProduct;
    }
}

