using UnityEngine;
using UnityEngine.EventSystems;

public class Scr_Inventory_InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) // Treatment to not have more than one object within the grid
        {
            GameObject dropped = eventData.pointerDrag;
            Scr_Inventory_ItemDragrabble draggableItem = dropped.GetComponent<Scr_Inventory_ItemDragrabble>();

            draggableItem.ParentAfterDrag = transform;
        }
    }
}
