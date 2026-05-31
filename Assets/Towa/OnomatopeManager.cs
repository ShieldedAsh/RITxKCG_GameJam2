using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnomatopeEntry
{
    public AttackType type;
    public OnomatopeBase prefab;
}

public class OnomatopeManager : MonoBehaviour
{
    [SerializeField]
    private OnomatopeEntry[] onomatopeEntries;

    [SerializeField] private int asasa;

    //インスタンス
    private static OnomatopeManager instance;
    public static OnomatopeManager Instance { get { return instance; } }

    // 攻撃のプレファブ
    private Dictionary<AttackType, OnomatopeBase> onomatopePrefab;

    // アタックのリスト
    private List<OnomatopeBase> onomatopes;

    // このフレームでオブジェクトを破壊するかのフラグ
    private bool destroyFlagObject;

    private void Awake()
    {
        instance = this;
        onomatopes = new List<OnomatopeBase>();
        onomatopePrefab = new Dictionary<AttackType, OnomatopeBase>();

        foreach (var entry in onomatopeEntries)
            onomatopePrefab[entry.type] = entry.prefab;
    }

    void Update()
    {
        foreach (var onomatope in onomatopes)
        {
            if (onomatope != null && !onomatope.DestroyFlag)
                onomatope.MyUpdate();
        }

        asasa = onomatopes.Count;
        if (destroyFlagObject)
            DestoryFlagObjects();
    }

    /// <summary>
    /// アタックの生成
    /// </summary>
    /// <param name="onomatopeTyoe">アタックの種類</param>
    /// <param name="pos">座標</param>
    /// <returns>インスタンス</returns>
    public OnomatopeBase CreateOnomatope(AttackType onomatopeTyoe, Vector3 pos)
    {
        var onomatope = Instantiate(onomatopePrefab[onomatopeTyoe]);
        onomatope.transform.position = pos;
        Register(onomatope);
        onomatope.Initialize();
        return onomatope;
    }

    /// <summary>
    /// 登録
    /// </summary>
    /// <param name="onomatope">アタック</param>
    public void Register(OnomatopeBase onomatope)
    {
        onomatopes.Add(onomatope);
    }

    /// <summary>
    /// 登録解除
    /// </summary>
    /// <param name="onomatope">アタック</param>
    public void Unregister(OnomatopeBase onomatope)
    {
        onomatope.DestroyFlag = true;
        destroyFlagObject = true;
    }

    /// <summary>
    /// フラグのついたオブジェクトを削除
    /// </summary>
    private void DestoryFlagObjects()
    {
        foreach (var onomatope in onomatopes)
        {
            if (onomatope != null)
                if (onomatope.DestroyFlag)
                    Destroy(onomatope.gameObject);
        }

        onomatopes.RemoveAll(a => a.DestroyFlag);
        destroyFlagObject = false;
    }

    public OnomatopeBase CreateOnomatope(OnomatopeBase type,Vector2 createPos)
    {
        var obj = Instantiate(type, new Vector3(createPos.x, createPos.y, 0), Quaternion.identity);
        Register(obj);
        obj.Initialize();

        return obj;
    }
}