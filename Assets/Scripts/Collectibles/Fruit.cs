using UnityEngine;

namespace Platformer
{
    public class Fruit : MonoBehaviour, IPickupable
    {
        private int healAmount;
        [SerializeField] private ConsumableItem _consumableItem;

        private void Awake()
        {
            healAmount = _consumableItem.healthRestored;
        }

        public void PickUp(Player p)
        {
            Debug.Log(p + " picked up " + gameObject + " healing " + healAmount + "HP");
            p.Healed(healAmount);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var player))
            {
                PickUp(player);
                Destroy(gameObject);
            }
        }
    }
}
