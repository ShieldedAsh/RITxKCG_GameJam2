using System.Drawing;
using UnityEngine;

public class BoomAttack : AttackBase
{
    public override void Initialize()
    {
        base.Initialize();
        Damage = attackdata.NomalAttackDataBoom.Damage;
        Size = attackdata.NomalAttackDataBoom.Size;
        DestroyTimer = attackdata.NomalAttackDataBoom.DestroyTime;
        transform.localScale = new Vector3(Size, Size, Size);
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }

    protected override void OnEnemyEnter(EnemyBase enemy)
    {
        enemy.TakeDamage((int)Damage);
    }
}
