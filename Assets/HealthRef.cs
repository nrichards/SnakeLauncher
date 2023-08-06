using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRef : MonoBehaviour
{
    protected void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        var health = transform.parent.GetComponent<Health>();
        
        health.OnCollisionEnter2DFromChild(collisionInfo, transform);
    }
}
