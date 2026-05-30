using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ウェーブクラス
/// </summary>
public class Wave : MonoBehaviour
{
    // ウェーブのごとのデータ
    [Header("ウェーブのスプリクタブルオブジェクトデータ")]
    [SerializeField] WaveData waveData;
    // スタート時間
    private float startTime;

    // 終了時間
    private float finishTime;

    // 生成フラグ
    protected bool isCreating;

    // 最後に生成した時間
    private float lastCreateTime;

    // 敵のデータ
    private WaveEnemyCreateData[] enemyCreateData;

    // 敵生成数
    protected int createCountMax;
    protected int createCountMin;

    // 敵生距離
    private int createLangeMin;
    private int createLangeMax;

    // 敵の現在生成数
    private int createCount;

    // 敵の生成間隔
    private float createTimerMax;
    private float createTimerMin;

    // 次の生成間隔
    private float nextCreateTime;

    // 追加の敵生成数
    private int addEnemyCreate;

    // タイマー
    private Timer timer;
    public Timer GetTimer { get { return timer; } }

    // 敵の生成闘値
    List<int> raitoBattleValue = new List<int>();

    // 確率の合計
    int raitoAll = 0;

    /// <summary>
    /// 初期化処理
    /// </summary>
    virtual public void Initialize()
    {
        // 初期化
        timer = new Timer();
        timer.Initialize();
        enemyCreateData = waveData.WaveEnemyCreateDatas;
        startTime = waveData.WaveStartTime;
        finishTime = waveData.WaveFinishTime;
        createCountMax = waveData.WaveEvenyCreateCountMax;
        createCountMin = waveData.WaveEvenyCreateCountMin;
        createTimerMax = waveData.WaveEvenyCreateTimeMax;
        createTimerMin = waveData.WaveEvenyCreateTimeMin;
        createLangeMax = waveData.WaveEvenyCreateLangeMax;
        createLangeMin = waveData.WaveEvenyCreateLangeMin;
        isCreating = false;
        addEnemyCreate = 0;

        // 初期確立をセット
        createCount = Random.Range(createCountMin, createCountMax);
        nextCreateTime = Random.Range(createTimerMin, createTimerMax);
        // 敵の確率合計をセット
        foreach (var enemyData in enemyCreateData)
        {
            raitoAll += enemyData.createRatio;
            // 確率の合計を求める
            raitoBattleValue.Add(enemyData.createRatio);
        }
    }

    /// <summary>
    /// 自身の更新処理
    /// </summary>
    virtual public void MyUpdate()
    {
        timer.UpdateTick();
        UpdateCreateFlag();
        UpdateCreateObjectCount();
    }

    /// <summary>
    /// 敵の生成カウント
    /// </summary>
    private void UpdateCreateObjectCount()
    {
        // ウェーブを実行する時間出なければreturn
        if (!isCreating) return;

        // 敵を生成出来る状況かのチェック
        if (timer.GetCurrentTime() - lastCreateTime >= nextCreateTime)
        {
            // 生成タイムを更新
            lastCreateTime = timer.GetCurrentTime();

            // 生成秒数の更新
            nextCreateTime = Random.Range(createTimerMin, createTimerMax);

            // 敵の生成
            CreateAllWaveEnemy();
        }
    }

    /// <summary>
    /// 生成フラグの更新
    /// </summary>
    private void UpdateCreateFlag()
    {
        if (timer.GetCurrentTime() <= finishTime && timer.GetCurrentTime() >= startTime)
        {
            isCreating = true;
            return;
        }
        isCreating = false;
    }

    /// <summary>
    /// 敵の生成
    /// </summary>
    private void CreateAllWaveEnemy()
    {
        
        createCount = Random.Range(createCountMin,createCountMax + 1);

        // 最低保証を引いた敵の生成数
        int createEnemyCount = createCount;

        foreach (var enemyData in enemyCreateData)
        {
            //最低保証を生成
            for (int i = 0; i < enemyData.createMin; i++)
            {
                CreateEnemy(enemyData.enemyType, CreateCreatePos());

                //その分確率の生成数を減らす
                createEnemyCount--;
            }
        }

        for (int i = 0; i < createEnemyCount; i++)
        {
            // 生成された乱数
            int enemyRand = Random.Range(0, raitoAll + 1);
            // 闘値の合計
            int battleValueSum = 0;
            for (int j = 0; j < enemyCreateData.Count(); j++)
            {
                battleValueSum += enemyCreateData[j].createRatio;
                if (battleValueSum >= enemyRand)
                {

                    CreateEnemy(enemyCreateData[j].enemyType, CreateCreatePos());
                    break;
                }
            }
        }
    }
        
    // EnemyCreatorに移行したい
        



    /// <summary>
    /// 生成座標の生成
    /// </summary>
    /// <returns></returns>
    public Vector2 CreateCreatePos()
    {
        float rad = Random.Range(0, 359) * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        float lange = Random.Range(createLangeMin, createLangeMax);
        Vector2 pos = new Vector2(sin * lange, cos * lange);
        return pos;
    }

    /// <summary>
    /// 敵の生成
    /// </summary>
    /// <param name="type">敵のタイプ</param>
    /// <param name="pos">生成座標</param>
    /// <returns>生成した敵</returns>
    public EnemyBase CreateEnemy(EnemyBase type, Vector2 pos)
    {
        var obj = Instantiate(type, new Vector3(pos.x, pos.y, 0), Quaternion.identity);

        obj.Initialize();

        return obj;
    }
}