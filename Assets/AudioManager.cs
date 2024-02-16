using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClipList _audioClipList;
    private AudioSource _audioSource;
    private float _volume;

    public static AudioManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        _volume = PlayerPrefs.GetFloat("SFXVolume", 10f) / 10f;
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.loop = false;
        _audioSource.volume = _volume;
    }
    
    public void UpdateVolume(float value)
    {
        _audioSource.volume = value / 10f;
    }
    
    public void ChestOpened(Vector3 chestPosition)
    {
        // AudioSource.PlayClipAtPoint(_audioClipList.chestOpened, chestPosition, _volume);
        _audioSource.clip = _audioClipList.chestOpened;
        _audioSource.Play();
    }

    public void PlayerDamaged(Vector3 playerPosition)
    {
        // AudioSource.PlayClipAtPoint(_audioClipList.playerDamaged, playerPosition, _volume);
        _audioSource.clip = _audioClipList.playerDamaged;
        _audioSource.Play();
    }
    
    public void PlayerDied(Vector3 playerPosition)
    {
        // AudioSource.PlayClipAtPoint(_audioClipList.playerDeath, playerPosition, _volume);
        _audioSource.clip = _audioClipList.playerDeath;
        _audioSource.Play();
    }

    public void EnemyDamaged(Vector3 enemyPosition)
    {
        // AudioSource.PlayClipAtPoint(_audioClipList.enemyDamaged, enemyPosition, _volume);
        _audioSource.clip = _audioClipList.enemyDamaged;
        _audioSource.Play();
    }
}
