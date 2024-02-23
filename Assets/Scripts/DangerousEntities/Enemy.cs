using UnityEngine;

namespace Platformer
{
    public class Enemy : DamageSource
    {
        private float _colliderBoundY;
        [Range(0, 3)] [SerializeField] private int hitpoints = 1;
        [SerializeField] private float hitFromAboveAllowedOffset = 0.01f;

        private void Awake()
        {
            _colliderBoundY = GetComponent<Collider2D>().bounds.extents.y;
        }

        protected override void PlayerCollidedHandler(Player player, DamageInfo damageInfo)
        {
            if (HasBeenHitFromAbove(damageInfo.contactPoint))
            {
                Damaged();
                // player.Knockback(-collision2D.GetContact(0).normal, knockbackForce / 5f);
            }
            else
            {
                player.Hit(damageInfo);
                // player.Knockback(-contact.normal, knockbackForce);
            }
        }

        private void Damaged()
        {
            Debug.Log(gameObject.name + " has been damaged");
            AudioManager.Instance.EnemyDamaged(transform.position);
            if (--hitpoints <= 0)
            {
                Destroyed();
            }
        }

        protected virtual void Destroyed()
        {
            Destroy(gameObject);
        }

        private bool HasBeenHitFromAbove(ContactPoint2D contactPoint)
        {
            return contactPoint.point.y + hitFromAboveAllowedOffset >= transform.position.y + _colliderBoundY;
        }
    }
}
