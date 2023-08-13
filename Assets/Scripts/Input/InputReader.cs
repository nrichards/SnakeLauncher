using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public delegate void IRAction(InputAction.CallbackContext context);
    public IRAction ActionPressed;
    
    public delegate void IRValue(Vector2 value);
    public IRValue Tilted;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void OnActionButton(InputAction.CallbackContext context)
    {
        if (context.phase.Equals(InputActionPhase.Started))
        {
            Debug.Log($"Action !!! {context}");
            
            ActionPressed(context);
        }
    }
    
    public void OnTilt(InputAction.CallbackContext context)
    {
        //Debug.Log($"OnTilt {context}");
        
        //Tilted( context.ReadValue<Vector2>() );
    }
}
