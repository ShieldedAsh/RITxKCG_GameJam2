using System.Drawing;
using UnityEngine;

public class ZapAttack : AttackBase
{
    public override void Initialize()
    {
        base.Initialize();
        Damage = attackdata.NomalAttackDataZap.Damage;
        Size = attackdata.NomalAttackDataZap.Size;
        DestroyTimer = attackdata.NomalAttackDataZap.DestroyTime;
        transform.localScale = new Vector3(Size, Size, Size);
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }

    protected override void OnEnemyEnter(EnemyBase enemy)
    {
        enemy.CauseNumb();
    }
}
