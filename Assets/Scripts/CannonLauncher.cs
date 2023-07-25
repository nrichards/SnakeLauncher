using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour
{
    [SerializeField] private float DeltaX = 0.0125f;
    [SerializeField] private float MaxX = 15f;
    
    private float startX;
    private bool isLaunching;
    private float progress;
    
    void Start()
    {
        startX = transform.position.x;
        isLaunching = false;
        progress = 0.0f;
        
        StartCoroutine(ExecuteAfterTime(3));
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
            progress = Mathf.Min(progress + DeltaX, 1f);

            var pos = transform.position;
            var x = EasingFunction.EaseOutQuad(startX, MaxX, progress);
            Debug.Log($"old={pos.x} new={x}");
            pos.x = x;
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
    }
    
}
