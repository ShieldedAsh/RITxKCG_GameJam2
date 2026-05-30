using UnityEngine;

public class Egg : MonoBehaviour
{
    [Header("子供ウミガメのプレハブ"), SerializeField]
    private EnemyBase seaturtleBabyPrefab;

    /// <summary>
    /// 生まれる時間
    /// </summary>
    private float layTime = 0;
    /// <summary>
    /// 経過時間
    /// </summary>
    private float timer = 0;

    public void Initialize(float time)
    {
        layTime = time;
    }

    public void SelfUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= layTime)
        {
            EnemyBase baby = Instantiate(seaturtleBabyPrefab, transform.position, Quaternion.identity);
            baby.Initialize();
            Destroy(gameObject);
        }
    }
}
