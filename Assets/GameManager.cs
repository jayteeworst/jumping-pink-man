using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public State GameState { get; private set; } 
    public static GameManager Instance { get; private set; }

    public Action<State> onGameStateChanged;

    private GameManager() { }

    [SerializeField] private SceneLoader.SceneName nextSceneName;
    [FormerlySerializedAs("_button")] [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Button _mainMenuButton;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("More than one instance found!", this);
            Destroy(Instance);
        }
        Instance = this;

        ChangeGameState(State.NotStarted);
        
        ButtonsSetUp();

        if(nextSceneName == SceneLoader.SceneName.LoadingScreen)
            Debug.LogWarning("nextSceneName is set to LoadingScreen. This might be unwanted.");
    }

    private void Start()
    {
        // TODO: Callback from loading screen (ie. press any key to continue)
        ChangeGameState(State.Started);
    }

    private void ButtonsSetUp()
    {
        _nextLevelButton.onClick.AddListener(LoadNextScene);
        _nextLevelButton.gameObject.SetActive(false);
        _tryAgainButton.onClick.AddListener(TryAgain);
        _tryAgainButton.gameObject.SetActive(false);
        _mainMenuButton.onClick.AddListener(() => SceneLoader.LoadScene(SceneLoader.SceneName.MainMenu));
        _mainMenuButton.gameObject.SetActive(false);
    }

    public void LevelComplete()
    {
        ChangeGameState(State.LevelSuccess);
        _nextLevelButton.gameObject.SetActive(true);
        _mainMenuButton.gameObject.SetActive(true);
    }

    public void PlayerDead()
    {
        ChangeGameState(State.LevelFailed);
        _tryAgainButton.gameObject.SetActive(true);
        _mainMenuButton.gameObject.SetActive(true);
    }

    private void TryAgain()
    {
        ChangeGameState(State.Restarted);
        _tryAgainButton.gameObject.SetActive(false);
        _mainMenuButton.gameObject.SetActive(false);
    }

    private void LoadNextScene()
    {
        SceneLoader.LoadScene(nextSceneName);
    }

    private void ChangeGameState(State state)
    {
        GameState = state;
        onGameStateChanged?.Invoke(state);
    }
    
    public enum State
    {
        NotStarted,
        Started,
        LevelFailed,
        LevelSuccess,
        Restarted
    }
}
