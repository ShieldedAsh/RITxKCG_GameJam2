using UnityEngine;

public class Crab : EnemyBase
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void SelfUpdate()
    {
        if(tower != null && Mathf.Abs(Vector3.Distance(transform.position, tower.transform.position)) <= AttackArea)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }
}
