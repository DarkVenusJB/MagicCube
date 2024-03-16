using UnityEngine;
using System;

public class EventSystem
{
    public static event Action WinEvent;

    public static void OnWin()
    {
        WinEvent?.Invoke();
    }
}
