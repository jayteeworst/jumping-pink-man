using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IPickupable
{
    [SerializeField] private int amount;
    
    public void PickUp(Player.Player p)
    {
        p.Heal(amount);
    }
}
