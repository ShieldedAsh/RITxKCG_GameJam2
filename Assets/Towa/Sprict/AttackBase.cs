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
}
