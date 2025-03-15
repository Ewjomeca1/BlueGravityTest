using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scr_Inventory_ItemDragrabble : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    //This script is the Item inside the UI
    
    [SerializeField] private Scr_SO_Item _item;
    
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _itemStack;
    
    [SerializeField] private Button _itemButton;

    private Transform _parentAfterDrag;
    public Transform ParentAfterDrag
    {
        get
        {
            return _parentAfterDrag;
        }
        set
        {
            _parentAfterDrag = value;
        }
    }

    public Scr_SO_Item Item
    {
        get { return _item; }
        set { _item = value; }
    } 

    private void Start()
    {
        _itemStack.text = _item.MaxStack.ToString();
    }

    public void InitializeItem()
    {
        _image.sprite = _item.ItemSprite;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_parentAfterDrag);
        _image.raycastTarget = true;
    }
}
