using UnityEngine;

public class HermitCrab: EnemyBase
{
    /// <summary>
    /// Šk‚É‚±‚à‚éŠÔ
    /// </summary>
    private float invincibleTime = 0;
    /// <summary>
    /// Šk‚É‚±‚à‚éŠÔŠu
    /// </summary>
    private float invincibleSpacing = 0;
    
    /// <summary>
    /// Œo‰ßŠÔ
    /// </summary>
    private float timer = 0;
    /// <summary>
    /// Šk‚É‚±‚à‚Á‚Ä‚¢‚éŠÔ
    /// </summary>
    private float invincibleTimer = 0;

    /// <summary>
    /// Šk‚É‚±‚à‚Á‚Ä‚¢‚é‚©
    /// </summary>
    private bool isInvincible = false;

    public override void Initialize()
    {
        timer = 0;
        base.Initialize();
        invincibleTime = enemyData.HermitCrabInvincibleTime;
        invincibleSpacing = enemyData.HermitCrabInvincibleSpacing;
    }

    public override void SelfUpdate()
    {
        // Šk‚É‚±‚à‚Á‚Ä‚¢‚éê‡
        if(isInvincible)
        {
            invincibleTimer += Time.deltaTime;
            if(invincibleTimer >= invincibleTime)
            {
                isInvincible = false;
                invincibleTimer = 0;
            }
            return;
        }

        // Šk‚É‚±‚à‚ç‚È‚¢ê‡
        timer += Time.deltaTime;
        if(timer >= invincibleSpacing)
        {
            isInvincible = true;
            timer = 0;
        }

        // UŒ‚‰Â”\‚Èê‡
        if(target != null && Vector3.Distance(transform.position, target.position) <= AttackArea)
        {
            Attack();
        }
        else
        {
            Move();
        }        
    }

    public override void TakeDamage(int damage)
    {
        if(isInvincible)
        {
            return;
        }
        base.TakeDamage(damage);
    }
}
