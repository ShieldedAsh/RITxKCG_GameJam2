using NUnit.Framework;
using UnityEngine;

public class TowerImageChanger : MonoBehaviour
{
    [Header("クプリクタブルオブジェクト")]
    [SerializeField] private TowerStatu statu;

    //スプライトレンダー
    [Header("レンダー")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    // タワーのHP闘値と画像
    private TowerSpriteHandler[] hpHander;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        hpHander = statu.TowerSpriteHandlers;
    }

    /// <summary>
    /// 画像の更新　ハンドラの闘値より現在体力が低いなら画像を切り替えます
    /// </summary>
    /// <param name="hp">塔の現在体力</param>
    public void UpdateSprite(int hp)
    {
        foreach (var handler in hpHander)
        {
            if (handler.battleValue >= hp)
            {
                spriteRenderer.sprite = handler.sprite;
            }
        }
    }
};
