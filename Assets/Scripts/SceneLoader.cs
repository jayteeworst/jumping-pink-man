using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum SceneName
    {
        MainMenu = 0,
        LoadingScreen = 1,
        Sandbox = 2,
        Parallax = 3
    }

    private static SceneName _sceneToLoad;

    public static void LoadScene(SceneName sceneToLoad)
    {
        _sceneToLoad = sceneToLoad;
        SceneManager.LoadScene(SceneName.LoadingScreen.ToString());
    }

    public static void LoadingScreenCallback()
    {
        SceneManager.LoadScene(_sceneToLoad.ToString());
    }
}