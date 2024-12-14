using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Pasta : ProductOrder
{
    public override void AddToDict()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    TypeOfProduct.Add("Linguine Tartufata", 9.5);
                    break;
                case 1:
                    TypeOfProduct.Add("Linguine Carbonara", 6.7);
                    break;
                case 2:
                    TypeOfProduct.Add("Linguine Arrabbiata", 8.4);
                    break;
                case 3:
                    TypeOfProduct.Add("Linguine Al Pesto", 8.5);
                    break;
                case 4:
                    TypeOfProduct.Add("Linguine Con Pollo a la Creme", 7.8);
                    break;
            }
        }
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
        return this.TypeOfProduct;
    }
}

