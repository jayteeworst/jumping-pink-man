using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioClipList", menuName = "GameAudio/AudioClipList")]
public class AudioClipList : ScriptableObject
{
    public AudioClip chestOpened;
    public AudioClip playerDeath;
    public AudioClip enemyDamaged;
    public AudioClip playerDamaged;
}
