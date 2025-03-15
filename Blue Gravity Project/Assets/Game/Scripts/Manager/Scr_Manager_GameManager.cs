using System.Collections.Generic;
using UnityEngine;

public class Scr_Manager_GameManager : MonoBehaviour
{
    public static Scr_Manager_GameManager Instance;

    [SerializeField] private int _playerMoney;
    [SerializeField] private float _playerHealth;
    
    [SerializeField] public List<Scr_SO_Item> allAvailableItems = new List<Scr_SO_Item>();
    
    public int PlayerMoney
    {
        get { return _playerMoney; }
    }
    
    public float PlayerHealth
    {
        get { return _playerHealth; }
    }
    
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

    public void AddPlayerMoney(int value)
    {
        _playerMoney += value;
    }

    public void AddPlayerHealth(float value)
    {
        _playerHealth += value;
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
