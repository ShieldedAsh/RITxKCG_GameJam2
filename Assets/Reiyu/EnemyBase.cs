using UnityEngine;

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

public abstract class EnemyBase : MonoBehaviour
{
    [Header("敵データ"), SerializeField]
    protected EnemyData enemyData;

    [Header("敵の種類"), SerializeField]
    protected EnemyKind kind;


    public float Size { get; private set; }
    public int HP{ get;set; }
    public int Power { get; private set; }
    public float MoveSpeed { get; private set; }
    public float AttackInterval { get; private set; }
    public float AttackArea { get; private set; }

    /// <summary>
    /// 塔
    /// </summary>
    protected Tower tower;

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

        Size = data.Size;
        HP = data.HP;
        Power = data.Power;
        MoveSpeed = data.MoveSpeed;
        AttackInterval = data.AttackInterval;
        AttackArea = data.AttackArea;  
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public abstract void SelfUpdate();

    /// <summary>
    /// 移動
    /// </summary>
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, tower.transform.position, MoveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    public void Attack()
    {
        tower.TakeDamage(Power);
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddTower(Tower _tower)
    {
        tower = _tower;
    }
}
