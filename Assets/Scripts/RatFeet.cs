using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatFeet : MonoBehaviour
{
    public RatMover mover;
    
    private int groundLayerMask;

    void Start()
    {
        groundLayerMask = LayerMask.GetMask(new string[]{"Ground"});
        // Debug.Log($"groundLayerMask = {groundLayerMask}, isTouchingLayers={GetComponent<Collider2D>().IsTouchingLayers(groundLayerMask)}");
    }
    
    void FixedUpdate()
    {
        //Debug.Log($"{gameObject}: groundLayerMask = {groundLayerMask}, isTouchingLayers={GetComponent<Collider2D>().IsTouchingLayers(groundLayerMask)}");

        mover.OnTouchGround(gameObject, GetComponent<Collider2D>().IsTouchingLayers(groundLayerMask));
    }
}
