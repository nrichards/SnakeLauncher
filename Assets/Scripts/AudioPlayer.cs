using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] public AudioClipProviderRandomExhaustive Provider;
    [SerializeField] public AudioSource Source;
    [Header("Try 0.0002")]
    [Range(0, 1)]
    [SerializeField] public float FadePerFrame;
    
    private AudioClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
        clip = Provider.Next();
        Source.clip = clip;
        Source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (FadePerFrame > 0.0f)
        {
            Source.volume -= FadePerFrame;
        }
    }
}
