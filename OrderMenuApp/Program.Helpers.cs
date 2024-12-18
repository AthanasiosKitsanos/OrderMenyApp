using OrderMenuApp.Events;
using OrderMenuApp.Models;
using Spectre.Console;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OrderMenuApp;

partial class MainProgram
{
    public static int currentItemIndex = 1;
    public static int currentTableIndex = 1;
    public static bool lastExcecution = false;

    public static Table table = new();
    public static Pizza pizza = new();
    public static Burger burger = new();
    public static Pasta pasta = new();
    public static Salad salad = new();
    public static Sushi sushi = new();
    public static Dictionary<string, double> orderTypeDictionary = new();
    public static Dictionary<string, double> ListOfOrderedDishes = new();

    // Creation of each Table of each Class
    public static void CreatePizzaTable(Table table)
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
    }
    public static void CreateBurgerTable(Table table)
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
    }
    public static void CreatePastaTable(Table table)
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
    }
    public static void CreateSaladTable(Table table)
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
    }
    public static void CreateSushiTable(Table table)
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
    }

    public static void DictionaryInfo(Dictionary<string, double> someDict)
    {
        foreach (KeyValuePair<string, double> kvp in someDict)
        {
            Console.WriteLine($"\n{kvp.Key}: ${kvp.Value:F2}");
        }
    }

    public static void FinalReceipt(Dictionary<string, double> someDict)
    {
        DateTime dateTime = DateTime.Now;
        Console.WriteLine("Receipt:");
        DictionaryInfo(someDict);
        Console.WriteLine($"\nTotal Amount: {OrderDish.PriceList.Sum():C}");
        Console.WriteLine($"{dateTime:HH:mm:ss dd/MM/yyyy}");
    }

    public static void RunningOrder(Dictionary<string, double> someDict)
    {
        Console.WriteLine("\n---Cart---");
        DictionaryInfo(someDict);
        Console.WriteLine($"\nTotal Amount: {OrderDish.PriceList.Sum():C}");
    }

    // Navigation methods to move between rows of the Table of Classes
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

    public static void NavigateToNextTable()
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

    public static void NavigateToPreviousTable()
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

    public static Dictionary<string, double>DisplayTypeOfDishTable(int tableindex, int itemindex) // Method that displays what each Class contains
    {
        Console.Clear();
        orderTypeDictionary = tableindex switch
        {
            1 => pizza.ShowListOfSelection(itemindex),
            2 => burger.ShowListOfSelection(itemindex),
            3 => pasta.ShowListOfSelection(itemindex),
            4 => salad.ShowListOfSelection(itemindex),
            5 => sushi.ShowListOfSelection(itemindex),
        };
        return orderTypeDictionary;
    }

    // Methods to navigate between each item, contained in a the Class
    public static void NavTypeOfDishNext()
    {
        if (currentItemIndex < 5)
        {
            currentItemIndex++;
            DisplayTypeOfDishTable(currentTableIndex, currentItemIndex);
        }
        else if (currentItemIndex == 5)
        {
            currentItemIndex = 1;
            DisplayTypeOfDishTable(currentTableIndex, currentItemIndex);
        }
    }

    public static void NavTypeOfDishPrevious()
    {
        if (currentItemIndex > 1)
        {
            currentItemIndex--;
            DisplayTypeOfDishTable(currentTableIndex, currentItemIndex);
        }
        else if (currentItemIndex == 1)
        {
            currentItemIndex = 5;
            DisplayTypeOfDishTable(currentTableIndex, currentItemIndex);
        }
    }

    public static Dictionary<string, double> AddToListOfOrderedDishes(Dictionary<string, double> someDict)
    {
        ListOfOrderedDishes = someDict;
        return ListOfOrderedDishes;
    }

    public static bool BuildReceiptCheck()
    {
        if(MainProgram.ListOfOrderedDishes.Count == 0)
        {
            return false;
        }
        return true;
    }

    public static void NavigationInfo()
    {
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
    }

    public static async Task ListeningForKey()
    {
        while (true)
        {
            var key = await Task.Run(() => Console.ReadKey(true));
            if (!lastExcecution)
            {
                KeyEvents.OnKeyPressedOnMenu(key);
            }
            else
            {
                KeyEvents.OnKeyPressedOnList(key);
            }
        };
    }
}

