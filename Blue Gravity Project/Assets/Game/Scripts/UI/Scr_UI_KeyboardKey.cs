using UnityEngine.UI;
using UnityEngine;

public class Scr_UI_KeyboardKey : MonoBehaviour
{
    [SerializeField] private Image _normalImage;

    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _pressedSprite;

    public Image NormalImage
    {
        get { return _normalImage; }
    }
    public Sprite NormalSprite
    {
        get { return _normalSprite; }
    }
    public Sprite PressedSprite
    {
        get { return _pressedSprite; }
    }

    public void ChangeToPressedSprite()
    {
        _normalImage.sprite = _pressedSprite;
    }

    public void ChangeToNormalSprite()
    {
        _normalImage.sprite = _normalSprite;
    }
}
