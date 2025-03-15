using UnityEngine;

public class Scr_Item_CollectableItem : MonoBehaviour
{
    [SerializeField] private Scr_SO_Item _item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Try add item in the inventory
            bool wasAdded = Scr_Inventory_BaseInventory.Instance.AddItem(_item);

            if (wasAdded)
            {
                Debug.Log(_item.ItemName + "coletado");
                Scr_Manager_GameManager.Instance.SavePlayer();
                Destroy(gameObject); // Destroy item
            }
            else
            {
                Debug.Log("Inventory is Full");
            }
        }
    }
}
