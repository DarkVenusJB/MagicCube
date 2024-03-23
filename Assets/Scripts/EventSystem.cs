using System;

public class EventSystem
{
    public static event Action WinEvent;
    public static event Action BlockMoveEvent;
    public static event Action LevelRestartedEvent;

    public static void OnWin()
    {
        WinEvent?.Invoke();
    }

    public static void OnBlockMove()
    {
        BlockMoveEvent?.Invoke();
    }

    public static void OnLevelRestarted()
    {
        LevelRestartedEvent?.Invoke();
    }
}
