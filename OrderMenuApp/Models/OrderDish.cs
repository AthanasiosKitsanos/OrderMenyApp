using System;

namespace OrderMenuApp.Models;

public class OrderDish
{
    public static Dictionary<string, double> DetailedDictionary = new();

    public static List<double> PriceList = new(); 

    //Adds the Dictionary Values into a List and then adds each value of the List
    public static List<double> AddPriceToList(ConsoleKeyInfo userChoice, Dictionary<string, double> aDict)
    {
        PriceList.Add(aDict.Values.ElementAt((int)userChoice.Key - 1));
        return PriceList;
    }

    // This method takes the user's choice and adds it as a key in the dictionary, but if the key exists, it replaces it and updates the value.
    public static Dictionary<string, double> BuildReceipt(int num, Dictionary<string, double> aDict) 
    {
        string dishName = aDict.Keys.ElementAt(num);
        double dishPrice = aDict.Values.ElementAt(num);

        string? existingKey = DetailedDictionary.Keys.FirstOrDefault(key => key == dishName || key.EndsWith($"x {dishName}"));

        if (existingKey is not null)
        {
            int count = 1;
            if (existingKey.Contains("x"))
            {
                count = int.Parse(existingKey.Split('x')[0]);
            }

            count++;
            string newKey = $"{count}x {dishName}";

            DetailedDictionary.Remove(existingKey);
            DetailedDictionary[newKey] = count * dishPrice;
        }
        else
        {
            DetailedDictionary[dishName] = dishPrice;
        }
        return DetailedDictionary;
    }
}
