using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorPickerControl : MonoBehaviour
{
    public float currentHue, currentSat, currentVal;

    [SerializeField] private RawImage _hueImage, _satValImage, _outputImage;
    
    [SerializeField] private Slider _hueSlider;
    

    private Texture2D _hueTexture, _svTexture, _outputTexture;
    
    [SerializeField] private List<Material> _changeThisMaterial;
    [SerializeField] private List<Button> _changeThisObjectMaterial;

    private int _selectedObjectIndex = -1;

    private void Start()
    {
        CreateHueImage();
        
        CreateSVImage();
        
        CreateOutputImage();
        
        UpdateOutputImage();

        for (int i = 0; i < _changeThisObjectMaterial.Count; i++)
        {
            int index = i;
            _changeThisObjectMaterial[i].onClick.AddListener(() => SelectedObject(index));
        }
    }

    private void SelectedObject(int index)
    {
        _selectedObjectIndex = index;
    }
    private void CreateHueImage()
    {
        _hueTexture = new Texture2D(1, 16);
        _hueTexture.wrapMode = TextureWrapMode.Clamp;
        _hueTexture.name = "HueTexture";

        for (int i = 0; i < _hueTexture.height; i++)
        {
            _hueTexture.SetPixel(0, i, Color.HSVToRGB((float)i / _hueTexture.height,1,1f));
        }
        
        _hueTexture.Apply();
        currentHue = 0;

        _hueImage.texture = _hueTexture;
    }

    private void CreateSVImage()
    {
        _svTexture = new Texture2D(16, 16);
        _svTexture.wrapMode = TextureWrapMode.Clamp;
        _svTexture.name = "SatValTexture";

        for (int y = 0; y < _svTexture.height; y++)
        {
            for (int x = 0; x < _svTexture.width; x++)
            {
                float saturation = (float)x / (_svTexture.width - 1);
                float value = (float)y / (_svTexture.height - 1);

                Color color = Color.HSVToRGB(currentHue, saturation, value);

                _svTexture.SetPixel(x, y, color);
            }
        }

        _svTexture.Apply();
        
        currentSat = 0;
        currentVal = 0;
        
        _satValImage.texture = _svTexture;
    }

    private void CreateOutputImage()
    {
        _outputTexture = new Texture2D(1, 16);
        _outputTexture.wrapMode = TextureWrapMode.Clamp;
        _outputTexture.name = "OutputTexture";
        
        Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);

        for (int i = 0; i < _outputTexture.height; i++)
        {
            _outputTexture.SetPixel(0,i,currentColor);
        }
        
        _outputTexture.Apply();
        
        _outputImage.texture = _outputTexture;
    }
    

    public void UpdateOutputImage()
    {
        Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);

        for (int i = 0; i < _outputTexture.height; i++)
        {
            _outputTexture.SetPixel(0, i, currentColor);
        }
        
        _svTexture.Apply();

        if (_selectedObjectIndex != -1)
        {
            _changeThisMaterial[_selectedObjectIndex].color = currentColor;
        }
    }
    
    public void SetSv(float S, float V)
    {
        currentSat = S;
        currentVal = V;

        UpdateOutputImage();
    }

    public void UpdateSVImage()
    {
        currentHue = _hueSlider.value;

        for (int y = 0; y < _svTexture.height; y++)
        {
            for (int x = 0; x < _svTexture.width; x++)
            {
                _svTexture.SetPixel(x,y,Color.HSVToRGB(currentHue,(float)x/ _svTexture.width,(float)y / _svTexture.height));
            }
        }
        _svTexture.Apply();
        
        UpdateOutputImage();
    }
}
