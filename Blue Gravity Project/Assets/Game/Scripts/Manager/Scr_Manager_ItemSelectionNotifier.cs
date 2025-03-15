using System.Collections.Generic;

public static class Scr_Manager_ItemSelectionNotifier
{
    private static List<Scr_Interface_SelectionListener> _observers = new List<Scr_Interface_SelectionListener>();

    public static void AddObserver(Scr_Interface_SelectionListener observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public static void RemoveObserver(Scr_Interface_SelectionListener observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }

    public static void NotifyItemSelected(Scr_Inventory_ItemDragrabble item)
    {
        foreach (var observer in _observers)
        {
            observer.OnItemSelected(item);
        }
    }
}
