using System;

namespace OrderMenuApp.Models;

public class OrderDish
{
    public static List<double> AddingPriceToList = new();
    public static List<double> AddPrice(double dictValue)
    {
        AddingPriceToList.Add(dictValue);
        double price = 0;
        foreach(double pr in AddingPriceToList)
        {
            price += pr;
        }
        return AddingPriceToList;
    }
}
