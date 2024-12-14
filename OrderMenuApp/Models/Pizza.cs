using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public class Pizza : ProductOrder
{
    public override void AddToDict()
    {
        for(int i = 0; i < 5; i++)
        {
            switch(i)
            {
                case 0: TypeOfProduct.Add("Margarita", 7.4);
                    break;
                case 1: TypeOfProduct.Add("BBQ Chicken", 9.9);
                    break;
                case 2: TypeOfProduct.Add("Ceasar's", 9.9);
                    break;
                case 3: TypeOfProduct.Add("Mexicana", 9.3); 
                    break;
                case 4: TypeOfProduct.Add("Siciliana", 7.9);
                    break;
            }
        }
    }

    public override Dictionary<string, double> ShowListOfSelection()
    {
        Table table = new Table();
        int number = 0;
        table.AddColumn($"Type of {nameof(Pizza)}");
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

