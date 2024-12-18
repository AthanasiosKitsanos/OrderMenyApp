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
        NavigationInfo();

        await Task.Run(() => ListeningForKey());
    }
}

