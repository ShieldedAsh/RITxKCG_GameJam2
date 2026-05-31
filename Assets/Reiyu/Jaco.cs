using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Jaco : EnemyBase
{
    public override void Initialize()
    {
        base.Initialize();

        //‰E‘¤‚È‚ç‰æ‘œ‚ð”½“]‚·‚é
        if (tower.transform.position.x < transform.position.x)
        {
            var scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        }

        imageRotOffset = 90;
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
