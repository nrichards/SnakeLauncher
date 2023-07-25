using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public static class Execution
    {   
        public static IEnumerator ExecuteAfterTime(float time, System.Action execute)
        {
            yield return new WaitForSeconds(time);
    
            execute();
        }
    }
}
