using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public Transform Cannon;
    public GameObject snakeLauncherInput; // THis has been dragged onto me
    
    private InputReader inputReader;
    private ImpulseDriver impulseDriver;
    
    void Start()
    {
        inputReader = snakeLauncherInput.GetComponent<InputReader>();
        
        inputReader.ActionPressed += Trigger;
        
        impulseDriver = Cannon.gameObject.GetComponent<ImpulseDriver>();
    }

    void Update()
    {
        
    }
    
    void Trigger()
    {
        Debug.Log("Is triggered");
        
        impulseDriver.OneShot(true);
    }
}
