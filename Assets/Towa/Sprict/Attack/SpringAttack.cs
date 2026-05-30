using System.Drawing;
using UnityEngine;

public class SpringAttack : AttackBase
{
    public override void Initialize()
    {
        base.Initialize();
        Damage = attackdata.NomalAttackDataSpring.Damage;
        Size = attackdata.NomalAttackDataSpring.Size;
        DestroyTimer = attackdata.NomalAttackDataSpring.DestroyTime;
        transform.localScale = new Vector3(Size, Size, Size);
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }

    protected override void OnEnemyStay(EnemyBase enemy)
    {
        //‚¢‚Á‚½‚ñ‚±‚ê‚Å
        enemy.TakeDamage(1);
    }
}
