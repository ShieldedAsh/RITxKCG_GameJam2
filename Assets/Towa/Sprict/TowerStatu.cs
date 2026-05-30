using UnityEngine;

[CreateAssetMenu(fileName = "TowerStatu", menuName = "Scriptable Objects/TowerStatu")]
public class TowerStatu : ScriptableObject
{
    // “ƒ‚ÌÅ‘å‘Ì—Í
    [SerializeField] private int towerMaxHp;
    public int TowerMaxHp { get { return towerMaxHp; } }

    // “ƒ‚Ì“¬’lƒnƒ“ƒhƒ‰
    [SerializeField] private TowerSpriteHandler[] towerHanders;
    public TowerSpriteHandler[] TowerSpriteHandlers { get { return towerHanders; } }
}
