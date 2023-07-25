using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeWiggle : MonoBehaviour
{
	[Header("NOTE: Attach me to the TAIL of a chain of GameObjects linked through \nHingeJoint2D \"Connected Rigid Body\" parameters \nfor a serpentine locomotion wiggling effect. \n\nHow frequently to move.")]
    [MinTo(0.0f, 60.0f)]
    [SerializeField] private Vector2 MoveEvery = new Vector2(0.25f, 5.0f);
    
    [Header("Time before applying force to next body segment.")]
    [SerializeField] private float serpentinePropagationTime = 0.25f;

    
	[Header("The desired speed for the Rigidbody2D to reach as it moves with the joint.")]
	[SerializeField] private float MaxSpeed = 400;
    
	[Header("The maximum force that can be applied to the Rigidbody2D at the joint to attain the target speed.")]
	[SerializeField] private float MaxTorque = 5000;
	
    private List<HingeJoint2D> segments = new List<HingeJoint2D>();
    private int currWiggleSegmentIndex = 0;
    
    private float nextWiggleTime;
    private float nextSerpentineTime;
    private bool isMoving = false; // TODO replace with something about time ..
    
    struct Wiggle {
        public float MotorSpeed;
        public float MaxMotorTorque;
    }
    private Wiggle wiggle;
    
	void Start()
	{
        //Debug.Log("Start");
        CollectSegments();
		UpdateNextWiggleTime();
    }

    void CollectSegments()
    {
        //Debug.Log("CollectSegments");

        var tail = GetComponent<HingeJoint2D>();
        segments.Add(tail);
        
        var curr = tail;
        while (!(curr is null) && !(curr.connectedBody is null)) {
            HingeJoint2D sibling;
            var result = curr.connectedBody.gameObject.TryGetComponent<HingeJoint2D>(out sibling);
            if (result) {
                segments.Add(sibling);
            }
            curr = sibling;
        }
        
        segments.Reverse();
    }
    
    void UpdateNextWiggleTime() {
        nextWiggleTime = Time.fixedTime + Random.Range(MoveEvery.x, MoveEvery.y);
        //Debug.Log($"delta nextWiggleTime={nextWiggleTime - Time.fixedTime}");
    }
    
	void FixedUpdate()
	{		
		if (!isMoving && IsTimeToMove()) {
            //Debug.Log("FixedUpdate IsTimeToMove");
            
            currWiggleSegmentIndex = 0;
            
            StartImpulse();
            isMoving = true;
        } else if (isMoving) {
	    	UpdateSerpentineLocomotion();
	    }
    }
    
    bool IsTimeToMove() {
        return Time.fixedTime > nextWiggleTime;
    }
    
	void StartImpulse() {
		//Debug.Log("StartImpulse");
		
        wiggle.MotorSpeed = Random.Range(-MaxSpeed, MaxSpeed);
        wiggle.MaxMotorTorque = Random.Range(0, MaxTorque);
        
        UpdateSerpentineLocomotion();
        
        nextSerpentineTime = Time.fixedTime + serpentinePropagationTime;
    }
    
	void UpdateSerpentineLocomotion() {
        if (currWiggleSegmentIndex < 0 || currWiggleSegmentIndex >= segments.Count) {
            //Debug.Log("UpdateSerpentineLocomotion no current segment index");
            UpdateNextWiggleTime();
            isMoving = false;
            return;
        }
        
        if (Time.fixedTime > nextSerpentineTime) {
            //Debug.Log("UpdateSerpentineLocomotion applying wiggle");

            var stopMe = segments[currWiggleSegmentIndex];
            ApplyWiggle(stopMe, true);

            NextWiggleSegment();
            if (currWiggleSegmentIndex >= 0) {
                nextSerpentineTime = Time.fixedTime + serpentinePropagationTime;
    
                var wiggleMe = segments[currWiggleSegmentIndex];
                ApplyWiggle(wiggleMe);
            }
        } else {
            //Debug.Log("UpdateSerpentineLocomotion waiting ...");
        }
	}
    
    void ApplyWiggle(HingeJoint2D segment, bool stop = false) {
        //Debug.Log($"ApplyWiggle {segment}");
        
        var curr = segment.GetComponent<HingeJoint2D>();
        
        JointMotor2D motor = curr.motor;
        motor.motorSpeed = stop ? 0 : wiggle.MotorSpeed;
        motor.maxMotorTorque = stop ? 0 : wiggle.MaxMotorTorque;
        curr.motor = motor;
    }
    
    HingeJoint2D NextWiggleSegment() {
        currWiggleSegmentIndex++;

        if (currWiggleSegmentIndex >= segments.Count) {
            currWiggleSegmentIndex = -1;
            return null;
        } else {
            return segments[currWiggleSegmentIndex];
        }
    }
}
