using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    //singleton
    public static PauseManager instance;
    private bool IsPaused;
    [SerializeField]
    private GameObject pauseMenuUI;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        Debug.Log("Unpaused");
        IsPaused = false;
    }

    void Pause()
    {
        IsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Paused");
    }
}
