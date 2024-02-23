using System;
using UnityEngine;

namespace Platformer
{
    public class Coin : MonoBehaviour, IPickupable
    {
        public ValuableItem CoinType;
        
        public void PickUp(Player p)
        {
            Debug.Log(p + " collected " + CoinType.itemName + " worth " + CoinType.itemValue);
            OnCoinCollected?.Invoke(this);
            Destroy(gameObject);
        }
        
        public static event Action<Coin> OnCoinCollected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var player))
            {
                PickUp(player);
            }
        }
    }
}