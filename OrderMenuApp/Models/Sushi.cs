using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Sushi : ProductOrder
{
    public Sushi()
    {
        TypeOfProduct = new Dictionary<string, double>
        {
            {"Ocean Roll", 6.9},
            {"Dragon Roll", 6.9},
            {"Salamon Nigiri", 5.9},
            {"Eel Nigiri", 6.9},
            {"Seabass Sashimi", 6.9}
        };
    }

    public override Dictionary<string, double> ShowListOfSelection()
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Sushi)}");
        table.AddColumn("Prices");
        foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
        {
            number++;
            table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
        }
        AnsiConsole.Write(table);
        Console.WriteLine($"Select the type of {nameof(Sushi)}.");
        return this.TypeOfProduct;
    }
}

