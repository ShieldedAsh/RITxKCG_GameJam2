using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField]
    private EnemyCreatorData enemyCreatorData;
    // 生成座標
    private Vector2 createPos;

    // オフセット座標
    private Vector2 offsetPos;

    // 生成の距離最短
    private float createLangeMin;
    // 生成の距離最長
    private float createLangeMax;

    private void Start()
    {
        createPos = transform.position;
        offsetPos = enemyCreatorData.OffsetPos;
        createLangeMin = enemyCreatorData.CreateLangeMin;
        createLangeMax = enemyCreatorData.CreateLangeMax;
    }

    /// <summary>
    /// 生成座標の生成
    /// </summary>
    /// <returns></returns>
    public Vector2 CreateCreatePos()
    {
        float rad = Random.Range(0, 359) * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        float lange = Random.Range(createLangeMin, createLangeMax);
        Vector2 pos = new Vector2(sin * lange, cos * lange);
        return pos;
    }

    /// <summary>
    /// 敵の生成
    /// </summary>
    /// <param name="type">敵のタイプ</param>
    /// <param name="pos">生成座標</param>
    /// <returns>生成した敵</returns>
    public EnemyBase CreateEnemy(EnemyBase type)
    {
        var lange = CreateCreatePos();
        var obj = Instantiate(type, new Vector3(createPos.x + offsetPos.x + lange.x, createPos.y + offsetPos.y + lange.y, 0), Quaternion.identity);

        obj.Initialize();

        return obj;
    }
}
