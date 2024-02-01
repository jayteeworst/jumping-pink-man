using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
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
        rb.AddForce(transform.up * 1000f);
        _animator.SetTrigger(Launch);
    }
}
