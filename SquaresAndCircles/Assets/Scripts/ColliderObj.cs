using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ColliderObj : MonoBehaviour
{

    public bool tapToProcess = false;
    public bool isBeingDragged = false;
    public GameObject collidingObject = null;
    public AudioRequest audioRequest;

    void Start()
    {
    }

    void OnCollisionEnter(Collision collisionInfo) {

        var objTag = collisionInfo.gameObject.tag;
        var nameObject = collisionInfo.collider.name;

        if (!tapToProcess) { 
            if (objTag == "square")
            {
                //myAudioSource.PlayOneShot(quadrado);
                audioRequest.PlayRemoteAudio(-1,-1, transform.position);
            }
            else if (objTag == "circle")
            {
                //myAudioSource.PlayOneShot(circulo);
                audioRequest.PlayRemoteAudio(-1, -1, transform.position);
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
                //myAudioSource.PlayOneShot(quadrado);
                audioRequest.PlayRemoteAudio(-1, -1, transform.position);
            }
            else if (objTag == "circle")
            {
                //myAudioSource.PlayOneShot(circulo);
                audioRequest.PlayRemoteAudio(-1, -1, transform.position);
            }
            tapToProcess = false;
        }
    }

    void OnCollisionExit(Collision collisionInfo) {

        var objTag = collisionInfo.gameObject.tag;
        //myAudioSource.Stop();
        audioRequest.StopRemoteAudio(-1);

        if (isBeingDragged) {
            //  myAudioSource.PlayOneShot(exitObjM);
            audioRequest.PlayRemoteAudio(-1, -1, transform.position);

        }

        collidingObject = null;
    }

    public void SelectObject()
    {
        //myAudioSource.PlayOneShot(selectedM);
        audioRequest.PlayRemoteAudio(-1, -1, transform.position);
        Destroy(collidingObject);
        collidingObject = null;
    }
}
