using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Game;

public class Lifespan : MonoBehaviour
{
    [SerializeField] private float DestroyAfter = 10.0f;
    public EntityDebugLabel DebugLabel;

    private float WaitCounter;
    private float ActualDestroyAfter;
    private IEnumerator countdown;
    
    void Start()
    {
        ActualDestroyAfter = DestroyAfter;
        StartCoroutine(countdown = Countdown());
    }

    private IEnumerator Countdown() {
        while(true) {
            yield return new WaitForSeconds(1);
            WaitCounter += 1;
            
            DebugLabel?.AddDebugValue("ls", (WaitCounter - ActualDestroyAfter).ToString());
            
            if (WaitCounter > ActualDestroyAfter)
            {
                StopCoroutine(countdown);
                Destroy(gameObject);
                yield break;
            }
        }
    }
    
    public void KeepAlive()
    {
        if (ActualDestroyAfter - WaitCounter < DestroyAfter)
        {
            ActualDestroyAfter += DestroyAfter;
        }
    }
}
