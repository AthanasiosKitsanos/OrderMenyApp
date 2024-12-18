using OrderMenuApp.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMenuApp.StreamingManaging;

public class FileCreate
{
    public static string CreateNewFolder()
    {
        string folderPath = @"C:\Users\PC\source\repos\Portofolio\MenuApplication\OrderMenuApp\Receipt Folder";
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        return folderPath;
    }
    public static void CreateNewFile()
    {
        Table table = new Table();
        string fileName = Combine(CreateNewFolder(), "Receipts.txt");
        if(!File.Exists(fileName))
        {
            using(StreamWriter fileWriter = File.CreateText(fileName))
            {

                Console.WriteLine("Receipt:");
                foreach (KeyValuePair<string, double> item in MainProgram.ListOfOrderedDishes)
                {
                    fileWriter.WriteLine($"\n{item.Key}: ${item.Value:F2}");
                }
                fileWriter.WriteLine($"\nTotal Amount: {OrderDish.PriceList.Sum():C}");
                fileWriter.WriteLine($"{MainProgram.dateTime:HH:mm:ss dd/MM/yyyy}");
            }
        }
        else
        {
            using (StreamWriter fileWriter = new StreamWriter(fileName, true))
            {
                fileWriter.WriteLine("\n\nReceipt:");
                foreach (KeyValuePair<string, double> item in MainProgram.ListOfOrderedDishes)
                {
                    fileWriter.WriteLine($"\n{item.Key}: ${item.Value:F2}");
                }
                fileWriter.WriteLine($"\nTotal Amount: {OrderDish.PriceList.Sum():C}");
                fileWriter.WriteLine($"{MainProgram.dateTime:HH:mm:ss dd/MM/yyyy}");
            }
        }
    }
}

