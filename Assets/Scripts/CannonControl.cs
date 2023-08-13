using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonControl : MonoBehaviour
{
    [Header("UI")]
    public Transform Cannon;
    public GameObject snakeLauncherInput; // THis has been dragged onto me
    
    public float tiltSpeed = 1f;
    
    public Transform TiltHandle;
    public float snapBackFactor = 0.002f;
    public Transform Groove;
    
    [Header("Economy")]
    public Inventory inventory;
    public InventoryItem.InventoryKind itemToLaunch;
    
    private float invertTilt = -1f;
    
    private InputReader inputReader;
    private ImpulseDriver impulseDriver;
    private Controls m_Controls;
    private float centerOfControl = 0f;

    void Start()
    {
        inputReader = snakeLauncherInput.GetComponent<InputReader>();
        inputReader.ActionPressed += Trigger;
        inputReader.Tilted += OnTilt;
        
        impulseDriver = Cannon.gameObject.GetComponent<ImpulseDriver>();

        centerOfControl = TiltHandle.position.x;
    }
    
    void Awake()
    {
        m_Controls = new Controls();
    }

    void Update()
    {
        // Gamepad
        var tilt = m_Controls.Map.Tilt.ReadValue<Vector2>();
        var scaledTiltSpeed = tiltSpeed * Time.deltaTime * invertTilt;
        Tilt(tilt.x * scaledTiltSpeed);


        // On-screen control
        if (TiltHandle.position.x != centerOfControl)
        {
            // if the x is greater than the inner groove, then limit the X
            var grooveBounds = new Bounds(Groove.transform.position, Vector3.zero);
            
            //if (TiltHandle.position.x > grooveBounds.size.x + grooveBounds.size. || TiltHandle.position.x < grooveBounds.extents.x)
            //{
            //    var newPos = Vector3.zero + TiltHandle.position;
            //    newPos.x = grooveBounds.extents.x;
            //}
            
            
            // Tilt
            var deltaX = TiltHandle.position.x - centerOfControl * (tiltSpeed * Time.deltaTime);
            Tilt(deltaX);
            
            // Snap-back
            var dampenedDeltaX = TiltHandle.position.x + (deltaX * snapBackFactor * -1.0f);
            
            TiltHandle.transform.position = 
                new Vector3(dampenedDeltaX, TiltHandle.position.y, TiltHandle.position.z);
                
            Debug.Log($"Groove's bounds {grooveBounds}, deltaX {deltaX}, dampenedDeltaX {dampenedDeltaX}");

        }
    }
    
    public void OnEnable()
    {
        m_Controls.Enable();
    }

    public void OnDisable()
    {
        m_Controls.Disable();
    }
    
    void Trigger(InputAction.CallbackContext context)
    {
        Debug.Log($"Trigger phase {context}");

        if (context.phase != InputActionPhase.Started)
        {
            return;
        }
        
        Debug.Log("Is triggered");
        
        inventory.RemoveItem(itemToLaunch, 1);
        
        impulseDriver.OneShot(true);
    }
    
    void OnTilt(Vector2 amount)
    {
        Debug.Log($"Is tilted {amount}");
        
        Tilt(amount.x);
    }
    
    void Tilt(float eulerAngle)
    {
        Cannon.transform.Rotate(new Vector3(0f, 0f, eulerAngle));
    }
}
