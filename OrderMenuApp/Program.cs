using System;
using OrderMenuApp.Models;

namespace OrderMenuApp;


partial class MainProgram
{
    static void Main(string[] args)
    {
        ConfigureConsole();

        Pizza pizza = new();
        Burger burger = new();
        Pasta pasta = new();
        Salad salad = new();
        Sushi sushi = new();

        pizza.TypeOfProduct.Add("Margarita", 10.5);
        pizza.ShowListOfSelection();
        
    }
}