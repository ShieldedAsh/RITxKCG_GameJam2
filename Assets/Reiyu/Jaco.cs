using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Jaco : EnemyBase
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void SelfUpdate()
    {
        if (tower == null) return;

        if(Vector3.Distance(transform.position, tower.transform.position) <= AttackArea)
        {
            Attack();
        }
        else
        {
            Move();
        }        
    }
}
