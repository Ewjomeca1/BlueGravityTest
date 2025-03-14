using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Scr_Player_Movement : MonoBehaviour
{
    // Referência ao CharacterController
    [SerializeField] private CharacterController _controller;
    
    [Header("Player Settings")]
    [SerializeField] private Scr_SO_PlayerInformations _playerSettings;

    [Header("Ground Detection")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private float _rotationSpeed = 10f;
    
    // Variáveis de estado
    private Vector2 _moveInput;
    private Vector3 _velocity;
    private bool _isGrounded;
    private bool _isSprinting;
    
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _sprintAction;

    private void Awake()
    {
        // Configura o Input System
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        //_sprintAction = _playerInput.actions["Sprint"];
        
        // Configura os callbacks
        _moveAction.performed += OnMovePerformed;
        _moveAction.canceled += OnMoveCanceled;
        //_sprintAction.performed += OnSprintPerformed;
        //_sprintAction.canceled += OnSprintCanceled;
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundLayer);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; // Reseta a velocidade vertical quando está no chão
        }

        // Calcula a direção do movimento (agora incluindo o eixo Z)
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y); // Inclui o eixo Z

        // Aplica a aceleração e limita a velocidade máxima
        float targetSpeed = _isSprinting ? _playerSettings.MaxSpeed : _playerSettings.MaxSpeed * 0.5f; // Sprint reduzido para 50% da velocidade máxima
        float acceleration = _playerSettings.Acceleration;
        float friction = _playerSettings.Friction;

        // Aplica a aceleração ou fricção dependendo do input
        if (moveDirection.magnitude > 0)
        {
            // Aumenta a velocidade gradualmente até o valor máximo
            _velocity.x = Mathf.MoveTowards(_velocity.x, moveDirection.x * targetSpeed, acceleration * Time.deltaTime);
            _velocity.z = Mathf.MoveTowards(_velocity.z, moveDirection.z * targetSpeed, acceleration * Time.deltaTime);
            
            RotatePlayer(moveDirection);
        }
        else
        {
            // Aplica fricção para reduzir a velocidade gradualmente
            _velocity.x = Mathf.MoveTowards(_velocity.x, 0, friction * Time.deltaTime);
            _velocity.z = Mathf.MoveTowards(_velocity.z, 0, friction * Time.deltaTime);
        }

        // Aplica o movimento horizontal
        _controller.Move(_velocity * Time.deltaTime);

        _velocity.y += _playerSettings.Gravity * Time.deltaTime;

        // Move o personagem no eixo Y (gravidade e pulo)
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void RotatePlayer(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }
    
    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        _isSprinting = true;
    }
    
    private void OnSprintCanceled(InputAction.CallbackContext context)
    {
        _isSprinting = false;
    }

    public Vector2 GetMoveInput()
    {
        return _moveInput;
    }
    
    private void OnEnable()
    {
        // Habilita as ações de entrada
        _moveAction.Enable();
        //_sprintAction.Enable();
    }

    private void OnDisable()
    {
        // Desabilita as ações de entrada
        _moveAction.Disable();
        //_sprintAction.Disable();

        // Remove os callbacks para evitar vazamentos de memória
        _moveAction.performed -= OnMovePerformed;
        _moveAction.canceled -= OnMoveCanceled;
        //_sprintAction.performed -= OnSprintPerformed;
        //_sprintAction.canceled -= OnSprintCanceled;
    }

    private void OnDrawGizmosSelected()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
    }
}
