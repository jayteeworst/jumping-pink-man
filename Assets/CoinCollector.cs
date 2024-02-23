using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Platformer
{
    public class CoinCollector : MonoBehaviour
    {
        private int totalCoinsValue;
        private int collectedCoinsValue;
        private Coin[] coins;
        private List<Coin> coinsRandomized = new();
        private CoinAudioManager _coinAudioManager;
        [SerializeField] private TextMeshProUGUI coinText;

        private void Start()
        {
            _coinAudioManager = GetComponent<CoinAudioManager>();
            coins = GetComponentsInChildren<Coin>(true);
            foreach (var coin in coins)
            {
                totalCoinsValue += coin.CoinType.itemValue;
            }

            var randomizedContainers = GetComponentsInChildren<RandomizedContainer>(true);
            
            foreach (var rc in randomizedContainers)
            {
                foreach (var go in rc.contents)
                {
                    if (!go.TryGetComponent<Coin>(out var coin)) continue;
                    coinsRandomized.Add(coin);
                    totalCoinsValue += coin.CoinType.itemValue;
                }
            }
            // coinText.text = collectedCoinsValue + "/" + totalCoinsValue;
            Coin.OnCoinCollected += HandleCoinCollection;
        }

        private void HandleCoinCollection(Coin collectedCoin)
        {
            Debug.Log("Collected " + collectedCoin + " (Value: " + collectedCoin.CoinType.itemValue + ")");
            collectedCoinsValue += collectedCoin.CoinType.itemValue;
            coinText.text = collectedCoinsValue.ToString();
            _coinAudioManager.PlayCoinPickupAudio();
        }
    }
}
