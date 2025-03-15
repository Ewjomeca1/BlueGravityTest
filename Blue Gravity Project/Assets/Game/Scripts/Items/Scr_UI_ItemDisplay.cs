using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scr_UI_ItemDisplay : MonoBehaviour, Scr_Interface_SelectionListener, Scr_Interface_ItemSoldObserver
{
    [SerializeField] private GameObject _itemDisplayUI;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemDescription;
    [SerializeField] private Scr_Inventory_ItemDragrabble _currentItem;
    
    [SerializeField] private Scr_Item_PerformAction _itemSeller;
    
    private void OnEnable()
    {
        Scr_Manager_ItemSelectionNotifier.AddObserver(this);
    }

    private void OnDisable()
    {
        Scr_Manager_ItemSelectionNotifier.RemoveObserver(this);
    }
    
    public void OnItemSelected(Scr_Inventory_ItemDragrabble item)
    {
        _currentItem = item;
        DisplayItem(item.Item);

        SetItemSeller(_itemSeller);
        _itemSeller.SetSelectedItem(_currentItem);
    }
    
    private void DisplayItem(Scr_SO_Item item)
    {
        if(item == null) return;
        
        _itemDisplayUI.SetActive(true);

        _itemIcon.sprite = item.ItemSprite;
        _itemDescription.text = item.ItemDescription;
    }

    public void HideItemDisplay()
    {
        _itemDisplayUI.SetActive(false);
    }

    public void SetItemSeller(Scr_Item_PerformAction itemSeller)
    {
        _itemSeller = itemSeller;
    }
    public void OnItemSold(Scr_Inventory_ItemDragrabble item)
    {
        Debug.Log("Item was selled");
    }
}
