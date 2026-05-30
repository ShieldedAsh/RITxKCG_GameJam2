using UnityEngine;

public class FinalWave : Wave
{
    // 最後に敵を増やした時のタイマー
    private float lastAddEnemyTimer;

    // 増加の間隔
    [SerializeField]private float addTimer;
    /// <summary>
    /// 初期化
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();
        lastAddEnemyTimer = 0;

    }

    /// <summary>
    /// 更新
    /// </summary>
    public override void MyUpdate()
    {
        base.MyUpdate();
        if (!isCreating)
        {
            lastAddEnemyTimer = GetTimer.GetCurrentTime();
        }
        if (GetTimer.GetCurrentTime() > lastAddEnemyTimer + addTimer) 
        {
            createCountMax += 5;
            createCountMin += 5;
            lastAddEnemyTimer = GetTimer.GetCurrentTime();
        }
    }
}
