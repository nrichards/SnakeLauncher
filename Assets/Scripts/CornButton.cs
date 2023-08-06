using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseUp()
    {
        Debug.Log("OnMouseUp");    
    }
    
    public void OnButton()
    {
        Debug.Log("button clicked");
    }
}
