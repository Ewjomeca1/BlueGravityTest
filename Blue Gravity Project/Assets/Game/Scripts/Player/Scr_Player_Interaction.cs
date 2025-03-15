using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Player_Interaction : MonoBehaviour
{
    [Header("Interaction Settings")] [SerializeField]
    private float _interactionRange = 2f;

    [SerializeField] private LayerMask _interactableLayer;

    private PlayerInput _playerInput;
    private InputAction _interactionAction;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        _interactionAction = _playerInput.actions["Interact"];
        
        _interactionAction.performed += OnInteracted;
        _interactionAction.canceled += OnInteractedEnded;
    }

    private void OnInteractedEnded(InputAction.CallbackContext obj)
    {
        Debug.Log("Interaction Ended");
    }

    private void OnInteracted(InputAction.CallbackContext obj)
    {
        TryInteract();
    }

    private void TryInteract()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _interactionRange, _interactableLayer);

        foreach (var hitCollider in hitColliders)
        {
            Scr_Interface_PlayerInteractions interactable = hitCollider.GetComponent<Scr_Interface_PlayerInteractions>();
            if (interactable != null)
            {
                interactable.Interact();
                break; // Interact only with the first obj founded
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }
}
