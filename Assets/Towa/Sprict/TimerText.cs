using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float time = Tower.lastTime;
        tmp.text = (int)(time / 60) + ":" + (int)(time % 60); int m = (int)(time / 60);
        int s = (int)(time % 60);

        tmp.text = m.ToString("00") + ":" + s.ToString("00");
    }

}
