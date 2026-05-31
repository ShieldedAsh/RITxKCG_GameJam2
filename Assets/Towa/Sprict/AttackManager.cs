using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Dokan,
    BiriBiri,
    MeraMera,
    SupaSups,
    kyuin,
    nyokinyoki
}

[System.Serializable]
public class AttackEntry
{
    public AttackType type;
    public AttackBase prefab;
}

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private AttackEntry[] attackEntries;

    [SerializeField] private int asasa;

    //インスタンス
    private static AttackManager instance;
    public static AttackManager Instance { get { return instance; } }

    // 攻撃のプレファブ
    private Dictionary<AttackType, AttackBase> attackPrefab;

    // アタックのリスト
    private List<AttackBase> attacks;

    // このフレームでオブジェクトを破壊するかのフラグ
    private bool destroyFlagObject;

    private void Awake()
    {
        instance = this;
        attacks = new List<AttackBase>();
        attackPrefab = new Dictionary<AttackType, AttackBase>();

        foreach (var entry in attackEntries)
            attackPrefab[entry.type] = entry.prefab;
    }

    void Start()
    {
        
    }

    void Update()
    {
        foreach(var attack in attacks)
        {
            if(attack != null && !attack.DestroyFlag)
                attack.MyUpdate();
        }

        asasa = attacks.Count;
        if (destroyFlagObject)
            DestoryFlagObjects();
    }
    
    /// <summary>
    /// アタックの生成
    /// </summary>
    /// <param name="attackTyoe">アタックの種類</param>
    /// <param name="pos">座標</param>
    /// <returns>インスタンス</returns>
    public AttackBase CreateAttack(AttackType attackTyoe,Vector3 pos)
    {
        var attack = Instantiate(attackPrefab[attackTyoe]);
        attack.transform.position = pos;
        Register(attack);
        attack.Initialize();
        return attack;
    }

    /// <summary>
    /// 登録
    /// </summary>
    /// <param name="attack">アタック</param>
    public void Register(AttackBase attack)
    {
        attacks.Add(attack);
    }

    /// <summary>
    /// 登録解除
    /// </summary>
    /// <param name="attack">アタック</param>
    public void Unregister(AttackBase attack)
    {
        attack.DestroyFlag = true;
        destroyFlagObject = true;
    }

    /// <summary>
    /// フラグのついたオブジェクトを削除
    /// </summary>
    private void DestoryFlagObjects()
    {
        foreach (var attack in attacks)
        {
            if (attack != null)
            if (attack.DestroyFlag)
                Destroy(attack.gameObject);
        }

        attacks.RemoveAll(a => a.DestroyFlag);
        destroyFlagObject = false;
    }
}
