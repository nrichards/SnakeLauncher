using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRef : MonoBehaviour
{
    [Header("Optional: set to override notifying parent's Health")]
    public Health health;
    
    void Start()
    {
        if (health == null)
        {
            health = transform.parent.GetComponent<Health>();
        }
    }
    
    protected void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        var health = transform.parent.GetComponent<Health>();
        
        health.OnCollisionEnter2DFromChild(collisionInfo, transform);
    }
    
    public void OnParticleSystemStopped()
    {
        var health = transform.parent.GetComponent<Health>();

        health.OnParticleSystemStoppedFromChild();
    }
}
