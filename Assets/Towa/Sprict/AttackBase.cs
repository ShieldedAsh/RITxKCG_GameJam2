using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    // アタックデータ
    [SerializeField]
    protected AttackData attackdata;
    // 破壊フラグ
    private bool destroyFlag;
    public bool DestroyFlag { get { return destroyFlag; } set { destroyFlag = value; } }

    // ダメージ
    private float damage;
    public float Damage { get { return damage; } set { damage = value; } }

    // 円の直径
    private float size;
    public float Size { get { return size; } set { size = value; } }

    // 破壊までのタイマー
    private float destroyTimer;
    public float DestroyTimer { get { return destroyTimer; } set { destroyTimer = value; } }

    // タイマー
    protected Timer timer;

    [SerializeField]
    private LayerMask enemyLayer;

    /// <summary>
    /// 初期化
    /// </summary>
    virtual public void Initialize()
    {
        timer = new Timer();
        timer.Initialize();
        DestroyFlag = false;
        Damage = 0;
        Size = 1;
        destroyTimer = 1;
        
    }


    /// <summary>
    /// 更新処理
    /// </summary>
    virtual public void MyUpdate()
    {
        timer.UpdateTick();

        if (destroyTimer <= timer.GetCurrentTime())
        {
            AttackManager.Instance.Unregister(this);
        }
    }

    // 接触時に送られるイベント
    protected virtual void OnEnemyEnter(EnemyBase enemy) { }
    protected virtual void OnEnemyStay(EnemyBase enemy) { }
    protected virtual void OnEnemyExit(EnemyBase enemy) { }

    /// <summary>
    /// 敵との接触時処理
    /// </summary>
    /// <param name="other">接触したコライダー</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsEnemy(other.gameObject))
        {
            var enemy = other.GetComponent<EnemyBase>();
            if (enemy != null)
                OnEnemyEnter(enemy);
        }
    }

    /// <summary>
    /// 敵との接触中処理
    /// </summary>
    /// <param name="other">接触したコライダー</param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsEnemy(other.gameObject))
        {
            var enemy = other.GetComponent<EnemyBase>();
            if (enemy != null)
                OnEnemyStay(enemy);
        }
    }

    /// <summary>
    /// 敵との接触終了処理
    /// </summary>
    /// <param name="other">接触したコライダー</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsEnemy(other.gameObject))
        {
            var enemy = other.GetComponent<EnemyBase>();
            if (enemy != null)
                OnEnemyExit(enemy);
        }
    }

    /// <summary>
    /// 敵レイヤー検知
    /// </summary>
    /// <param name="obj">接触したオブジェクト</param>
    private bool IsEnemy(GameObject obj)
    {
        return (enemyLayer.value & (1 << obj.layer)) != 0;
    }
}
