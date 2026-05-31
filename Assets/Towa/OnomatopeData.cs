using UnityEngine;

[CreateAssetMenu(fileName = "OnomatopeData", menuName = "Scriptable Objects/OnomatopeData")]
public class OnomatopeData : ScriptableObject
{
    [Header("オフセット")]
    [SerializeField]
    private Vector3 offsetPos;
    public Vector3 OffseyPos { get => offsetPos; }

    [Header("サイズ")]
    [SerializeField]
    private float size;
    public float Size { get => size; }

    [Header("消えるまでの秒数")]
    [SerializeField]
    private float destroyTime;
    public float DestroyTime { get => destroyTime; }
}
