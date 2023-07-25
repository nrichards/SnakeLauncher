using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game;

public class Lifespan : MonoBehaviour
{
    [SerializeField] private float DestroyAfter = 10.0f;
    
    void Start()
    {
        Destroy(gameObject, DestroyAfter);
    }

}
