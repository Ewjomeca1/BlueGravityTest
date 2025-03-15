using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Scr_Scriptable_Items", menuName = "Scriptable Objects/Scr_Scriptable_Items")]
public class Scr_SO_Item : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private string _itemDescription;
    [SerializeField] private Sprite _itemSprite;
    [SerializeField] private int _maxStack;
    [FormerlySerializedAs("_isEquippable")] [SerializeField] private bool _isHealabble;
    [SerializeField] private int _itemValue;

    public string ItemID => this.name;
    public string ItemName
    {
        get { return _itemName; }
        set { _itemName = value; }
    }
    
    public string ItemDescription
    {
        get { return _itemDescription; }
        set { _itemDescription = value; }
    }
    
    public Sprite ItemSprite
    {
        get { return _itemSprite; }
        set { _itemSprite = value; }
    }
        
    public int MaxStack
    {
        get { return _maxStack; }
        set { _maxStack = value; }
    }
    
    public bool IsHealabble
    {
        get { return _isHealabble; }
        set { _isHealabble = value; }
    }

    public int ItemValue
    {
        get { return _itemValue; }
        set { _itemValue = value; }
    }
}
