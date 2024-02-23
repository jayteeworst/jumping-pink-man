using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContainer;
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject optionsContainer;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Button returnButton;
    
    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneLoader.LoadScene(SceneLoader.SceneName.Sandbox);
        });
        optionsButton.onClick.AddListener(() =>
        {
            mainMenuContainer.SetActive(false);
            optionsContainer.SetActive(true);
        });
        exitButton.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            
#if UNITY_STANDALONE
            Application.Quit();
#endif
        });
        returnButton.onClick.AddListener(() =>
        {
            optionsContainer.SetActive(false);
            mainMenuContainer.SetActive(true);
            SaveCurrentValues();
        });
    }

    private void Start()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", musicVolumeSlider.maxValue);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", SFXSlider.maxValue);
    }

    private void SaveCurrentValues()
    {
        Debug.Log("Saving values to PlayerPrefs, Music: " + musicVolumeSlider.value + ", SFX: " + SFXSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.Save();
        
    }
}
