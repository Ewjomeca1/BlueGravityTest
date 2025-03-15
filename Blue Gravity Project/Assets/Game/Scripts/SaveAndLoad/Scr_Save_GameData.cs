using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scr_Save_GameData
{
    private List<string> _itemIDs = new List<string>();
    private List<int> _itemPositions = new List<int>();
    private int _playerMoney;
    private float _playerHealth;

    public List<string> ItemIDs
    {
        get { return _itemIDs; }
        set { _itemIDs = value; }
    }
    
    public List<int> ItemPositions
    {
        get { return _itemPositions; }
        set { _itemPositions = value; }
    }
    public int PlayerMoney
    {
        get { return _playerMoney; }
        set { _playerMoney = value; }
    }
    public float PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }
}
