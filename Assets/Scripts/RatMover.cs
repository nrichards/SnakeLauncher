using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// </summary>
/// <seealso>
/// https://stackoverflow.com/questions/71900258/how-to-flip-character-when-moving-left-unity-2d - to flip and go left
/// </seealso>
public class RatMover : MonoBehaviour
{
    
    ///// <summary>
    ///// Scales the target around an arbitrary point by scaleFactor.
    ///// This is relative scaling, meaning using  scale Factor of Vector3.one
    ///// will not change anything and new Vector3(0.5f,0.5f,0.5f) will reduce
    ///// the object size by half.
    ///// The pivot is assumed to be the position in the space of the target.
    ///// Scaling is applied to localScale of target.
    ///// </summary>
    ///// <param name="target">The object to scale.</param>
    ///// <param name="pivot">The point to scale around in space of target.</param>
    ///// <param name="scaleFactor">The factor with which the current localScale of the target will be multiplied with.</param>
    //public static void ScaleAroundRelative(GameObject target, Vector3 pivot, Vector3 scaleFactor)
    //{
    //    // pivot
    //    var pivotDelta = target.transform.localPosition - pivot;
    //    pivotDelta.Scale(scaleFactor);
    //    target.transform.localPosition = pivot + pivotDelta;
     
    //    // scale
    //    var finalScale = target.transform.localScale;
    //    finalScale.Scale(scaleFactor);
    //    target.transform.localScale = finalScale;
    //}
     
    ///// <summary>
    ///// Scales the target around an arbitrary pivot.
    ///// This is absolute scaling, meaning using for example a scale factor of
    ///// Vector3.one will set the localScale of target to x=1, y=1 and z=1.
    ///// The pivot is assumed to be the position in the space of the target.
    ///// Scaling is applied to localScale of target.
    ///// </summary>
    ///// <param name="target">The object to scale.</param>
    ///// <param name="pivot">The point to scale around in the space of target.</param>
    ///// <param name="scaleFactor">The new localScale the target object will have after scaling.</param>
    //public static void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    //{
    //    // pivot
    //    Vector3 pivotDelta = target.transform.localPosition - pivot; // diff from object pivot to desired pivot/origin
    //    Vector3 scaleFactor = new Vector3(
    //        newScale.x / target.transform.localScale.x,
    //        newScale.y / target.transform.localScale.y,
    //        newScale.z / target.transform.localScale.z );
    //    pivotDelta.Scale(scaleFactor);
    //    target.transform.localPosition = pivot + pivotDelta;
     
    //    //scale
    //    target.transform.localScale = newScale;
    //}

    
    [Header("Attach me to the parent of the rat objects\n\n")]
    public GameObject Head; 
    public GameObject Tail; 
    public Vector2 WalkForce = new Vector2(50, 0);
    
    private HingeJoint2D hinge;
    Vector2 previousPosition;
    bool xRightFacing = true;
    int settle = 0;
    bool isGrounded = false;
    
    void Start()
    {
        previousPosition = Tail.GetComponent<Rigidbody2D>().position;
        
        hinge = Tail.GetComponent<HingeJoint2D>();
    }
    
