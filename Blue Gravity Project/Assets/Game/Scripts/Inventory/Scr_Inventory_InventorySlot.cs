using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scr_Inventory_InventorySlot : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    //This script is the Item inside the UI
    
    [SerializeField] private Image _image;
    [SerializeField] private Scr_SO_Item _item;


    public void AddItem(Scr_SO_Item item)
    {
        
    }

    public void ClearSlot()
    {
        
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
