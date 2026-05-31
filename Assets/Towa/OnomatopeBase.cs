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

    private Vector3 offSetPos;
    public Vector3 OffsetPos { get { return offSetPos; } }

    private SpriteRenderer render;

    // タイマー
    protected Timer timer;

    /// <summary>
    /// 初期化
    /// </summary>
    virtual public void Initialize()
    {
        render = GetComponent<SpriteRenderer>();
        timer = new Timer();
        timer.Initialize();
        DestroyFlag = false;
        Size = onomatopeData.Size;
        offSetPos = onomatopeData.OffseyPos;
        destroyTimer = onomatopeData.DestroyTime;
        transform.position += OffsetPos;
        transform.localScale = new Vector3(Size, Size, Size);
        var c = render.color;
        c.a = 0f;
        render.color = c;
    }


    /// <summary>
    /// 更新処理
    /// </summary>
    virtual public void MyUpdate()
    {
        timer.UpdateTick();

        var c = render.color;
        float a = c.a;

        if (DestroyTimer <= timer.GetCurrentTime())
        {
                a -= 5f * Time.deltaTime;
        }
        else
        {
                a += 5f * Time.deltaTime;
        }

        c.a = Mathf.Clamp01(a);
        render.color = c;

        if (c.a <= 0f)
        {
            OnomatopeManager.Instance.Unregister(this);
        }
    }
}
