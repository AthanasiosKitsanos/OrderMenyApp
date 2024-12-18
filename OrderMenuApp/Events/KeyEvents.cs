using OrderMenuApp.Models;
using System;
using System.Threading.Tasks;

namespace OrderMenuApp.Events;
// A Class with methods to that navigate depending on the key the user presses.
public class KeyEvents
{
    public static void OnKeyPressedOnMenu(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            MainProgram.NavigateToNextTable();
            if (MainProgram.BuildReceiptCheck())
            {
                MainProgram.RunningOrder(MainProgram.ListOfOrderedDishes);
            }
            MainProgram.NavigationInfo();
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            MainProgram.NavigateToPreviousTable();
            if (MainProgram.BuildReceiptCheck())
            {
                MainProgram.DictionaryInfo(MainProgram.ListOfOrderedDishes);
            }
            MainProgram.NavigationInfo();
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            MainProgram.DisplayTypeOfDishTable(MainProgram.currentTableIndex, MainProgram.currentItemIndex);
            MainProgram.lastExcecution = true;
            if (MainProgram.BuildReceiptCheck())
            {
                MainProgram.RunningOrder(MainProgram.ListOfOrderedDishes);
            }
            MainProgram.NavigationInfo();
        }
        else if (keyInfo.Key == ConsoleKey.Escape)
        {
            MainProgram.CreateTableByIndex(MainProgram.currentTableIndex);
            MainProgram.lastExcecution = false;
        }
        else if (keyInfo.Key == ConsoleKey.Q)
        {
            Console.Clear();
            MainProgram.FinalReceipt(MainProgram.ListOfOrderedDishes);
            Environment.Exit(0);
        }
    }
    public static void OnKeyPressedOnList(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            MainProgram.NavTypeOfDishNext();
            if (MainProgram.BuildReceiptCheck())
            {
                MainProgram.RunningOrder(MainProgram.ListOfOrderedDishes);
            }
            MainProgram.NavigationInfo();
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            MainProgram.NavTypeOfDishPrevious();
            if (MainProgram.BuildReceiptCheck())
            {
                MainProgram.RunningOrder(MainProgram.ListOfOrderedDishes);
            }
            MainProgram.NavigationInfo();
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            MainProgram.DisplayTypeOfDishTable(MainProgram.currentTableIndex, MainProgram.currentItemIndex);
            OrderDish.BuildReceipt(MainProgram.currentItemIndex, MainProgram.orderTypeDictionary, MainProgram.ListOfOrderedDishes);
            OrderDish.AddPriceToList(MainProgram.currentItemIndex, MainProgram.orderTypeDictionary);
            MainProgram.RunningOrder(MainProgram.ListOfOrderedDishes);
            MainProgram.NavigationInfo();
        }
        else if (keyInfo.Key == ConsoleKey.Escape)
        {
            MainProgram.currentItemIndex = 1;
            Console.Clear();
            MainProgram.CreateTableByIndex(MainProgram.currentTableIndex);
            MainProgram.lastExcecution = false;
            if (MainProgram.BuildReceiptCheck())
            {
                MainProgram.RunningOrder(MainProgram.ListOfOrderedDishes);
            }
            MainProgram.NavigationInfo();
        }
        else if (keyInfo.Key == ConsoleKey.Q)
        {
            Console.Clear();
            MainProgram.FinalReceipt(MainProgram.ListOfOrderedDishes);
            Environment.Exit(0);
        }
    }
}


