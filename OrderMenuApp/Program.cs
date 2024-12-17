using System;
using System.Runtime.CompilerServices;
using OrderMenuApp.Models;
using OrderMenuApp.Events;
using Spectre.Console;
using Spectre.Console.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderMenuApp;


partial class MainProgram
{ 
    static async Task Main(string[] args)
    {
        ConfigureConsole();
        CreatePizzaTable(table);

        HandlerOfEvents.KeyPress += (sender, keyInfo) =>
        {
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                NavigateToNextTable();
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                NavigateToPreviousTable();   
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                DisplayTypeOfDishTable(currentTableIndex, currentItemIndex);
                lastExcecution = true;
            }
            else if(keyInfo.Key == ConsoleKey.Escape)
            {
                CreateTableByIndex(currentTableIndex);
                lastExcecution = false;
            }
            else if(keyInfo.Key == ConsoleKey.Q)
            {
                Console.Clear();
                FinalReceipt(ListOfOrderedDishes);
                Environment.Exit(0);
            }
        };

        await Task.Run(() => ListeningForKey());
    }
}

