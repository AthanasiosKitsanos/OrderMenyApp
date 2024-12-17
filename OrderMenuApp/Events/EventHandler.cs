using System;
using System.Threading.Tasks;

namespace OrderMenuApp.Events;

public static class HandlerOfEvents
{
    public static event EventHandler<ConsoleKeyInfo> KeyPress;

    public static void OnKeyPressedOnMenu(ConsoleKeyInfo keyinfo)
    {
        KeyPress?.Invoke(null, keyinfo);
    }
}

