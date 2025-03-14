using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int playerMoney;
    public float playerHealth;
    public List<string> playerItems;

    public PlayerData(Scr_Manager_GameManager player)
    {
        playerMoney = player.PlayerMoney;
        playerHealth = player.PlayerHealth;
        
        playerItems = new List<string>(Scr_Inventory_BaseInventory.Instance.ItemNames);
    }
}
