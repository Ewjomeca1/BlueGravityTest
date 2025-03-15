using System.Collections.Generic;
using UnityEngine;

public class Scr_UI_InventoryUI : MonoBehaviour, Scr_Interface_InventoryObserver
{
    [SerializeField] private Transform _itemParent;
    [SerializeField] private GameObject _inventoryUI;

    [SerializeField] private Scr_Inventory_BaseInventory _inventory;
    [SerializeField] private GameObject _slotPrefab;

    [SerializeField] private List<Scr_Inventory_InventorySlot> _inventorySlots;

    private void Start()
    {
        _inventory = Scr_Inventory_BaseInventory.Instance;

        _inventory.AddObserver(this);

        UpdateUI();
    }

    public void OnInventoryChanged(Scr_Inventory_BaseInventory inventory)
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < _inventorySlots.Count; i++)
        {
            Transform slotTransform = _inventorySlots[i].transform;

            foreach (Transform child in slotTransform)
            {
                Destroy(child.gameObject);
            }
        }

        foreach (var item in _inventory.Items)
        {
            AddItemToFirstEmptySlot(item);
        }
    }

    private void AddItemToFirstEmptySlot(Scr_SO_Item item)
    {
        foreach (var slot in _inventorySlots)
        {
            if (slot.transform.childCount == 0)
            {
                GameObject itemObject = Instantiate(_slotPrefab, slot.transform);
                
                Scr_Inventory_ItemDragrabble draggableItem = itemObject.GetComponent<Scr_Inventory_ItemDragrabble>();
                
                //Configure and Initialize item
                draggableItem.Item = item;
                draggableItem.InitializeItem();
                
                break; // Get out of the loop after add the item in the empty slot
            }
        }
    }
}
