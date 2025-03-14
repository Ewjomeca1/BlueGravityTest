using UnityEngine;

public class Scr_UI_InventoryUI : MonoBehaviour, Scr_Interface_InventoryObserver
{
    [SerializeField] private Transform _itemParent;
    [SerializeField] private GameObject _inventoryUI;

    [SerializeField] private Scr_Inventory_BaseInventory _inventory;
    [SerializeField] private Scr_Inventory_InventorySlot[] _slots;

    private void Start()
    {
        _inventory = Scr_Inventory_BaseInventory.Instance;
        _slots = _itemParent.GetComponentsInChildren<Scr_Inventory_InventorySlot>();

        _inventory.AddObserver(this);

        UpdateUI();
    }

    public void OnInventoryChanged(Scr_Inventory_BaseInventory inventory)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < _inventory.Items.Count)
            {
                _slots[i].AddItem(_inventory.Items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
