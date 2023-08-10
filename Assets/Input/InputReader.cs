using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public delegate void IRAction();
    public IRAction ActionPressed;
    
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
            
            ActionPressed();
        }
    }
    
}
