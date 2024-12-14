using System;

namespace OrderMenuApp.Models;

public class OrderDish
{
    public static List<double> AddingPriceToList = new();

    // Adds the Dictionary Values into a List and then adds each value of the List
    public static List<double> AddPrice(int userChoice, Dictionary<string, double> aDict)
    {
        AddingPriceToList.Add(aDict.Values.ElementAt(userChoice - 1));
        double price = 0;
        foreach(double pr in AddingPriceToList)
        {
             price += pr;
        }
        return AddingPriceToList;
    }
}
