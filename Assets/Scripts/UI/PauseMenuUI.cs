using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuContainer;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject optionsContainer;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Button returnButton;
    
    private void Awake()
    {
        continueButton.onClick.AddListener(() =>
        {
            GameManager.Instance.PauseGame(false);
        });
        optionsButton.onClick.AddListener(() =>
        {
            pauseMenuContainer.SetActive(false);
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
            pauseMenuContainer.SetActive(true);
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
