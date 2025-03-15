using UnityEngine;

public class Scr_Item_CollectableItem : MonoBehaviour, Scr_Interface_PlayerInteractions
{
    [SerializeField] private Scr_SO_Item _item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pressione E para coletar " + _item.ItemName);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Saiu da área de coleta");
        }
    }

    public void Interact()
    {
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
