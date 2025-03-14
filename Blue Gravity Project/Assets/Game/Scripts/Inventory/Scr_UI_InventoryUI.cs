using UnityEngine;

public class Scr_UI_InventoryUI : MonoBehaviour, Scr_Interface_InventoryObserver
{
    [SerializeField] private Transform _itemParent;
    [SerializeField] private GameObject _inventoryUI;

    [SerializeField] private Scr_Inventory_BaseInventory _inventory;
    [SerializeField] private GameObject _slotPrefab;

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
        foreach (Transform child in _itemParent) //Destroy all slots
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < _inventory.Items.Count; i++)
        {
            GameObject slot = Instantiate(_slotPrefab, _itemParent);

            Scr_Inventory_InventorySlot inventorySlot = slot.GetComponent<Scr_Inventory_InventorySlot>();

            if (inventorySlot != null)
            {
                inventorySlot.AddItem(_inventory.Items[i]);
            }
        }
    }
}
