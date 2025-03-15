using System;
using TMPro;
using UnityEngine;

public class Scr_UI_PlayerInformations : MonoBehaviour
{
    [SerializeField] private Scr_SO_PlayerInformations _playerInformations;

    [SerializeField] private TextMeshProUGUI _currentHealth;
    [SerializeField] private TextMeshProUGUI _playerCurrentMoney;

    private void Start()
    {
        _currentHealth.text = "Current Health: " + Scr_Manager_GameManager.Instance.PlayerHealth;

        _playerCurrentMoney.text = "Current Money: " + Scr_Manager_GameManager.Instance.PlayerMoney;
    }

    private void OnEnable()
    {
        _currentHealth.text = "Current Health: " + Scr_Manager_GameManager.Instance.PlayerHealth;
        
        _playerCurrentMoney.text = "Current Money: " + Scr_Manager_GameManager.Instance.PlayerMoney;
    }
}
