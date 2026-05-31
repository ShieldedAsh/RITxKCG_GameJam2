using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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
    public void LaunchAttack(AttackType attackType)
    {
        Vector3 mouse = Mouse.current.position.ReadValue();
        Vector3 world = cam.ScreenToWorldPoint(
            new Vector3(mouse.x, mouse.y, 10f)
        );

        Debug.Log($"{attackType} launched at world {world}");
        // アタックを生成
        AttackManager.Instance.CreateAttack(attackType, world);
        //OnomatopeManager.Instance.CreateOnomatope(attackType, world);
    }

    /*
    public void LaunchAttack(Attack attackType)
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
    */
    
}
