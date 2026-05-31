using UnityEngine;

public class TitleSound : MonoBehaviour
{

    void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.GameMenu);
    }

}
