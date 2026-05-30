using UnityEngine;

public class Egg : MonoBehaviour
{
    [Header("子供ウミガメのプレハブ"), SerializeField]
    private GameObject seaturtleBabyPrefab;

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
        EnemyManager.Instance.AddEgg(this);
    }

    public void SelfUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= layTime)
        {
            GameObject baby = Instantiate(seaturtleBabyPrefab, transform.position, Quaternion.identity);
            baby.GetComponent<EnemyBase>().Initialize();
            Destroy(gameObject);
        }
    }
}
