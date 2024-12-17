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

    public override Dictionary<string, double> ShowListOfSelection(int index)
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Salad)}");
        table.AddColumn("Prices");
        switch (index)
        {
            case 1:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {
                    number++;
                    if (kvp.Key == "Asian")
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
                    if (kvp.Key == "American")
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
                    if (kvp.Key == "Chicken Ceasar's")
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
                    if (kvp.Key == "Vegetable Cobb")
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
                    if (kvp.Key == "Chef")
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
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
        return this.TypeOfProduct;
    }
}