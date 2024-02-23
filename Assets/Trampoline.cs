using System;
using Platformer;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounceForce = 500f;
    private Animator _animator;
    private static readonly int Launch = Animator.StringToHash("Launch");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.TryGetComponent<Rigidbody2D>(out var rb)) return;
        Debug.Log(rb + " touched " + gameObject.name);
        // rb.AddForceAtPosition(transform.up * bounceForce, rb.position);
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * bounceForce);
        _animator.SetTrigger(Launch);
    }
}