    void FixedUpdate()
    {
        EnsureRightSideUp(Tail);
        
        //EnsureFacingDirection(Tail);
        
        WalkToTheCorn(Head);
    }
    
    
    void EnsureFacingDirection(GameObject go)
    {
        // NOTE: DISABLED
        //
        
        var currentPosition = go.GetComponent<Rigidbody2D>().position;
        Vector2 currentDirection = (currentPosition-previousPosition).normalized;
        previousPosition = currentPosition;
        
        Debug.Log(currentDirection.x);
        
        // TODO Ignore flipping if value is close to zero
        if (settle > 0) {
            settle--;
            return;
        }
        if (currentDirection.x >= 0.1f) {
            Debug.Log($"Nick");
            if (
                //false && 
                xRightFacing == false) {
                Debug.Log("RIGHT");

                settle = 3;
                
                xRightFacing = true;
                
                
                //SleepWakeChildRBs(true);
                
                ResetParentPos();
                
                // WONT WORK
                // TODO: Rotate the object on the Y, 180 degrees, and apply an impulse double the current X momentum,
                //       to offset that
                

                // TODO : Set parent transform of child gameobjects to null, then moving the parent game object's X 
                //        to be appropriate for flipping the localScale's x, below,
                //        Optionally setting isKinematic to true, and restoring that after restoring parent

                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                

                //SleepWakeChildRBs(false);
                //var i = 0;
                //foreach(Transform child in transform) {
                //    child.GetComponent<SpriteRenderer>().flipX = false;
                    
                //    var rb = child.GetComponent<Rigidbody2D>();
                //    //rb.Sleep();
                //    var pos = new Vector2(rb.position.x, rb.position.y);
                //    if (i == 1) {
                //        Debug.Log("R:");
                //        pos.x += 1.0f;
                //        rb. MoveRotation(0f);
                //    }
                //    rb.MovePosition(pos);
                //    //rb.WakeUp();
                //    i++;
                //}
            }
        } else if (currentDirection.x <= -0.1f) {
            if (xRightFacing == true) {
                Debug.Log("LEFT");
                settle = 3;
                
                xRightFacing = false;
                
                //SleepWakeChildRBs(true);
                Debug.Break();
                Debug.Log("Break1");
                
                ResetParentPos();
                Debug.Break();
                Debug.Log("Break2");
                
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                Debug.Break();
                Debug.Log("Break3");

                //SleepWakeChildRBs(false);

                //var i = 0;
                //foreach(Transform child in transform) {
                //    child.GetComponent<SpriteRenderer>().flipX = true;
                    
                //    var rb = child.GetComponent<Rigidbody2D>();
                //    //rb.Sleep();
                //    var pos = new Vector2(rb.position.x, rb.position.y);
                //    if (i==1) {
                //        Debug.Log("L:");
                //        pos.x -= 1.0f;
                //        rb.MoveRotation(180f);
                //    }
                //    rb.MovePosition(pos);
                //    //rb.WakeUp();
                //    i++;
                    
                //}
            }
        }
        
        //var inverter = 1.0f;
        //if (!xRightFacing) {
        //    inverter = -1.0f;
        //}
        
        //var curRightFacing = currentDirection.x * inverter >= 0f ? true : false;
        //Debug.Log($"curdir.x={currentDirection.x}, xRFacing={xRightFacing}");
        
        //if (xRightFacing != curRightFacing) {
            
        //    Debug.Log("Changing dir");
        //    var scale = transform.localScale;
        //    scale.x *= -1.0f;
        //    scale.z *= -1.0f;
        //    transform.localScale = scale;
            
        //    xRightFacing = curRightFacing;
        //}
    }
    
    void ResetParentPos()
    {
        var calcX = Tail.transform.position.x + hinge.anchor.x;

        var transforms = new List<Transform>();
        foreach(Transform child in transform) {
            transforms.Add(child);
            child.SetParent(null);
        }
        
        
        var oldPos = transform.position;
        var pos = new Vector3(calcX, oldPos.y, oldPos.z);
        transform.position = pos;
        

        foreach(Transform child in transforms) {
            child.SetParent(transform);
        }
    }
    
    void SleepWakeChildRBs(bool sleep) {
        foreach(Transform child in transform) {
            child.GetComponent<SpriteRenderer>().flipX = true;
                    
            var rb = child.GetComponent<Rigidbody2D>();
            if (sleep) {
                rb.Sleep();
            } else {
                rb.WakeUp();
            }
        }
    }
    
    void EnsureRightSideUp(GameObject go)
    {
        float flipStrength = Mathf.Abs(GetInstanceID() % 100) > 50 ? 1.0f : -1.0f;

        if (Mathf.Abs(go.transform.eulerAngles.z) > 90f  && Mathf.Abs(go.transform.eulerAngles.z) < (360f-90f)) {
            go.GetComponent<Rigidbody2D>().AddTorque(flipStrength, ForceMode2D.Impulse);
        } 
    }
    
    public void OnTouchGround(GameObject toucher, bool grounded)
    {
        isGrounded = grounded;
    }
    
    void WalkToTheCorn(GameObject go)
    {
        // Tell if the Rat is touching the ground, or ANYTHING under foot
        if (!isGrounded)
        {
            return;
        }
        
        //Debug.Log($"Touching ground {go}");
        
        // Then, ApplyForce to Rat
        var rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(WalkForce);
    }
    
}
