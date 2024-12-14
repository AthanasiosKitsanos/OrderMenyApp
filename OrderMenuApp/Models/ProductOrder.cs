using System;

namespace OrderMenuApp.Models;

public abstract class ProductOrder
{
    public Dictionary<string, double> TypeOfProduct = new();
    public int PlateQuantity { get; set; }
   
    public abstract Dictionary<string, double> ShowListOfSelection();
    public abstract void AddToDict();   
}

