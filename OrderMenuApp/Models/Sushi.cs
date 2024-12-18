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

    public override Dictionary<string, double> ShowListOfSelection(int index)
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"[Yellow]Type of {nameof(Sushi)}[/]");
        table.AddColumn("[Yellow]Prices[/]");
        switch (index)
        {
            case 1:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {
                    number++;
                    if (kvp.Key == "Ocean Roll")
                    {
                        table.AddRow($"[underline]{number}. {kvp.Key}[/]", $"{kvp.Value:C}");
                    }
                    else
                    {
                        table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
                    }
                }
                break;
            case 2:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {
                    number++;
                    if (kvp.Key == "Dragon Roll")
                    {
                        table.AddRow($"[underline]{number}. {kvp.Key}[/]", $"{kvp.Value:C}");
                    }
                    else
                    {
                        table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
                    }
                }
                break;
            case 3:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {
                    number++;
                    if (kvp.Key == "Salamon Nigiri")
                    {
                        table.AddRow($"[underline]{number}. {kvp.Key}[/]", $"{kvp.Value:C}");
                    }
                    else
                    {
                        table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
                    }
                }
                break;
            case 4:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {
                    number++;
                    if (kvp.Key == "Eel Nigiri")
                    {
                        table.AddRow($"[underline]{number}. {kvp.Key}[/]", $"{kvp.Value:C}");
                    }
                    else
                    {
                        table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
                    }
                }
                break;
            case 5:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {
                    number++;
                    if (kvp.Key == "Seabass Sashimi")
                    {
                        table.AddRow($"[underline]{number}. {kvp.Key}[/]", $"{kvp.Value:C}");
                    }
                    else
                    {
                        table.AddRow($"{number}. {kvp.Key}", $"{kvp.Value:C}");
                    }
                }
                break;
        }
        AnsiConsole.Write(table);
        Console.WriteLine($"Select the type of {nameof(Burger)}.");
        return this.TypeOfProduct;
    }
}