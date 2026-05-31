using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnClick()
    {
        switch(gameObject.tag)
        {
            case "Quit":
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
                break;
            case "Settings":
                break;
            case "Play":
                SceneSwitcher.LoadScene("MainScene");
                break;
            case "Menu":
                SceneSwitcher.LoadScene("MainMenuEN");
                break;
        }
    }
}
