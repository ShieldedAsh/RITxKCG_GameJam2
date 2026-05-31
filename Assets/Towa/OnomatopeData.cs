using UnityEngine;

[CreateAssetMenu(fileName = "OnomatopeData", menuName = "Scriptable Objects/OnomatopeData")]
public class OnomatopeData : ScriptableObject
{
    [Header("ƒTƒCƒY")]
    [SerializeField]
    private float size;
    public float Size { get => size; }

    [Header("Á‚¦‚é‚Ü‚Å‚Ì•b”")]
    [SerializeField]
    private float destroyTime;
    public float DestroyTime { get => destroyTime; }
}
