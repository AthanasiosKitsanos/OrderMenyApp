using System;
using System.Globalization;

namespace OrderMenuApp;

partial class MainProgram
{
    private static void ConfigureConsole(string culture = "en-US")
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
    }
}

