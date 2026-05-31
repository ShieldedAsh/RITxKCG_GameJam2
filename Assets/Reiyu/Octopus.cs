using UnityEngine;

public class Octopus : EnemyBase
{
    public override void Initialize()
    {
        base.Initialize();

        imageRotOffset = 180;
    }

    public override void SelfUpdate()
    {
        if (tower == null) return;

        base.SelfUpdate();

        if (isNumb == true) return;

        if (Vector3.Distance(transform.position, tower.transform.position) <= AttackArea)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }
}
