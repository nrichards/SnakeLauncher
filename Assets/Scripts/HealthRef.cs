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
            health = GetParentHealth();
        }
    }
    
    protected void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        health?.OnCollisionEnter2DFromChild(collisionInfo, transform);
    }
    
    public void OnParticleSystemStopped()
    {
        health?.OnParticleSystemStoppedFromChild();
    }
    
    public void OnDamage()
    {
        health?.OnDamageFromChild();
    }
    
    public Health GetParentHealth()
    {
        return transform.parent.GetComponent<Health>();
    }

    // Corn N Damage by Rat R
    // Find R callback
    // Call R_KeepAlive(N)
}
