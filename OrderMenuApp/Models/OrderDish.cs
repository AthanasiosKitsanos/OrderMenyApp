using System;

namespace OrderMenuApp.Models;

public class OrderDish
{
    public static List<double> AmountList = new();

    // Adds the Dictionary Values into a List and then adds each value of the List
    public static List<double> AddPriceToList(int userChoice, Dictionary<string, double> aDict)
    {
        AmountList.Add(aDict.Values.ElementAt(userChoice - 1));
        return AmountList;
    }
}
