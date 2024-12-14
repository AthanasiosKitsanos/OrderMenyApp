using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Burger : ProductOrder
{
    public override void AddToDict()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    TypeOfProduct.Add("Humburger", 4.8);
                    break;
                case 1:
                    TypeOfProduct.Add("Cheeseburger", 5.6);
                    break;
                case 2:
                    TypeOfProduct.Add("Bacon Dream", 6.4);
                    break;
                case 3:
                    TypeOfProduct.Add("Smokey BBQ", 6.4);
                    break;
                case 4:
                    TypeOfProduct.Add("Chicken Avocado", 7.5);
                    break;
            }
        }
    }

    public override Dictionary<string, double> ShowListOfSelection()
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Burger)}");
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

