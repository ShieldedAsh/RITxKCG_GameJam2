using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Scriptable Objects/AttackData")]
public class AttackData : ScriptableObject
{
    [Header("どかん")]
    [SerializeField]
    private NomalAttackData nomalAttackDataBoom;
    public NomalAttackData NomalAttackDataBoom {  get { return nomalAttackDataBoom; }}

    [Header("びりびり")]
    [SerializeField]
    private NomalAttackData nomalAttackDataZap;
    public NomalAttackData NomalAttackDataZap { get { return nomalAttackDataZap; } }

    [Header("めらめら")]
    [SerializeField]
    private NomalAttackData nomalAttackDataBlaze;
    public NomalAttackData NomalAttackDataBlaze { get { return nomalAttackDataBlaze; } }

    [Header("すぱすぱ")]
    [SerializeField]
    private NomalAttackData nomalAttackDataSlash;
    public NomalAttackData NomalAttackDataSlash { get { return nomalAttackDataSlash; } }

    [Header("きゅいーん")]
    [SerializeField]
    private NomalAttackData nomalAttackDataWhoosh;
    public NomalAttackData NomalAttackDataWhoosh { get { return nomalAttackDataWhoosh; } }

    [Header("にょきにょき")]
    [SerializeField]
    private NomalAttackData nomalAttackDataSpring;
    public NomalAttackData NomalAttackDataSpring { get { return nomalAttackDataSpring; } }
}

[Serializable]
public class NomalAttackData
{
    [Header("サイズ")]
    [SerializeField]
    private float size;
    public float Size { get => size; }

    [Header("攻撃力")]
    [SerializeField]
    private int damage;
    public int Damage { get => damage; }

    [Header("消えるまでの秒数")]
    [SerializeField]
    private float destroyTime;
    public float DestroyTime { get => destroyTime; }
    /*
    [Tooltip("タイプ")]
    [SerializeField]
    private AttackType type;
    public AttackType Type { get => Type; }
    */
}