using System;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Inventory_BaseInventory : MonoBehaviour // This Script goes to the player prefab
{
    [SerializeField] private List<Scr_SO_Item> _items = new List<Scr_SO_Item>();
    [SerializeField] private int _maxSlots = 10;
    
    private static Scr_Inventory_BaseInventory _instance;

    private List<Scr_Interface_InventoryObserver> _observers = new List<Scr_Interface_InventoryObserver>();

    public List<Scr_SO_Item> Items
    {
        get { return _items; }
    }

    public static Scr_Inventory_BaseInventory Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddObserver(Scr_Interface_InventoryObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(Scr_Interface_InventoryObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (Scr_Interface_InventoryObserver observer in _observers)
        {
            observer.OnInventoryChanged(this);
        }
    }

    public bool AddItem(Scr_SO_Item item)
    {
        if (_items.Count < _maxSlots)
        {
            _items.Add(item);
            NotifyObservers(); // Notify Observers
            return true;
        }

        return false; // Inventory Full
    }

    public void RemoveItem(Scr_SO_Item item)
    {
        _items.Remove(item);
        NotifyObservers();
    }
}
