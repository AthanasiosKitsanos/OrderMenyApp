using System;
using System.Collections.Generic;

namespace OrderMenuApp.Models;

public class OrderDish
{
    public static Dictionary<string, double> DetailedDictionary = new(); // Remember to change the name

    public static List<double> PriceList = new();

    //Adds the Dictionary Values into a List and then adds each value of the List
    public static List<double> AddPriceToList(int index, Dictionary<string, double> someDict)
    { 
        PriceList.Add(someDict.Values.ElementAt(index-1));
        return PriceList;
    }

    // This method takes the user's choice and adds it as a key in the dictionary, but if the key exists, it replaces it and updates the value.
    public static Dictionary<string, double> BuildReceipt(int num, Dictionary<string, double> someDict, Dictionary<string, double> newDict) 
    {
        DetailedDictionary = someDict;
        string dishName = DetailedDictionary.Keys.ElementAt(num-1);
        double dishPrice = DetailedDictionary.Values.ElementAt(num-1);
        
        string? existingKey = newDict.Keys.FirstOrDefault(key => key == dishName || key.EndsWith($"x {dishName}"));

        if (existingKey is not null)
        {
            int count = 1;
            if (existingKey.Contains("x"))
            {
                count = int.Parse(existingKey.Split('x')[0]);
            }

            count++;
            string newKey = $"{count}x {dishName}";

            newDict.Remove(existingKey);
            newDict[newKey] = count * dishPrice;
        }
        else
        {
            newDict[dishName] = dishPrice;
        }
        return newDict;
    }
}
