using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_UI_ItemDisplay : MonoBehaviour
{
    private static Scr_UI_ItemDisplay _instance;

    [SerializeField] private GameObject _itemDisplayUI;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemDescription;
    
    public static Scr_UI_ItemDisplay Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        HideItemDisplay();
    }

    public void DisplayItem(Scr_SO_Item item)
    {
        if(item == null) return;
        
        _itemDisplayUI.SetActive(true);

        _itemIcon.sprite = item.ItemSprite;
        _itemDescription.text = item.ItemDescription;
    }

    public void HideItemDisplay()
    {
        _itemDisplayUI.SetActive(false);
    }
}
