using UnityEngine;
using Random = UnityEngine.Random;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    public MusicList musicList;
    private float _volume;

    private void Start()
    {
        if (!musicList)
        {
            Debug.LogError("MusicList ScriptableObject not assigned!", this);
            return;
        }
        
        var randomIndex = Random.Range(0, musicList.musicTracks.Length - 1);
        var randomMusicTrack = musicList.musicTracks[randomIndex];

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
