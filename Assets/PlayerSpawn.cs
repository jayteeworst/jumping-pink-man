using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private GameObject playerGO;
    
    private void Start()
    {
        GameManager.Instance.onGameStateChanged += GameStateChanged;
        playerGO = FindObjectOfType<Player.Player>().gameObject;
    }

    private void GameStateChanged(GameManager.State state)
    {
        if (state == GameManager.State.Started)
        {
            OnGameStarted();
        }

        if (state == GameManager.State.Restarted)
        {
            OnGameRestarted();
        }
    }

    private void OnGameRestarted()
    {
        playerGO.transform.position = transform.position;
        playerGO.GetComponent<Player.Player>().Restart();
    }

    private void OnGameStarted()
    {
        playerGO = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
