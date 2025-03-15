using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Scr_Inventory_InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Scr_SO_Item _item;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) // Treatment to not have more than one object within the grid
        {
            GameObject dropped = eventData.pointerDrag;
            Scr_Inventory_ItemDragrabble draggableItem = dropped.GetComponent<Scr_Inventory_ItemDragrabble>();
            
            GetItemInformation(draggableItem.Item);
            
            draggableItem.ParentAfterDrag = transform;
        }
    }

    private void GetItemInformation(Scr_SO_Item item)
    {
        _item = item;
    }
}
