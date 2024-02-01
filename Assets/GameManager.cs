using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameState gameState { get; private set; } 
    public static GameManager Instance { get; private set; }

    private GameManager() { }

    [SerializeField] private SceneLoader.SceneName nextSceneName;
    [SerializeField] private Button _button;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("More than one instance found!", this);
            Destroy(Instance);
        }
        Instance = this;

        gameState = GameState.NotStarted;
        _button.onClick.AddListener(LoadNextScene);
        _button.gameObject.SetActive(false);
        
        if(nextSceneName == SceneLoader.SceneName.LoadingScreen)
            Debug.LogWarning("nextSceneName is set to LoadingScreen. This might be unwanted.");
    }

    public void LevelComplete()
    {
        gameState = GameState.LevelSuccess;
        _button.gameObject.SetActive(true);
    }

    public void PlayerDead()
    {
        gameState = GameState.LevelFailed;
    }

    private void LoadNextScene()
    {
        SceneLoader.LoadScene(nextSceneName);
    }

    public enum GameState
    {
        NotStarted,
        Started,
        LevelFailed,
        LevelSuccess
    }
}
