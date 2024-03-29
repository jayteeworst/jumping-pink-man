using Platformer;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.TryGetComponent<Player>(out _)) return;
        if (GameManager.Instance.GameState == GameManager.State.LevelSuccess) return;
        PlayConfetti();
        GameManager.Instance.LevelComplete();
    }

    private void PlayConfetti()
    {
        _particleSystem.Play();
    }
}
