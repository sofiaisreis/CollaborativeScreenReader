using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ColliderObjTest : MonoBehaviour
{

    public bool tapToProcess = false;
    public bool isBeingDragged = false;
    private AudioSource myAudioSource;
    public AudioClip
        ding, selected, shortBeep;
    public TrackerClient trackedUser;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isBeingDragged)
        {
            myAudioSource.Stop();
        }
    }

    public void PlaySound()
    {
        myAudioSource.PlayOneShot(shortBeep);
    }
}