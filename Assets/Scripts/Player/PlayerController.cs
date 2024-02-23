using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float jumpForce = 10f;
        
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Collider2D groundCheckCollider;
        private PlayerVisuals _playerVisuals;
        private PlayerInput _playerInput;
        private Player _player;
        private Rigidbody2D _rb;
        private bool _isGrounded;
        private float _moveDirection;

        public bool enableDebug;
        
        private void OnEnable()
        {
            _player.onHit.AddListener(Knockback);
            _player.onDeath.AddListener(DisableInput);
            _player.onRespawn.AddListener(EnableInput);
        }

        private void OnDisable()
        {
            _player.onHit.AddListener(Knockback);
        }

        private void Awake()
        {
            _player = GetComponent<Player>();
            _playerVisuals = GetComponent<PlayerVisuals>();
            _rb = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            _rb.velocity = new Vector2(_moveDirection * moveSpeed, _rb.velocity.y);
            _isGrounded = Physics2D.IsTouchingLayers(groundCheckCollider, groundLayer);
            _playerVisuals.UpdateVisuals(_rb.velocity, _moveDirection);

            if (enableDebug)
            {
                var totalForce = _rb.totalForce;
                if(totalForce.x != 0 || totalForce.y != 0)
                    Debug.Log($"totalforce x: {totalForce.x}, totalforce y: {totalForce.y}");
            }
        }

        public void Move(InputAction.CallbackContext ctx)
        {
            _moveDirection = ctx.ReadValue<Vector2>().x;
        }

        public void Jump(InputAction.CallbackContext ctx)
        {
            if (_isGrounded && ctx.performed)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            }

            if (ctx.canceled && _rb.velocity.y > 0)
            {
                var velocity = _rb.velocity;
                velocity = new Vector2(velocity.x, velocity.y * 0.5f);
                _rb.velocity = velocity;
            }
        }

        public void Interact(InputAction.CallbackContext ctx)
        {
            if(ctx.performed)
                _player.LookForInteractables();
        }

        public void EscapeKeyPressed(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
                GameManager.Instance.HandleEscapeButton();
        }

        private void DisableInput()
        {
            _playerInput.DeactivateInput();
        }

        private void EnableInput()
        {
            _playerInput.ActivateInput();
        }

        private void Knockback(Vector2 direction, float force)
        {
            _rb.AddForce(direction * force);
        }
    }
}