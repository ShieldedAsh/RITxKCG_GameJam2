using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    void Start()
    {
        float time = Tower.lastTime;

        int m = (int)(time / 60);
        int s = (int)(time % 60);

        tmp.text = $"{m:00}:{s:00}";
    }
}
