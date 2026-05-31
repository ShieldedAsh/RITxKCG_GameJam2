using UnityEngine;

public class OnomatopeBase : MonoBehaviour
{
    [SerializeField] OnomatopeData onomatopeData;
    // 破壊フラグ
    private bool destroyFlag;
    public bool DestroyFlag { get { return destroyFlag; } set { destroyFlag = value; } }

    private float size;
    public float Size { get { return size; } set { size = value; } }

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
        Size = onomatopeData.Size;
        destroyTimer = onomatopeData.DestroyTime;

    }


    /// <summary>
    /// 更新処理
    /// </summary>
    virtual public void MyUpdate()
    {
        timer.UpdateTick();

        if (destroyTimer <= timer.GetCurrentTime())
        {
            OnomatopeManager.Instance.Unregister(this);
        }
    }
}
