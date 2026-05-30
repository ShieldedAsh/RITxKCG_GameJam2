using System.Drawing;
using UnityEngine;

public class BlazeAttack : AttackBase
{
    public override void Initialize()
    {
        base.Initialize();
        Damage = attackdata.NomalAttackDataBlaze.Damage;
        Size = attackdata.NomalAttackDataBlaze.Size;
        DestroyTimer = attackdata.NomalAttackDataBlaze.DestroyTime;
        transform.localScale = new Vector3(Size, Size, Size);
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }
    protected override void OnEnemyEnter(EnemyBase enemy)
    {
        enemy.CauseBurn();
    }
}
