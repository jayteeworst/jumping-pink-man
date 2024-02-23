using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerVisuals : MonoBehaviour
    {
        [Header("Player Animator")] 
        [SerializeField] private Animator _animator;

        [Header("Player ParticleSystems")] 
        [SerializeField] private ParticleSystem _movementParticles;
        [SerializeField] private ParticleSystem _bloodParticles;
        [SerializeField] private ParticleSystem _bloodParticlesDeath;

        [SerializeField] private SpriteRenderer _playerSpriteRenderer;
        private bool _isFacingRight = true;

        public void UpdateVisuals(Vector2 rbVelocity, float moveDirection)
        {
            _animator.SetBool(PlayerAnimatorConstants.Running, rbVelocity.x != 0);
            _animator.SetBool(PlayerAnimatorConstants.Jumping, rbVelocity.y > 0);
            _animator.SetBool(PlayerAnimatorConstants.Falling, rbVelocity.y < 0);
            _animator.SetFloat(PlayerAnimatorConstants.VerticalVelocity, rbVelocity.y);
            _animator.SetFloat(PlayerAnimatorConstants.RunSpeed, Mathf.Abs(rbVelocity.x));

            PlayerMovingVisuals(rbVelocity.x > 0 || rbVelocity.y > 0);

            if (!_isFacingRight && moveDirection > 0f)
            {
                FlipSpriteRenderer();
            }
            else if (_isFacingRight && moveDirection < 0f)
            {
                FlipSpriteRenderer();
            }
        }

        private void PlayerMovingVisuals(bool isMoving)
        {
            if (isMoving)
            {
                _movementParticles.Play();
            }
            else
            {
                _movementParticles.Stop();
            }
        }

        public void PlayerHitVisuals()
        {
            _animator.SetTrigger(PlayerAnimatorConstants.Hit);
            _bloodParticles.Play();
        }

        public void PlayerDeadVisuals()
        {
            _animator.SetTrigger(PlayerAnimatorConstants.Death);
            _bloodParticlesDeath.Play();
        }

        public void ResetParticlesAndAnimator()
        {
            _bloodParticlesDeath.Stop();
            _animator.SetTrigger(PlayerAnimatorConstants.Restart);
        }

        private void FlipSpriteRenderer()
        {
            _playerSpriteRenderer.flipX = !_playerSpriteRenderer.flipX;
            _isFacingRight = !_isFacingRight;
        }
        
        public void ToggleTransparency(bool value)
        {
            var color = _playerSpriteRenderer.color;
            color.a = value ? 0.5f : 1f;
            _playerSpriteRenderer.color = color;
        }
    }
}