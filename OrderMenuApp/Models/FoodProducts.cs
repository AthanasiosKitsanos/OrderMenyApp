using System;

namespace OrderMenuApp.Models;

public abstract class FoodProducts
{
    public string? Name { get; set; }
    public double Price { get; set; }
    public int PlateQuantity { get; set; }
}

