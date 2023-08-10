using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Game;

public class ImpulseDriver : MonoBehaviour
{
    public GameObject Cloneable;
    [Header("Set impulse angle and force. \nIf ForceAngle is set, angle is instead derived from that, \nand my magnitude is used for impulse.")]
    public Vector2 Force = new Vector2(30000, 10000);
    [Header("Optional: impulse angle derived from Transform.rotation.")]
    public Transform ForceAngle;
    public float LoadDuration = 1.5f;
    public float LaunchDuration = 1.5f;
    public bool Autorepeat;
    
    private bool isLaunching;
    private Rigidbody2D projectile;
    
    void Start()
    {
        Cloneable.SetActive(false);
        
        OneShot();
    }
    
    public void OneShot(bool now = false)
    {
        InitProjectile();
        
        var oldLaunchDuration = LaunchDuration;
        if (now)
        {
            LaunchDuration = 0.0000001f;
        }
        
        Launch();
        
        LaunchDuration = oldLaunchDuration;
    }
    
    Rigidbody2D InitProjectile()
    {
        var instance = Instantiate(Cloneable);
        
        instance.transform.position = Cloneable.transform.position;
        instance.transform.rotation = Cloneable.transform.rotation;
        
        instance.SetActive(true);

        projectile = instance.GetComponentInChildren<Rigidbody2D>();
        return projectile;
    }
    
    public void Launch()
    {
        StartCoroutine(Execution.ExecuteAfterTime(LaunchDuration, () => {
            isLaunching = true;
        } ));
    }
    
    void FixedUpdate()
    {
        if (isLaunching)
        {
            isLaunching = false;
            
            AddForce();
            
            ContinueLaunching();
        }
    }
    
    void AddForce()
    {
        if (projectile == null) 
        {
            return;
        }
        
        var forceVector = Force;

        if (ForceAngle != null)
        {
            forceVector = CreateVector2FromAngleAndMagnitude(
                ForceAngle.rotation.eulerAngles.z, 
                Force.magnitude);
        }
            
        projectile.AddForce(forceVector);
    }
    
    void ContinueLaunching()
    {
        if (Autorepeat)
        {
            StartCoroutine(Execution.ExecuteAfterTime(LoadDuration, () => {
                OneShot();
            } ));
        }
    }
    
    public static Vector2 CreateVector2FromAngleAndMagnitude(float angle, float magnitude)
    {
        float radians = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * magnitude; 
    }
}
