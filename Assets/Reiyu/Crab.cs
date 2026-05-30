using UnityEngine;

public class Crab : EnemyBase
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void SelfUpdate()
    {
        if(tower != null && Vector3.Distance(transform.position, tower.transform.position) <= AttackArea)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }
}
