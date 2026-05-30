using UnityEngine;

public class Ray : EnemyBase
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void SelfUpdate()
    {
        if(target != null && Vector3.Distance(transform.position, target.position) <= AttackArea)
        {
            Attack();
        }
        else
        {
            Move();
        }        
    }
}
