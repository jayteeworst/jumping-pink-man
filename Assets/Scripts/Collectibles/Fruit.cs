using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IPickupable
{
    private int healAmount;
    [SerializeField] private ConsumableItem _consumableItem;

    private void Awake()
    {
        healAmount = _consumableItem.healthRestored;
    }

    public void PickUp(Player.Player p)
    {
        p.Heal(healAmount);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player.Player>(out var player))
        {
            player.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
