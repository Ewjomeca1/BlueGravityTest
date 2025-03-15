using UnityEngine;

public class Scr_Item_CollectableItem : MonoBehaviour, Scr_Interface_PlayerInteractions
{
    [SerializeField] private Scr_SO_Item _item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Scr_Manager_GameManager.Instance.UIDisplay.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Scr_Manager_GameManager.Instance.UIDisplay.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        bool wasAdded = Scr_Inventory_BaseInventory.Instance.AddItem(_item);

        if (wasAdded)
        {
            Debug.Log(_item.ItemName + "coletado");
            Scr_Manager_AudioManager.Instance.PlaySound(SoundType.ItemPickup);
            Scr_Manager_GameManager.Instance.SavePlayer();
            Destroy(gameObject); // Destroy item
        }
        else
        {
            Debug.Log("Inventory is Full");
        }
        
        Scr_Manager_GameManager.Instance.UIDisplay.gameObject.SetActive(false);
    }
}
