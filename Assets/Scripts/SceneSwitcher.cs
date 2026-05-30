using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSwitcher
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
