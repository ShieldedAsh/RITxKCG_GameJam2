using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{

    //シングルトン
    private static EnemyManager instance;
    public static EnemyManager Instance { get { return instance; } }

    [SerializeField]
    private Tower tower;

    // エネミークリエイター
    [SerializeField]
    private EnemyCreator[] enemyCreators;
    public EnemyCreator[] EnemyCreators {  get { return enemyCreators; } }

    /// <summary>
    /// 生成後の敵のリスト
    /// </summary>
    private List<EnemyBase> enemies = new List<EnemyBase>();

    private List<Egg> eggs = new List<Egg>();

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
                continue;
            }
            enemies[i].SelfUpdate();
        }

        for (int i = 0; i < eggs.Count; i++)
        {
            if (eggs[i] == null)
            {
                eggs.RemoveAt(i);
                continue;
            }

            eggs[i].SelfUpdate();
        }
    }

    public void AddEnemy(EnemyBase enemy)
    {
        enemies.Add(enemy);
        enemy.AddTower(tower);
    }


    public void AddEgg(Egg egg)
    {
        eggs.Add(egg);
    }

}
