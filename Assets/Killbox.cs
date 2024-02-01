using UnityEngine;

public class Killbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player.Player>(out var player))
        {
            player.Kill();
        }
    }
}
