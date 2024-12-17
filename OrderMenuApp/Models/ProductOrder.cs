using Spectre.Console;
using System;

namespace OrderMenuApp.Models;

public abstract class ProductOrder
{
    public Dictionary<string, double>? TypeOfProduct { get; set; }
    public int PlateQuantity { get; set; }
   
    public abstract Dictionary<string, double> ShowListOfSelection(int index);   
}

