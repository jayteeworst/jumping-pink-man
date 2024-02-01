using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectibles
{
    public class CoinCollector : MonoBehaviour
    {
        private int totalCoinValue;
        private Coin[] coins;
        private List<Coin> coinsRandomized = new();

        private void Start()
        {
            coins = GetComponentsInChildren<Coin>(true);
            foreach (var coin in coins)
            {
                totalCoinValue += coin.CoinType.itemValue;
            }

            var randomizedContainers = GetComponentsInChildren<RandomizedContainer>(true);
            
            foreach (var rc in randomizedContainers)
            {
                foreach (var go in rc.contents)
                {
                    if (!go.TryGetComponent<Coin>(out var coin)) continue;
                    coinsRandomized.Add(coin);
                    totalCoinValue += coin.CoinType.itemValue;
                }
            }
            
            Coin.OnCoinCollected += HandleCoinCollection;
        }

        private void HandleCoinCollection(Coin collectedCoin)
        {
            Debug.Log("gagri " + collectedCoin);
        }
    }
}
