using System.Drawing;
using UnityEngine;

public class WhooshAttack : AttackBase
{
    private float whooshPower = 0;
    public override void Initialize()
    {
        base.Initialize();
        whooshPower = attackdata.WhooshPower;
        Damage = attackdata.NomalAttackDataWhoosh.Damage;
        Size = attackdata.NomalAttackDataWhoosh.Size;
        DestroyTimer = attackdata.NomalAttackDataWhoosh.DestroyTime;
        transform.localScale = new Vector3(Size, Size, Size);
    }
    public override void MyUpdate()
    {
        base.MyUpdate();
    }

    protected override void OnEnemyStay(EnemyBase enemy)
    {
        Rigidbody2D enemyRb2 = enemy.GetComponent<Rigidbody2D>();

        Vector2 dir = (transform.position - enemy.transform.position).normalized;
        enemyRb2.AddForce(dir * whooshPower, ForceMode2D.Force);
    }
}
