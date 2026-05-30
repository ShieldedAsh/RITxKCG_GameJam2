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
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }
}
