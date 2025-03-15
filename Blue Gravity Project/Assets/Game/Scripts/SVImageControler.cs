using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SVImageControler : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Image _pickerImage;

    private RawImage _SVImage;

    [SerializeField] private ColorPickerControl _colorPickerControl;

    private RectTransform _rectTransform, _pickerTransform;

    private void Awake()
    {
        _SVImage = GetComponent<RawImage>();

        _rectTransform = GetComponent<RectTransform>();

        _pickerTransform = _pickerImage.GetComponent<RectTransform>();
        _pickerTransform.position =
            new Vector2(-(_rectTransform.sizeDelta.x * 0.5f), -(_rectTransform.sizeDelta.y * 0.5f));
    }

    private void UpdateColour(PointerEventData eventData)
    {
        Vector3 pos = _rectTransform.InverseTransformPoint(eventData.position);

        float deltaX = _rectTransform.sizeDelta.x * 0.5f;
        float deltaY = _rectTransform.sizeDelta.y * 0.5f;

        if (pos.x < -deltaX)
        {
            pos.x = -deltaX;
        }
        else if (pos.x > deltaX)
        {
            pos.x = deltaX;
        }

        if (pos.y < -deltaY)
        {
            pos.y = -deltaY;
        }
        else if (pos.y > deltaY)
        {
            pos.y = deltaY;
        }

        float x = pos.x + deltaX;
        float y = pos.y + deltaY;

        float xNorm = x / _rectTransform.sizeDelta.x;
        float yNorm = y / _rectTransform.sizeDelta.y;

        _pickerTransform.localPosition = pos;
        _pickerImage.color = Color.HSVToRGB(0,0,1 - yNorm);
        
        _colorPickerControl.SetSv(xNorm,yNorm);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateColour(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateColour(eventData);
    }
}
