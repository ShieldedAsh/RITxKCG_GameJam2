using UnityEngine;

public class Timer
{
    // 現在カウントしているか
    private bool isCounting = false;

    // 現在のタイム
    private float currentTime;

    // 1f前のタイム
    private float prevTime;

    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Initialize()
    {
        isCounting = true;
        currentTime = 0;
        prevTime = 0;
    }

    /// <summary>
    /// 現在のタイム取得
    /// </summary>
    /// <returns>現在のタイム</returns>
    public float GetCurrentTime()
    {
        return currentTime;
    }

    /// <summary>
    /// 現在タイムのセット
    /// </summary>
    /// <param name="time"></param>
    public void SetCurrentTime(float time)
    {
        currentTime = Mathf.Max(0f, time);
    }

    /// <summary>
    /// 1f前のタイムを取得
    /// </summary>
    /// <returns></returns>
    public float GetPrevTime()
    {
        return prevTime;
    }

    /// <summary>
    /// タイマーの更新
    /// </summary>
    public void UpdateTick()
    {
        if (isCounting == false)
        {
            return;
        }
        prevTime = currentTime;
        currentTime += Time.deltaTime;
    }

    /// <summary>
    /// タイマーの開始
    /// </summary>
    public void StartTimer()
    {
        isCounting = true;

        currentTime = 0f;
        prevTime = 0f;
    }

    /// <summary>
    /// タイマーの停止
    /// </summary>
    public void StopTimer()
    {
        isCounting = false;
    }

    /// <summary>
    /// タイマーのリセット
    /// </summary>
    public void ResetTimer()
    {
        currentTime = 0f;
        prevTime = 0f;
    }
}
