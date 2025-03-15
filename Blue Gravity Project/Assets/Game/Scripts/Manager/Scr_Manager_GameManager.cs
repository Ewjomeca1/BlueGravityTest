using System.Collections.Generic;
using UnityEngine;

public class Scr_Manager_GameManager : MonoBehaviour
{
    public static Scr_Manager_GameManager Instance;

    [SerializeField] public int _playerMoney;
    [SerializeField] public float _playerHealth;
    
    [SerializeField] public List<Scr_SO_Item> allAvailableItems = new List<Scr_SO_Item>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadPlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        _playerMoney = data.playerMoney;
        _playerHealth = data.playerHealth;
        
        Scr_Inventory_BaseInventory.Instance.LoadItems(data.playerItems,allAvailableItems);
    }
    
    private void OnApplicationQuit()
    {
        SavePlayer();
    }
}
