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
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            MainProgram.NavigateToPreviousTable();
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            MainProgram.DisplayTypeOfDishTable(MainProgram.currentTableIndex, MainProgram.currentItemIndex);
            MainProgram.lastExcecution = true;
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
    public static void HandleKeyPress(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            MainProgram.NavTypeOfDishNext();
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            MainProgram.NavTypeOfDishPrevious();
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            //DisplayTypeOfDishTable(currentTableIndex, currentItemIndex);
        }
        else if (keyInfo.Key == ConsoleKey.Escape)
        {
            MainProgram.currentItemIndex = 1;
            Console.Clear();
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
}


