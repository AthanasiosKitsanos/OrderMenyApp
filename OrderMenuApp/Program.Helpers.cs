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
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
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
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
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
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
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
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
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
        Console.WriteLine("Navigate up and down with arrows. Press ENTER to select or Esc to go back or Q to stop ordering.");
    }

    public static void DictionaryInfo(Dictionary<string, double> dictionary)
    {
        foreach(KeyValuePair<string, double> kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key}:  ${kvp.Value:F2}\n");
        }
    }

    public static void FinalReceipt(Dictionary<string, double> someDict)
    {
        DateTime dateTime = DateTime.Now;
        Console.WriteLine("Receipt:");
        DictionaryInfo(someDict);
        Console.WriteLine($"Total Amount: {OrderDish.PriceList.Sum():C}");
        Console.WriteLine($"{dateTime:HH:mm:ss dd/MM/yyyy}");
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

    public static void DisplayTypeOfDishTable(int tableindex, int itemindex) // Method that displays what each Class contains
    {
        Console.Clear();
        switch(tableindex)
        {
            case 1:
                pizza.ShowListOfSelection(itemindex);
                break;
            case 2:
                burger.ShowListOfSelection(itemindex);
                break;
            case 3:
                pasta.ShowListOfSelection(itemindex);
                break;
            case 4:
                salad.ShowListOfSelection(itemindex);
                break;
            case 5:
                sushi.ShowListOfSelection(itemindex);
                break;
        };
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
                KeyEvents.HandleKeyPress(key);
            }
        };
    }
}

