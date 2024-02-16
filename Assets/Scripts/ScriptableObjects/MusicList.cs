using UnityEngine;

[CreateAssetMenu(fileName = "NewMusicList", menuName = "Music/MusicList")]
public class MusicList : ScriptableObject
{
    public AudioClip[] musicTracks;
}