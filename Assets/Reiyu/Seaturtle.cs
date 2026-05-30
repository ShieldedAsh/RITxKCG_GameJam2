using UnityEngine;

public class Seaturtle : EnemyBase
{

    [Header("—‘‚ÌƒvƒŒƒnƒu"), SerializeField]
    private Egg eggPrefab;

    /// <summary>
    /// Y‚Ş—‘‚Ì”
    /// </summary>
    private int layEggs;
    /// <summary>
    /// —‘‚ğY‚ŞŠÔŠu
    /// </summary>
    private float laySpacing = 0;
    /// <summary>
    /// ›z‰»‚·‚é‚Ü‚Å‚ÌŠÔ
    /// </summary>
    private float hatchingSpacing = 0;

    /// <summary>
    /// Œo‰ßŠÔ
    /// </summary>
    private float timer = 0;

    public override void Initialize()
    {
        timer = 0;
        base.Initialize();
        layEggs = enemyData.SeaturtleLayEggs;
        hatchingSpacing = enemyData.SeaturtleHatchingSpacing;
        laySpacing = enemyData.SeaturtleLaySpacing;
    }

    public override void SelfUpdate()
    {
        if (tower == null) return;

        base.SelfUpdate();

        timer += Time.deltaTime;

        if (isNumb == true) return;

        if (Vector3.Distance(transform.position, tower.transform.position) <= AttackArea)
        {
            Attack();
        }
        else if(timer >= laySpacing)
        {
            LayEggs();
            timer = 0;
        }
        else
        {
            Move();
        }        
    }

    private void LayEggs()
    {
        for(int i = 0; i < layEggs; i++)
        {
            Egg egg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
            egg.Initialize(hatchingSpacing);
        }
    }

}
