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
    public GameObject collidingObject = null;
    private AudioSource myAudioSource;
    public AudioClip sound;
    public TrackerClient trackedUser;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        var objTag = collisionInfo.gameObject.tag;
        var nameObject = collisionInfo.collider.name;
        Debug.Log("We hit a " + objTag + " named " + collisionInfo.collider.name);

        if (!tapToProcess) { 
            if (objTag == "square")
            {
                myAudioSource.PlayOneShot(sound);
            }
            else if (objTag == "circle")
            {
                myAudioSource.PlayOneShot(sound);
            }
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        var objTag = collisionInfo.gameObject.tag;
        collidingObject = collisionInfo.gameObject;

        if (tapToProcess)
        {
            if (objTag == "square")
            {
                myAudioSource.PlayOneShot(sound);
            }
            else if (objTag == "circle")
            {
                myAudioSource.PlayOneShot(sound);
            }
            tapToProcess = false;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        var objTag = collisionInfo.gameObject.tag;

        if (isBeingDragged) {
            //myAudioSource.PlayOneShot(exitObj);

        }

        collidingObject = null;
    }

    public void SelectObject()
    {
        myAudioSource.PlayOneShot(sound);
        Destroy(collidingObject);
        collidingObject = null;
    }
}
