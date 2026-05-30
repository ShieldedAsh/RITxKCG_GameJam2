using Unity.Hierarchy;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
public class WaveData : ScriptableObject
{
    [Header("ウェーブごとの生成する敵のデータ")]
    [SerializeField] private WaveEnemyCreateData[] waveEnemyCreateDatas;
    public WaveEnemyCreateData[] WaveEnemyCreateDatas {  get { return waveEnemyCreateDatas; } }

    [Header("ウェーブの開始時間")]
    [SerializeField]private float waveStartTime;
    public float WaveStartTime { get { return waveStartTime; } }

    [Header("ウェーブの終了時間")]
    [SerializeField]private float waveFinishTime;
    public float WaveFinishTime { get { return waveFinishTime; } }

    [Header("ウェーブの敵生成間隔")]
    [SerializeField] private float waveEvenyCreateTimeMin;
    public float WaveEvenyCreateTimeMin { get { return waveEvenyCreateTimeMin; } }
    [SerializeField] private float waveEvenyCreateTimeMax;
    public float WaveEvenyCreateTimeMax { get { return waveEvenyCreateTimeMax; } }

    [Header("ウェーブの敵生成数")]
    [SerializeField] private int waveEvenyCreateCountMin;
    public int WaveEvenyCreateCountMin { get { return waveEvenyCreateCountMin; } }
    [SerializeField] private int waveEvenyCreateCountMax;
    public int WaveEvenyCreateCountMax { get { return waveEvenyCreateCountMax; } }

    [Header("ウェーブの敵生成距離")]
    [SerializeField] private int waveEvenyCreateLangeMin;
    public int WaveEvenyCreateLangeMin { get { return waveEvenyCreateLangeMin; } }
    [SerializeField] private int waveEvenyCreateLangeMax;
    public int WaveEvenyCreateLangeMax { get { return waveEvenyCreateLangeMax; } }
}
