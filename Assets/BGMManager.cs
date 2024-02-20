using UnityEngine;
using Random = UnityEngine.Random;

public class BGMManager : MonoBehaviour
{
    public MusicList musicList;
    private AudioSource _audioSource;
    private float _volume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (!musicList)
        {
            Debug.LogError("MusicList ScriptableObject not assigned!", this);
            return;
        }
        
        int randomIndex = Random.Range(0, musicList.musicTracks.Length - 1);
        AudioClip randomMusicTrack = musicList.musicTracks[randomIndex];

        _volume = PlayerPrefs.GetFloat("MusicVolume", 10f);
        _audioSource.clip = randomMusicTrack;
        _audioSource.loop = true;
        _audioSource.volume = _volume / 10f;

        _audioSource.Play();
    }

    public void UpdateVolume(float value)
    {
        _audioSource.volume = value / 10f;
    }
}
