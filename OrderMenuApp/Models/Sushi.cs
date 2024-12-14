using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Sushi : ProductOrder
{
    public override void AddToDict()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    TypeOfProduct.Add("Ocean Roll", 6.9);
                    break;
                case 1:
                    TypeOfProduct.Add("Dragon Roll", 6.9);
                    break;
                case 2:
                    TypeOfProduct.Add("Salamon Nigiri", 5.9);
                    break;
                case 3:
                    TypeOfProduct.Add("Eel Nigiri", 6.9);
                    break;
                case 4:
                    TypeOfProduct.Add("Seabass Sashimi", 6.9); 
                    break;
            }
        }
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

