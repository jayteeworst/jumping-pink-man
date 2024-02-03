using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private int interactableLayer;
        private int hitpoints;
        [SerializeField] private int maximumHitpoints;
        private bool isInvincible;
        public bool IsInvincible
        {
            get => isInvincible;
            set => isInvincible = value;
        }
        public int MaximumHitpoints => maximumHitpoints;
        private PlayerController pc;
        private int playerLayer;
        private int trapsLayer;

        private void Awake()
        {
            pc = GetComponent<PlayerController>();
        }

        private void Start()
        {
            hitpoints = maximumHitpoints;
            interactableLayer = 1 << LayerMask.NameToLayer("Interactable");
            playerLayer = LayerMask.NameToLayer("Player");
            trapsLayer = LayerMask.NameToLayer("Trap");
        }

        public void Hit(IDamageInformation damageInformation)
        {
            if (isInvincible) return;
            pc.PlayerHitVisuals();
            Damage(damageInformation.DamageInfo.DamageAmount);
            Debug.Log(this + " hit by " + damageInformation.DamageInfo.DamageSourceName + " for " + damageInformation.DamageInfo.DamageAmount + " HP!");
        }

        private void Damage(int amount)
        {
            hitpoints -= amount;
            if (hitpoints <= 0)
            {
                Kill();
                return;
            }

            StartCoroutine(MakeTemporarilyInvincible(3f));
        }
        
        public void Kill()
        {
            Debug.Log("Player ded");
            pc.PlayerDeadVisuals();
            pc.DisableInput();
            GameManager.Instance.PlayerDead();
        }

        public void Heal(int healAmount)
        {
            hitpoints += healAmount;
        }

        public void FullyHeal()
        {
            hitpoints = maximumHitpoints;
        }

        public void LookForInteractables()
        {
            Debug.Log("Looking for interactables...");
            var hit = Physics2D.OverlapCircle(transform.position, 0.5f, interactableLayer);
            if (!hit) return;
            Debug.Log(hit);
            if (hit.gameObject.TryGetComponent<IInteractable>(out var interactable))
            {
                Interact(interactable);
            }
        }

        private void Interact(IInteractable interactable)
        {
            interactable.Interact(this);
        }

        private IEnumerator MakeTemporarilyInvincible(float duration)
        {
            isInvincible = true;
            IgnoreCollisionWithTraps(true);
            pc.ToggleTransparency(true);
            
            yield return new WaitForSeconds(duration);
            
            isInvincible = false;
            IgnoreCollisionWithTraps(false);
            pc.ToggleTransparency(false);
        }

        private void IgnoreCollisionWithTraps(bool state)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, trapsLayer, state);
        }

        public void Knockback(Vector2 direction, float force)
        {
            pc.Knockback(direction, force);
        }
    }
}
