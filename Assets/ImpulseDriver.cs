using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseDriver : MonoBehaviour
{
    [SerializeField] public Rigidbody2D Projectile;
    [SerializeField] public Vector2 Force = new Vector2(30000, 10000);
    [SerializeField] public float Delay = 1.5f;
    
    private bool isLaunching;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(Delay));
    }
    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Debug.Log("Launching ...");
        // Code to execute after the delay
        
        DoLaunch();
    }

    void DoLaunch()
    {
        isLaunching = true;
    }

    void FixedUpdate()
    {
        if (isLaunching)
        {
            isLaunching = false;
            
            Projectile.AddForce(Force);
        }
    }
}
