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
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }
}
