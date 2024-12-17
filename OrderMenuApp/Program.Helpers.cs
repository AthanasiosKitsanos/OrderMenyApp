using OrderMenuApp.Events;
using OrderMenuApp.Models;
using Spectre.Console;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OrderMenuApp;

partial class MainProgram
{
    private static int currentItemIndex = 1;
    private static int currentTableIndex = 1;
    private static bool lastExcecution = false;

    private static Table table = new();
    private static Pizza pizza = new();
    private static Burger burger = new();
    private static Pasta pasta = new();
    private static Salad salad = new();
    private static Sushi sushi = new();
    private static Dictionary<string, double> orderTypeDictionary = new();
    private static Dictionary<string, double> ListOfOrderedDishes = new();
    private static void CreatePizzaTable(Table table)
    {
        table = new();
        Console.Clear();
        table.AddColumn(new TableColumn("[Yellow]List Menu[/]"));
        table.AddRow($"[underline]1. {nameof(Pizza)}[/]");
        table.AddRow($"2. {nameof(Burger)}");
        table.AddRow($"3. {nameof(Pasta)}");
        table.AddRow($"4. {nameof(Salad)}");
        table.AddRow($"5. {nameof(Sushi)}");
        AnsiConsole.Write(table);
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
    }
    private static void CreateBurgerTable(Table table)
    {
        table = new();
        Console.Clear();
        table.AddColumn(new TableColumn("[Yellow]List Menu[/]"));
        table.AddRow($"1. {nameof(Pizza)}");
        table.AddRow($"[underline]2. {nameof(Burger)}[/]");
        table.AddRow($"3. {nameof(Pasta)}");
        table.AddRow($"4. {nameof(Salad)}");
        table.AddRow($"5. {nameof(Sushi)}");
        AnsiConsole.Write(table);
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
    }
    private static void CreatePastaTable(Table table)
    {
        table = new();
        Console.Clear();
        table.AddColumn(new TableColumn("[Yellow]List Menu[/]"));
        table.AddRow($"1. {nameof(Pizza)}");
        table.AddRow($"2. {nameof(Burger)}");
        table.AddRow($"[underline]3. {nameof(Pasta)}[/]");
        table.AddRow($"4. {nameof(Salad)}");
        table.AddRow($"5. {nameof(Sushi)}");
        AnsiConsole.Write(table);
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
    }
    private static void CreateSaladTable(Table table)
    {
        table = new();
        Console.Clear();
        table.AddColumn(new TableColumn("[Yellow]List Menu[/]"));
        table.AddRow($"1. {nameof(Pizza)}");
        table.AddRow($"2. {nameof(Burger)}");
        table.AddRow($"3. {nameof(Pasta)}");
        table.AddRow($"[underline]4. {nameof(Salad)}[/]");
        table.AddRow($"5. {nameof(Sushi)}");
        AnsiConsole.Write(table);
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
    }
    private static void CreateSushiTable(Table table)
    {
        table = new();
        Console.Clear();
        table.AddColumn(new TableColumn("[Yellow]List Menu[/]"));
        table.AddRow($"1. {nameof(Pizza)}");
        table.AddRow($"2. {nameof(Burger)}");
        table.AddRow($"3. {nameof(Pasta)}");
        table.AddRow($"4. {nameof(Salad)}");
        table.AddRow($"[underline]5. {nameof(Sushi)}[/]");
        AnsiConsole.Write(table);
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
    }

    private static void DictionaryInfo(Dictionary<string, double> dictionary)
    {
        foreach(KeyValuePair<string, double> kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key}:  ${kvp.Value:F2}\n");
        }
    }

    private static void FinalReceipt(Dictionary<string, double> someDict)
    {
        DateTime dateTime = DateTime.Now;
        Console.WriteLine("Receipt:");
        DictionaryInfo(someDict);
        Console.WriteLine($"Total Amount: {OrderDish.PriceList.Sum():C}");
        Console.WriteLine($"{dateTime:HH:mm:ss dd/MM/yyyy}");
    }

    public static void CreateTableByIndex(int tableindex)
    {
        switch (tableindex)
        {
            case 1:
                CreatePizzaTable(table);
                break;
            case 2:
                CreateBurgerTable(table);
                break;
            case 3:
                CreatePastaTable(table);
                break;
            case 4:
                CreateSaladTable(table);
                break;
            case 5:
                CreateSushiTable(table);
                break;
        }
    }

    private static void NavigateToNextTable()
    {
        if(currentTableIndex < 5)
        {
            currentTableIndex++;
            CreateTableByIndex(currentTableIndex);
        }
        else if(currentTableIndex == 5)
        {
            currentTableIndex = 1;
            CreateTableByIndex(currentTableIndex);
        }
    }

    private static void NavigateToPreviousTable()
    {
        if(currentTableIndex > 1)
        {
            currentTableIndex--;
            CreateTableByIndex(currentTableIndex);
        }
        else if(currentTableIndex == 1)
        {
            currentTableIndex = 5;
            CreateTableByIndex(currentTableIndex);
        }
    }
    private static void DisplayTypeOfDishTable()
    {
        Console.Clear();
        switch(currentTableIndex)
        {
            case 1:
                pizza.ShowListOfSelection(currentItemIndex);
                break;
            case 2:
                burger.ShowListOfSelection(currentItemIndex);
                break;
            case 3:
                pasta.ShowListOfSelection(currentItemIndex);
                break;
            case 4:
                salad.ShowListOfSelection(currentItemIndex);
                break;
            case 5:
                sushi.ShowListOfSelection(currentItemIndex);
                break;
        };
    }

    private static void NavTypeOfDishNext()
    {
        if (currentItemIndex < 5)
        {
            currentItemIndex++;
            DisplayTypeOfDishTable();
        }
        else if (currentItemIndex == 5)
        {
            currentItemIndex = 1;
            DisplayTypeOfDishTable();
        }
    }

    private static void NavTypeOfDishPrevious()
    {
        if (currentItemIndex > 1)
        {
            currentItemIndex--;
            DisplayTypeOfDishTable();
        }
        else if (currentItemIndex == 1)
        {
            currentItemIndex = 5;
            DisplayTypeOfDishTable();
        }
    }

    private static void HandleKeyPress(ConsoleKeyInfo keyInfo, Dictionary<string, double> currentMenu)
    {
        if(keyInfo.Key == ConsoleKey.DownArrow)
        {
            NavTypeOfDishNext();
        }
        else if(keyInfo.Key == ConsoleKey.UpArrow)
        {
            NavTypeOfDishPrevious();
        }
        else if(keyInfo.Key == ConsoleKey.Enter)
        {
            
        }
        else if(keyInfo.Key == ConsoleKey.Escape)
        {
            currentItemIndex = 1;
            Console.Clear();
            CreateTableByIndex(currentTableIndex);
            lastExcecution = false;
        }
        else if(keyInfo.Key == ConsoleKey.Q)
        {
            Console.Clear();
            FinalReceipt(ListOfOrderedDishes);
            Environment.Exit(0);
        }

    }


    public static async Task ListeningForKey()
    {
        while (true)
        {
            var key = await Task.Run(() => Console.ReadKey(true));
            if (!lastExcecution)
            {
                HandlerOfEvents.OnKeyPressedOnMenu(key);
            }
            else
            {
                HandleKeyPress(key, orderTypeDictionary);
            }
        };
    }
}

