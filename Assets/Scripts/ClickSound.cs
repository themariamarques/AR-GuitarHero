using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Vuforia;
using System;

[RequireComponent(typeof(VirtualButton))]
public class ClickSound : MonoBehaviour{

    public AudioClip sound;
    public GameObject button;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = true;
        source.volume = (float) 0.5;
        button.GetComponent<AudioSource>().Play();
    }
    
}