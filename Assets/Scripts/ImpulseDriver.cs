using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Game;

public class ImpulseDriver : MonoBehaviour
{
    [SerializeField] public GameObject Cloneable;
    [SerializeField] public Vector2 Force = new Vector2(30000, 10000);
    [SerializeField] public float LoadDuration = 1.5f;
    [SerializeField] public float LaunchDuration = 1.5f;
    [SerializeField] public bool Autorepeat;
    
    private bool isLaunching;
    private Rigidbody2D projectile;
    
    // Start is called before the first frame update
    void Start()
    {
        InitProjectile();
        Launch();
    }
    
    Rigidbody2D InitProjectile()
    {
        //Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        //Vector3 worldCenter = Camera.main.ScreenToWorldPoint(screenCenter);
        //var instance = Instantiate(Cloneable, worldCenter, Quaternion.identity);

        var instance = Instantiate(Cloneable);
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
            
            projectile.AddForce(Force);
            
            if (Autorepeat)
            {
                StartCoroutine(Execution.ExecuteAfterTime(LoadDuration, () => {
                    InitProjectile();
                    Launch();
                } ));
            }
        }
    }
}
