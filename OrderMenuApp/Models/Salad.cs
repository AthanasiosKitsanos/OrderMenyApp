using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Salad : ProductOrder
{
    public override void AddToDict()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    TypeOfProduct.Add("Asian", 7.5);
                    break;
                case 1:
                    TypeOfProduct.Add("American", 6.9);
                    break;
                case 2:
                    TypeOfProduct.Add("Chicken Ceasar's", 6.4);
                    break;
                case 3:
                    TypeOfProduct.Add("Vegetable Cobb", 7.5); 
                    break;
                case 4:
                    TypeOfProduct.Add("Chef", 6.1);
                    break;
            }
        }
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

