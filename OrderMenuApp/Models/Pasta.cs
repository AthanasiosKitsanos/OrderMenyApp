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

    public override Dictionary<string, double> ShowListOfSelection(int index)
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Pasta)}");
        table.AddColumn("Prices");
        switch (index)
        {
            case 1:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {
                    number++;
                    if (kvp.Key == "Linguine Tartufata")
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
                    if (kvp.Key == "Linguine Carbonara")
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
                    if (kvp.Key == "Linguine Arrabbiata")
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
                    if (kvp.Key == "Linguine Al Pesto")
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
                    if (kvp.Key == "Linguine Con Pollo a la Creme")
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