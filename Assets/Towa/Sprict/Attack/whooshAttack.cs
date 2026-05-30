using System.Drawing;
using UnityEngine;

public class WhooshAttack : AttackBase
{
    public override void Initialize()
    {
        base.Initialize();
        Damage = attackdata.NomalAttackDataWhoosh.Damage;
        Size = attackdata.NomalAttackDataWhoosh.Size;
        DestroyTimer = attackdata.NomalAttackDataWhoosh.DestroyTime;
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }
}
