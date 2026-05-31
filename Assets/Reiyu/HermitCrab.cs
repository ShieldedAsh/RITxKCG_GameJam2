using UnityEngine;

public class HermitCrab : EnemyBase
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

        //¶‘¤‚È‚ç‰æ‘œ‚ğ”½“]‚·‚é
        if (tower.transform.position.x > transform.position.x)
        {
            var scale = imageObj.transform.localScale;
            scale.y *= -1;
            imageObj.transform.localScale = scale;
        }
        imageRotOffset = -90;
    }

    public override void SelfUpdate()
    {
        if (tower == null) return;

        base.SelfUpdate();

        if (isNumb == true) return;

        // Šk‚É‚±‚à‚Á‚Ä‚¢‚éê‡
        if (isInvincible)
        {
            invincibleTimer += Time.deltaTime;
            if (invincibleTimer >= invincibleTime)
            {
                //F–ß‚µ
                var renderer = imageObj.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    renderer.color = Color.white;
                }

                isInvincible = false;
                invincibleTimer = 0;
            }
            return;
        }

        // Šk‚É‚±‚à‚ç‚È‚¢ê‡
        timer += Time.deltaTime;
        if (timer >= invincibleSpacing)
        {
            //F‘Ö‚¦
            var renderer = imageObj.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.color = Color.blue;
            }

            isInvincible = true;
            timer = 0;
        }

        // UŒ‚‰Â”\‚Èê‡
        if (Vector3.Distance(transform.position, tower.transform.position) <= AttackArea)
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
        if (isInvincible)
        {
            return;
        }
        base.TakeDamage(damage);
    }
}
