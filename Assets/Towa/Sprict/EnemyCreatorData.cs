using UnityEngine;

[CreateAssetMenu(fileName = "EnemyCreatorData", menuName = "Scriptable Objects/EnemyCreatorData")]
public class EnemyCreatorData : ScriptableObject
{
    [Header("生成座標")]
    [SerializeField]
    private Vector2 createPos;
    public Vector2 CeratePos { get { return createPos; } }

    [Header("オフセット座標")]
    [SerializeField]
    private Vector2 offsetPos;
    public Vector2 OffsetPos { get { return offsetPos; } }

    // 生成の距離最短
    [Header("生成距離最短")]
    [SerializeField]
    private float createLangeMin;
    public float CreateLangeMin {  get { return createLangeMin; } }

    // 生成の距離最長
    [Header("生成距離最長")]
    [SerializeField]
    private float createLangeMax;
    public float CreateLangeMax {  get { return createLangeMax; } }
}
