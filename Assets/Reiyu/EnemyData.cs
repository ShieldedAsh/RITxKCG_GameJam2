using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("ƒJƒj"), SerializeField]
    private CommonEnemyData crabData;
    public CommonEnemyData CrabData { get => crabData; }

    [Header("ƒ^ƒR"), SerializeField]
    private CommonEnemyData octopusData;
    public CommonEnemyData OctopusData { get => octopusData; }

    [Header("ƒGƒC"), SerializeField]
    private CommonEnemyData rayData;
    public CommonEnemyData RayData { get => rayData; }

    [Header("ƒEƒ~ƒKƒ"), SerializeField]
    private CommonEnemyData seaturtleData;
    public CommonEnemyData SeaturtleData { get => seaturtleData; }
    [Tooltip("—‘‚ðŽY‚Þ”"), SerializeField]
    private int seaturtleLayEggs = 1;
    public int SeaturtleLayEggs { get => seaturtleLayEggs; }
    [Tooltip("—‘‚ðŽY‚ÞŠÔŠu"), SerializeField]
    private float seaturtleLaySpacing = 3.0f;
    public float SeaturtleLaySpacing { get => seaturtleLaySpacing; }
    [Tooltip("›z‰»‚·‚é‚Ü‚Å‚ÌŽžŠÔ"), SerializeField]
    private float seaturtleHatchingSpacing = 3.0f;
    public float SeaturtleHatchingSpacing { get => seaturtleHatchingSpacing; }

    [Header("Žq‹ŸƒEƒ~ƒKƒ"), SerializeField]
    private CommonEnemyData seaturtleBabyData;
    public CommonEnemyData SeaturtleBabyData { get => seaturtleBabyData; }

    [Header("ƒ„ƒhƒJƒŠ"), SerializeField]
    private CommonEnemyData hermitCrabData;
    public CommonEnemyData HermitCrabData { get => hermitCrabData; }
    [Tooltip("Šk‚É‚±‚à‚éŽžŠÔ"), SerializeField]
    private float hermitCrabInvincibleTime = 2.0f;
    public float HermitCrabInvincibleTime { get => hermitCrabInvincibleTime; }
    [Tooltip("Šk‚É‚±‚à‚éŠÔŠu"), SerializeField]
    private float hermitCrabInvincibleSpacing = 5.0f;
    public float HermitCrabInvincibleSpacing { get => hermitCrabInvincibleSpacing; }

    [Header("ƒWƒƒƒR"), SerializeField]
    private CommonEnemyData jacoData;
    public CommonEnemyData JacoData { get => jacoData; }

    [Space(10)]
    [Header("‹¤’Êˆ—")]

    [Header("‚â‚¯‚ÇŽžŠÔ"), SerializeField]
    private float burnTime;
    public float BurnTime { get => burnTime; }

    [Header("‚â‚¯‚Çƒ_ƒ[ƒW"), SerializeField]
    private int burnDamage;
    public int BurnDamage { get => burnDamage; }

    [Header("‚â‚¯‚Çƒ_ƒ[ƒWŠÔŠu"), SerializeField]
    private float burnSpacing;
    public float BurnSpacing { get => burnSpacing; }

    [Header("áƒ‚êŽžŠÔ"), SerializeField]
    private float numbTime;
    public float NumbTime { get => numbTime; }
}

[Serializable]
public class CommonEnemyData
{
    [Tooltip("ƒTƒCƒY"), SerializeField]
    private float size = 1;
    public float Size { get => size; }

    [Tooltip("HP"), SerializeField]
    private int hp = 100;
    public int HP { get => hp; }

    [Tooltip("UŒ‚—Í"), SerializeField]
    private int power = 10;
    public int Power { get => power; }

    [Tooltip("ˆÚ“®‘¬“x"), SerializeField]
    private float moveSpeed = 1.0f;
    public float MoveSpeed { get => moveSpeed; }

    [Tooltip("UŒ‚ŠÔŠu"), SerializeField]
    private float attackInterval = 1;
    public float AttackInterval { get => attackInterval; }

    [Tooltip("UŒ‚‰Â”\‹——£"), SerializeField]
    private float attackArea = 1;
    public float AttackArea { get => attackArea; }
}