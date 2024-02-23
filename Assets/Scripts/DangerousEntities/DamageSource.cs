using UnityEngine;

namespace Platformer
{
    public abstract class DamageSource : MonoBehaviour
    {
        [Range(1, 10)] [SerializeField] protected int damageAmount = 1;
        [SerializeField] protected float knockbackForce = 1500f;

        public string Source => gameObject.name;
        public int Amount => damageAmount;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent<Player>(out var player)) return;
            
            PlayerCollidedHandler(player, new DamageInfo(gameObject.name, damageAmount, other.GetContact(0), knockbackForce));
        }

        protected abstract void PlayerCollidedHandler(Player player, DamageInfo damageInfo);
    }

    public struct DamageInfo
    {
        public string sourceName;
        public int amount;
        public ContactPoint2D contactPoint;
        public float knockbackForce;

        public DamageInfo(string name, int amount, ContactPoint2D point, float force)
        {
            sourceName = name;
            this.amount = amount;
            contactPoint = point;
            knockbackForce = force;
        }
    }
}
