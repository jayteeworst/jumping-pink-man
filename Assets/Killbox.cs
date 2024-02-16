using UnityEngine;

public class Killbox : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player.Player>(out var player))
        {
            player.Kill();
            _audioSource.Play();
        }
    }
}
