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
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }
}
