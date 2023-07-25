using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ExtensionMethods;

public class AudioClipProviderRandomExhaustive : MonoBehaviour
{
    [SerializeField] public AudioClip[] Clips;
    
    private int nextIndex;
    private AudioClip[] activeClips;
    
    // Start is called before the first frame update
    void Start()
    {
        nextIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public AudioClip Next()
    {
        if (nextIndex < 0 || nextIndex == Clips.Length)
        {
            activeClips = (AudioClip[]) Clips.Clone();
            activeClips.Shuffle();
            nextIndex = 0;
        }

        var result = activeClips[nextIndex];
        nextIndex++;
        
        Debug.Log($"Next: {result}");
        
        return result;
    }
}
