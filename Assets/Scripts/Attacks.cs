using UnityEngine;
using UnityEngine.InputSystem;

public enum Attack
{
    Boom,
    Zap,
    Blaze,
    Slash,
    Whoosh,
    Spring
};

public class Attacks : MonoBehaviour
{
    //camera ref
    [SerializeField]
    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LaunchAttack(Attack attackType)
    {
        switch (attackType)
        {
            case Attack.Boom:
                Debug.Log("boom attack launched");
                break;
            case Attack.Zap:
                Debug.Log("zap attack launched");
                break;
            case Attack.Blaze:
                Debug.Log("blaze attack launched");
                break;
            case Attack.Slash:
                Debug.Log("slash attack launched");
                break;
            case Attack.Whoosh:
                Debug.Log("whoosh attack launched");
                break;
            case Attack.Spring:
                Debug.Log("spring attack launched");
                break;
        }
    }
}
