using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Item_PerformAction : MonoBehaviour, Scr_Interface_ItemSeller
{
    [SerializeField] private Scr_Inventory_BaseInventory _inventory;
    [SerializeField] private int _sellPrice;

    private Scr_Inventory_ItemDragrabble _currentItem;

    public void SetSelectedItem(Scr_Inventory_ItemDragrabble item)
    {
        _currentItem = item;
    }

    public void SellSelectedItem()
    {
        if (_currentItem == null || _currentItem.Item == null) return; // No item was selected to sell
        
        Scr_Manager_GameManager.Instance.AddPlayerMoney(_currentItem.Item.ItemValue); //Could use a observer pattern here 
        
        _inventory.RemoveItem(_currentItem.Item);

        NotifyItemSold(_currentItem);

        _currentItem = null;
        
        Scr_Manager_GameManager.Instance.SavePlayer();
    }
    public void DiscartSelectedItem()
    {
        if (_currentItem == null || _currentItem.Item == null) return; // No item was selected to sell
        
        _inventory.RemoveItem(_currentItem.Item);
        
        _currentItem = null;
        
        Scr_Manager_GameManager.Instance.SavePlayer();
    }

    public void HealPlayerSelectedItem()
    {
        if (_currentItem == null || _currentItem.Item == null) return;

        if (_currentItem.Item.IsHealabble)
        {
            Scr_Manager_GameManager.Instance.AddPlayerHealth(_currentItem.Item.ItemHealthValue);
            
            _inventory.RemoveItem(_currentItem.Item);
        
            _currentItem = null;
            
            Scr_Manager_GameManager.Instance.SavePlayer();
        }
    }
    private void NotifyItemSold(Scr_Inventory_ItemDragrabble item)
    {
        var observers = GetComponents<Scr_Interface_ItemSoldObserver>();
        
        foreach (Scr_Interface_ItemSoldObserver observer in observers)
        {
            observer.OnItemSold(item);
        }
    }
}
