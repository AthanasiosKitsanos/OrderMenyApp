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

    public override Dictionary<string, double> ShowListOfSelection(int index)
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Burger)}");
        table.AddColumn("Prices");
        switch (index)
        {
            case 1:
                foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
                {
                    number++;
                    if (kvp.Key == "Humburger")
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
                    if (kvp.Key == "Cheeseburger")
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
                    if (kvp.Key == "Bacon Dream")
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
                    if (kvp.Key == "Smokey BBQ")
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
                    if (kvp.Key == "Chicken Avocado")
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