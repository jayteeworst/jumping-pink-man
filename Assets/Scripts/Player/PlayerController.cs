using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float jumpForce = 10f;
        
        [SerializeField] private GameObject playerVisuals;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Animator animator;
        [FormerlySerializedAs("_particleSystem")] [SerializeField] private ParticleSystem movementParticles;
        [SerializeField] private ParticleSystem bloodParticles;
        [SerializeField] private ParticleSystem bloodParticlesDeath;
        private PlayerInput playerInput;
        private SpriteRenderer playerSR; 
        private Player _player;
        private Rigidbody2D rb;
        private bool isGrounded;
        private Transform groundCheck;
        private float moveDirection;
        private bool isFacingRight;
        private bool isMoving;
        
        private void Start()
        {
            _player = GetComponent<Player>();
            rb = GetComponent<Rigidbody2D>();
            playerSR = playerVisuals.GetComponent<SpriteRenderer>();
            playerInput = GetComponent<PlayerInput>();
            groundCheck = transform.Find("GroundCheck");
            isFacingRight = true;
        }

        private void Update()
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
            isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
            isMoving = rb.velocity.x != 0 || rb.velocity.y != 0;

            if (isMoving)
            {
                movementParticles.Play();
            }
            else if (!isMoving)
            {
                movementParticles.Stop();
            }

            if (!isFacingRight && moveDirection > 0f)
            {
                FlipCharacter();
            }
            else if (isFacingRight && moveDirection < 0f)
            {
                FlipCharacter();
            }
            
            animator.SetBool("Running", rb.velocity.x != 0);
            animator.SetBool("Jumping", rb.velocity.y > 0);
            animator.SetBool("Falling", rb.velocity.y < 0);
            animator.SetFloat("VerticalVelocity", rb.velocity.y);
            animator.SetFloat("RunSpeed", Mathf.Abs(rb.velocity.x));
        }

        private void FlipCharacter()
        {
            playerSR.flipX = !playerSR.flipX;
            isFacingRight = !isFacingRight;
        }

        public void ToggleTransparency(bool value)
        {
            var color = playerSR.color;
            color.a = value ? 127 : 255;
            playerSR.color = color;
        }

        public void Move(InputAction.CallbackContext ctx)
        {
            moveDirection = ctx.ReadValue<Vector2>().x;
        }

        public void Jump(InputAction.CallbackContext ctx)
        {
            if (isGrounded && ctx.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (ctx.canceled && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

        public void Interact(InputAction.CallbackContext ctx)
        {
            if(ctx.performed)
                _player.LookForInteractables();
        }

        public void PlayerHitVisuals()
        {
            animator.SetTrigger("Hit");
            bloodParticles.Play();
        }

        public void PlayerDeadVisuals()
        {
            animator.SetTrigger("Death");
            bloodParticlesDeath.Play();
        }

        public void DisableInput()
        {
            playerInput.DeactivateInput();
        }
        
        public void Knockback(Vector2 direction, float force)
        {
            rb.AddForce(direction * force);
        }
    }
}