using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatFeet : MonoBehaviour
{
    public RatMover mover;
    
    private int groundLayerMask;

    void Start()
    {
        groundLayerMask = LayerMask.NameToLayer("Ground");
    }
    
    void FixedUpdate()
    {
        mover.OnTouchGround(gameObject, GetComponent<Collider2D>().IsTouchingLayers(groundLayerMask));
    }
}
