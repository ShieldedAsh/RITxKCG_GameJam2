using UnityEngine;

public class Crab : EnemyBase
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void SelfUpdate()
    {
        if (tower == null) return;

        base.SelfUpdate();

        if (isNumb == true) return;

        if (Mathf.Abs(Vector3.Distance(transform.position, tower.transform.position)) <= AttackArea)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }
}
