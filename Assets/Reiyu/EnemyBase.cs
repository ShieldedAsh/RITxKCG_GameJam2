using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum EnemyKind
{
    /// <summary>
    /// カニ
    /// </summary>
    CRAB,
    /// <summary>
    /// タコ
    /// </summary>
    OCTOPUS,
    /// <summary>
    /// エイ
    /// </summary>
    RAY,
    /// <summary>
    /// ウミガメ
    /// </summary>
    SEATURTLE,
    /// <summary>
    /// ヤドカリ
    /// </summary>
    HERMITCRAB,
    /// <summary>
    /// ジャコ
    /// </summary>
    JACO,
    /// <summary>
    /// 子供ウミガメ
    /// </summary>
    SEATURTLEBABY,
}

public class EnemyBase : MonoBehaviour
{
    [Header("敵データ"), SerializeField]
    protected EnemyData enemyData;

    [Header("敵の種類"), SerializeField]
    protected EnemyKind kind;

    protected float imageRotOffset;

    //アニメータ
    protected Animator animator;

    public int HP { get; set; }
    public int Power { get; private set; }
    public float MoveSpeed { get; private set; }
    public float AttackInterval { get; private set; }
    public float AttackArea { get; private set; }

    protected float attackTimer;

    /// <summary>
    /// 塔
    /// </summary>
    protected Tower tower;

    /// <summary>
    /// 痺れている
    /// </summary>
    protected bool isNumb;
    protected float numbTimer;

    /// <summary>
    /// やけどしている
    /// </summary>
    protected bool isBurn;
    protected int burnDamage;           //やけどダメージ
    protected float burnSpacing;        //やけどダメージ間隔
    protected float burnTimer;          //やけど時間計測
    protected int burnDamageNum;      //ダメージ回数

    /// <summary>
    /// 初期化
    /// </summary>
    public virtual void Initialize()
    {
        EnemyManager.Instance.AddEnemy(this);

        CommonEnemyData data;

        //種類に合わせてデータを設定
        switch (kind)
        {
            case EnemyKind.CRAB:
                data = enemyData.CrabData;
                break;
            case EnemyKind.OCTOPUS:
                data = enemyData.OctopusData;
                break;
            case EnemyKind.RAY:
                data = enemyData.RayData;
                break;
            case EnemyKind.SEATURTLE:
                data = enemyData.SeaturtleData;
                break;
            case EnemyKind.SEATURTLEBABY:
                data = enemyData.SeaturtleBabyData;
                break;
            case EnemyKind.HERMITCRAB:
                data = enemyData.HermitCrabData;
                break;
            case EnemyKind.JACO:
                data = enemyData.JacoData;
                break;
            default:
                data = enemyData.CrabData;
                break;
        }

        //ステータス初期化
        transform.localScale *= data.Size;
        HP = data.HP;
        Power = data.Power;
        MoveSpeed = data.MoveSpeed;
        AttackInterval = data.AttackInterval;
        AttackArea = data.AttackArea;
        //一回目は近づいたら攻撃できるようにしておく
        attackTimer = AttackInterval;

        animator = GetComponent<Animator>();

        //状態異常初期化
        isNumb = false;
        numbTimer = 0;
        isBurn = false;
        burnTimer = 0;
        burnDamage = enemyData.BurnDamage;
        burnSpacing = enemyData.BurnSpacing;
        burnDamageNum = (int)(enemyData.BurnTime / burnSpacing);

        imageRotOffset = 0;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public virtual void SelfUpdate()
    {
        attackTimer += Time.deltaTime;

        if (isBurn)
        {
            BurnUpdate();
        }

        if (isNumb)
        {
            NumbUpdate();
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    protected void Move()
    {
        Vector2 dir = tower.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90 + imageRotOffset);

        transform.position = Vector3.MoveTowards(transform.position, tower.transform.position, MoveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    protected void Attack()
    {
        if (attackTimer > AttackInterval)
        {
            animator.Play("Attack");
            tower.TakeDamage(Power);
            attackTimer = 0;
        }
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddTower(Tower _tower)
    {
        tower = _tower;
    }

    protected void BurnUpdate()
    {
        burnTimer += Time.deltaTime;

        //やけどダメージ間隔を過ぎたらダメージを受ける
        if (burnTimer > burnSpacing)
        {
            TakeDamage(burnDamage);
            burnDamageNum--;
            burnTimer = 0;
            //やけどダメージ回数が終了したらやけど状態を解除する
            if (burnDamageNum <= 0)
            {
                isBurn = false;
                return;
            }
        }
    }

    protected void NumbUpdate()
    {
        numbTimer += Time.deltaTime;

        //痺れ時間が終了したら痺れ状態を解除する
        if (numbTimer >= enemyData.NumbTime)
        {
            isNumb = false;
            numbTimer = 0;
        }
    }

    /// <summary>
    /// やけど状態にする
    /// </summary>
    public void CauseBurn()
    {
        isBurn = true;
        burnTimer = 0;
    }

    /// <summary>
    /// 痺れ状態にする
    /// </summary>
    public void CauseNumb()
    {
        isNumb = true;
        numbTimer = 0;
    }
}
