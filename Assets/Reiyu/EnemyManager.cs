using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{

    //シングルトン
    private static EnemyManager instance;
    public static EnemyManager Instance { get { return instance; } }

    [SerializeField]
    private Tower tower;

    /// <summary>
    /// 生成後の敵のリスト
    /// </summary>
    private List<EnemyBase> enemies = new List<EnemyBase>();

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        foreach (EnemyBase enemy in enemies)
        {
            enemy.SelfUpdate();
        }
    }

    public void AddEnemy(EnemyBase enemy)
    {
        enemies.Add(enemy);
        enemy.AddTower(tower);
    }
}
