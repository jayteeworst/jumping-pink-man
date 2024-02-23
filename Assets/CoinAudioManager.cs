using UnityEngine;

namespace Platformer
{
    public class CoinAudioManager : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField] private AudioClip _coinPickupAudioClip;
        private float _volume;

        private void Awake()
        {
            _volume = PlayerPrefs.GetFloat("SFXVolume", 10f);
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _coinPickupAudioClip;
            _audioSource.playOnAwake = false;
            _audioSource.loop = false;
            _audioSource.volume = _volume / 10f;
        }

        public void PlayCoinPickupAudio()
        {
            _audioSource.clip = _coinPickupAudioClip;
            _audioSource.Play();
        }

        public void UpdateVolume(float value)
        {
            _audioSource.volume = value / 10f;
        }
    }
}
