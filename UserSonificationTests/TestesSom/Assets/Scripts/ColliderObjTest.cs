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
    public AudioClip
        F1_quadrado, F1_circulo, F1_triangulo,
        ding, selected, exitObj, F1_test;
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
                myAudioSource.PlayOneShot(F1_quadrado);
            }
            else if (objTag == "circle")
            {
                myAudioSource.PlayOneShot(F1_circulo);
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
                myAudioSource.PlayOneShot(F1_quadrado);
            }
            else if (objTag == "circle")
            {
                myAudioSource.PlayOneShot(F1_circulo);
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
        myAudioSource.PlayOneShot(selected);
        Destroy(collidingObject);
        collidingObject = null;
    }
}
