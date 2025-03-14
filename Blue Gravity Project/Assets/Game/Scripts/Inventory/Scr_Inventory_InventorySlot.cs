using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scr_Inventory_InventorySlot : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    //This script is the Item inside the UI
    
    [SerializeField] private Scr_SO_Item _item;
    
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _itemStack;
    
    [SerializeField] private Button _deleteItemButton;
    [SerializeField] private Button _itemButton;

    private void Start()
    {
        _itemStack.text = _item.MaxStack.ToString();
        _image.sprite = _item.ItemSprite;
    }

    public void AddItem(Scr_SO_Item item)
    {
        
    }

    public void ClearSlot()
    {
        _item = null;
        Destroy(gameObject);
    }

    public void ActivateDeleteItem()
    {
        bool isDeleteButtonActive = !_deleteItemButton.gameObject.activeSelf; // Invert current state
        _deleteItemButton.gameObject.SetActive(isDeleteButtonActive);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
