using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.TryGetComponent<Player.Player>(out _)) return;
        if (GameManager.Instance.gameState == GameManager.GameState.LevelSuccess) return;
        PlayConfetti();
        GameManager.Instance.LevelComplete();
    }

    private void PlayConfetti()
    {
        _particleSystem.Play();
    }
}
