using UnityEngine;

public class Tower : MonoBehaviour
{
    // タワーの情報
    [Header("クプリクタブルオブジェクト")]
    [SerializeField]private TowerStatu statu;
    // 最大HP
    private int maxHp;
    // 現在HP
    [SerializeField]private int hp;

    // 塔の画像変換クラス
    [Header("画像変更クラス")]
    [SerializeField] private TowerImageChanger changer;

    void Start()
    {
        Initialize();
    }
    /// <summary>
    ///  初期化
    /// </summary>
    private void Initialize()
    {
        //タワーの体力を初期化
        maxHp = statu.TowerMaxHp;
        hp = maxHp;
    }

    /// <summary>
    /// ダメージを食らった時の処理
    /// </summary>
    /// <param name="damage">ダメージ値</param>
    public void TakeDamage(int damage) 
    {
        hp -= damage;

        // スプライトの更新
        changer.UpdateSprite(hp);
    }
}
