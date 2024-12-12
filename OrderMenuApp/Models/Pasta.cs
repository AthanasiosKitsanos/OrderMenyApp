using System;

namespace OrderMenuApp.Models;

public class Pasta : ProductOrder
{
    public override void ShowListOfSelection()
    {
        foreach (KeyValuePair<string, double> kvp in this.TypeOfProduct)
        {
            Console.WriteLine($"1. {kvp.Key} {kvp.Value:C}");
        }
    }
}

