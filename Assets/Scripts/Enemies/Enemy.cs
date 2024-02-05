using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageInformation
{
    private Collider2D enemyCollider;
    [Range(1, 10)][SerializeField] private int damageAmount = 1;
    [Range(1, 3)][SerializeField] private int hitpoints = 1;
    [SerializeField] private float knockbackForce = 1500f;
    
    private void Awake()
    {
        enemyCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.TryGetComponent<Player.Player>(out var player)) return;

        Debug.Log(HasBeenHitFromAbove(other.GetContact(0)));
        if (HasBeenHitFromAbove(other.GetContact(0)))
        {
            Damaged();
            player.Knockback(-other.GetContact(0).normal, knockbackForce / 5f);
        }
        else
        {
            player.Hit(this);
            player.Knockback(-other.GetContact(0).normal, knockbackForce);
        }
    }

    private void Damaged()
    {
        Debug.Log(gameObject.name + " has been damaged");
        
        if (--hitpoints <= 0)
        {
            Destroyed();
        }
    }

    private void Destroyed()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private bool HasBeenHitFromAbove(ContactPoint2D contactPoint)
    {
        return contactPoint.point.y >= transform.position.y + enemyCollider.bounds.extents.y;
    }

    public DamageInformation DamageInfo => new()
    {
        DamageSourceName = name,
        DamageAmount = damageAmount
    };
}
