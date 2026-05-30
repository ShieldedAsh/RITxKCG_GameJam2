using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // ウェーブ
    [Header("ウェーブを入れる")]
    [SerializeField]private List<Wave> waves = new List<Wave>();
    
    /// <summary>
    /// 全てのウェーブを初期化
    /// </summary>
    void Start()
    {
        foreach (var wave in waves)
        {
            wave.Initialize();
        }
    }

    /// <summary>
    /// 全てのウェーブを更新
    /// </summary>
    void Update()
    {
        foreach (var wave in waves)
        {
            wave.MyUpdate();
        }
    }

    /// <summary>
    /// タイマーの停止
    /// </summary>
    public void StopWaveTimer()
    {
        foreach (var wave in waves)
        {
            wave.GetTimer.StopTimer();
        }
    }

    /// <summary>
    /// タイマーの開始
    /// </summary>
    public void StartWaveTimer()
    {
        foreach (var wave in waves)
        {
            wave.GetTimer.StartTimer();
        }
    }
}