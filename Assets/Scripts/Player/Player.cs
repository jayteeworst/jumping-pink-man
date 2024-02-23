using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class Player : MonoBehaviour
    {
        private int _hitpoints;
        public int Hitpoints
        {
            get => _hitpoints;
            private set
            {
                _hitpoints = Mathf.Clamp(value, 0, maximumHitpoints);
                onHealthChanged.Invoke(value);
            }
        }
        [SerializeField] private int maximumHitpoints;

        public UnityEvent<int> onHealthChanged;
        public UnityEvent<Vector2, float> onHit;
        public UnityEvent onDeath;
        public UnityEvent onRespawn;

        private void Start()
        {
            SetHitpointsToMax();
        }

        public void Hit(DamageInfo damageInfo)
        {
            onHit.Invoke(-damageInfo.contactPoint.normal, damageInfo.knockbackForce);
            Damaged(damageInfo.amount);
            Debug.Log(this + " hit by " + damageInfo.sourceName + " for " + damageInfo.amount + " HP!");
        }

        private void Damaged(int amount)
        {
            Hitpoints -= amount;
            if (Hitpoints <= 0)
            {
                Killed();
                return;
            }
            AudioManager.Instance.PlayerDamaged(transform.position);
        }
        
        public void Killed()
        {
            onDeath.Invoke();
            AudioManager.Instance.PlayerDied(transform.position);
            GameManager.Instance.PlayerDead();
        }

        public void Healed(int healAmount)
        {
            Hitpoints = Mathf.Clamp(Hitpoints + healAmount, Hitpoints, maximumHitpoints);
        }

        private void SetHitpointsToMax()
        {
            Hitpoints = maximumHitpoints;
        }

        public void Respawned()
        {
            SetHitpointsToMax();
            onRespawn.Invoke();
        }

        public void LookForInteractables()
        {
            Debug.Log("Looking for interactables...");
            
            var hit = Physics2D.OverlapCircle(transform.position, 0.5f, GameLayers.InteractableLayerMask);
            if (!hit) return;
            
            if (hit.gameObject.TryGetComponent<IInteractable>(out var interactable))
            {
                Interact(interactable);
            }
        }

        private void Interact(IInteractable interactable)
        {
            interactable.Interact(this);
        }
    }
}
