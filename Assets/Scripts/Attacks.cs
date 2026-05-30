using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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
    private static Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void LaunchAttack(Attack attackType)
    {
        mousePos = Mouse.current.position.ReadValue();
        
        switch (attackType)
        {
            case Attack.Boom:
                Debug.Log("boom attack launched at " + mousePos.x + ", " + mousePos.y);
                break;
            case Attack.Zap:
                Debug.Log("zap attack launched at " + mousePos.x + ", " + mousePos.y);
                break;
            case Attack.Blaze:
                Debug.Log("blaze attack launched at " + mousePos.x + ", " + mousePos.y);
                break;
            case Attack.Slash:
                Debug.Log("slash attack launched at " + mousePos.x + ", " + mousePos.y);
                break;
            case Attack.Whoosh:
                Debug.Log("whoosh attack launched at " + mousePos.x + ", " + mousePos.y);
                break;
            case Attack.Spring:
                Debug.Log("spring attack launched at " + mousePos.x + ", " + mousePos.y);
                break;
        }
    }
}
