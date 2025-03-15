using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Player_UI : MonoBehaviour
{
    [Header("Menu Settings")] 
    [SerializeField] private GameObject _menuPanel;

    private PlayerInput _playerInput;
    private InputAction _toggleMenuAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _toggleMenuAction = _playerInput.actions["OpenMenu"];

        _toggleMenuAction.performed += OnToggleMenuPerformed;
    }

    private void OnToggleMenuPerformed(InputAction.CallbackContext context)
    {
        if (_menuPanel != null)
        {
            bool isMenuActive = !_menuPanel.activeSelf; // Invert current state
            _menuPanel.SetActive(isMenuActive);
            
            Debug.Log(isMenuActive ? "Open Menu" : "Closed Menu");
        }
        else
        {
            Debug.LogWarning("No panel was founded");
        }
        
        //ToggleMenu();
        Debug.Log("teste");
    }

    public void ToggleMenu()
    {
        if (_menuPanel != null)
        {
            bool isMenuActive = !_menuPanel.activeSelf; // Invert current state
            _menuPanel.SetActive(isMenuActive);
            
            Debug.Log(isMenuActive ? "Open Menu" : "Closed Menu");
        }
        else
        {
            Debug.LogWarning("No panel was founded");
        }
    }

    private void OnEnable()
    {
        _toggleMenuAction.Enable();
    }

    private void OnDisable()
    {
        _toggleMenuAction.Disable();

        _toggleMenuAction.performed -= OnToggleMenuPerformed;
    }
}
