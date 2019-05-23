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
    public User u;
    public TrackerClient trackedUser;
    public int idUser;
    public UserHand uHand;

    /* CODE OF SOUNDS
    * 1 - Female Square
    * 2 - Male Square
    * 
    * 3 - Female Circle
    * 4 - Male Circle
    * 
    * 5 - Female Triangle
    * 6 - Male Triangle
    *
    * 7 - Select
    * 8 - OnExit
    */

    /* CODE OF OBJECTS
     * 1 - square
     * 2 - circle
     * 3 - triangle
     * 4 - select
     * 5 - exit
     */

    void Start()
    {
        //_audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if ( idUser == 1)
        {
            idUser = u.user1;
        }
        else if ( idUser == 2)
        {
            idUser = u.user2;
        }
        else
        {
        }

        //print("IDDD USSEEEER: " + idUser);
        /*if(u.humanID == trackedUser.GetComponent<User>().)
        i
        {
            idUser = 1;
        }
        else if(u.humanID == Human.id)
        {
            idUser = 2;
        }
        else
        {
            print("ja foste...");
        }*/
    }

    void OnCollisionEnter(Collision collisionInfo) {

        var objTag = collisionInfo.gameObject.tag;
        var nameObject = collisionInfo.collider.name;
        print("ID DO USERINO: " + idUser);

        //print("Collision of user: " + u);
        if (!tapToProcess) { 
            if (objTag == "square")
            {
                //userIDstring = u.GetComponent<User>().humanID;
                audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position);
                //print("ID OF USER: " + u.humanID);
            }
            else if (objTag == "circle")
            {
                audioRequest.PlayRemoteAudio(idUser, 3, 2, transform.position);
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
                audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position);
            }
            else if (objTag == "circle")
            {
                audioRequest.PlayRemoteAudio(idUser, 3, 2, transform.position);
            }
            tapToProcess = false;
        }
    }

    void OnCollisionExit(Collision collisionInfo) {

        var objTag = collisionInfo.gameObject.tag;
        audioRequest.StopRemoteAudio(-1);

        if (isBeingDragged) {
            audioRequest.PlayRemoteAudio(idUser, 8, 5, transform.position);

        }

        collidingObject = null;
    }

    public void SelectObject()
    {
        audioRequest.PlayRemoteAudio(idUser, 7, 4, transform.position);
        Destroy(collidingObject);
        collidingObject = null;
    }
}
