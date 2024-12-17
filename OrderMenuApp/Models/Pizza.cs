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

    public override Dictionary<string, double> ShowListOfSelection(int index)
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Pizza)}");
        table.AddColumn("Prices");
        switch(index)
        {
            case 1:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {      
                    number++;
                    if (kvp.Key == "Margarita")
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
                    if (kvp.Key == "BBQ Chicken")
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
                    if (kvp.Key == "Ceasar's")
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
                    if (kvp.Key == "Mexicana")
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
                    if (kvp.Key == "Siciliana")
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
        Console.WriteLine($"Select the type of {nameof(Pizza)}.");
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
        return this.TypeOfProduct;
    }
}

