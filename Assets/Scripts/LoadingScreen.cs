using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private bool _hasUpdated;

    private void Update()
    {
        if (_hasUpdated) return;
        _hasUpdated = true;
        SceneLoader.LoadingScreenCallback();
    }
}
