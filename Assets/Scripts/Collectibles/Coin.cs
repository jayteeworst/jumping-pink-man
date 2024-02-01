using System;
using UnityEngine;

namespace Collectibles
{
    public class Coin : MonoBehaviour, IPickupable
    {
        public ValuableItem CoinType;
        
        public void PickUp(Player.Player p)
        {
            Debug.Log(p + " collected " + CoinType.itemName + " worth " + CoinType.itemValue);
        }
        
        public static event Action<Coin> OnCoinCollected;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Collected();
            }
        }

        private void Collected()
        {
            OnCoinCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}