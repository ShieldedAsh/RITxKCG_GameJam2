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
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }
}
