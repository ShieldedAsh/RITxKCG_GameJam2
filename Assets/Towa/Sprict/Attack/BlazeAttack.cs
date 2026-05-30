using UnityEngine;

public class BlazeAttack : AttackBase
{
    public override void Initialize()
    {
        base.Initialize();
        Damage = attackdata.NomalAttackDataBlaze.Damage;
        Size = attackdata.NomalAttackDataBlaze.Size;
        DestroyTimer = attackdata.NomalAttackDataBlaze.DestroyTime;
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }
}
