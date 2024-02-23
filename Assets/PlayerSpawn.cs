using Platformer;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private GameObject playerGO;
    
    private void Start()
    {
        GameManager.Instance.onGameStateChanged += GameStateChanged;
        
        if(FindObjectOfType<Player>())
            playerGO = FindObjectOfType<Player>().gameObject;
    }

    private void GameStateChanged(GameManager.State state)
    {
        if (state == GameManager.State.Restarted)
        {
            OnGameRestarted();
        }
    }

    private void OnGameRestarted()
    {
        playerGO.transform.position = transform.position;
        playerGO.GetComponent<Player>().Respawned();
    }
}
