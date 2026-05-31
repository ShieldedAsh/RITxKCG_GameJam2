using UnityEngine;

public class Maingame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.PlaySE(SFX.Start);
        SoundManager.Instance.PlayBGM(BGM.MainGame);
    }

}
