using System.Drawing;
using UnityEngine;

public class SlashAttack : AttackBase
{
    public override void Initialize()
    {
        base.Initialize();
        Damage = attackdata.NomalAttackDataSlash.Damage;
        Size = attackdata.NomalAttackDataSlash.Size;
        DestroyTimer = attackdata.NomalAttackDataSlash.DestroyTime;
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
