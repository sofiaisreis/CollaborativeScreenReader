using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ColliderObj : MonoBehaviour
{

    public bool isBeingDragged = false;
    public bool errorTap = false;
    public GameObject collidingObject = null;
    public AudioRequest audioRequest;
    public User u;
    public TrackerClient trackedUser;
    public UserHand uHand;
    public int squares_inc;
    public int circles_inc;
    public int squares_findTotal; // definido no inspector
    public int circles_findTotal;
    public GameObject lastCollidingObject = null;

    private void Start()
    {
        squares_inc = 0;
        circles_inc = 0;
    }

    /* CODE OF OBJECT TYPE SOUND
     * 1 - square
     * 2 - circle
     * 3 - triangle
     * 4 - select
     * 5 - exit
     * 6 - error
     */

    // (userID, lastObj, objTypeSound, relativePos1, relativePos2, selecionados, totais);

    private void Update()
    {
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        int feedbackNow = GetComponent<Logs>().whichFeedback;
        print("Feedback on collider: " + feedbackNow);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        var objTag = collisionInfo.gameObject.tag;

        if (collidingObject == null)
        {
            if (objTag == "square")
            {
                //userIDstring = u.GetComponent<User>().humanID;
                audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position, -1, -1, feedbackNow);
                //print("ID OF USER: " + u.humanID);
            }
            else if (objTag == "circle")
            {
                audioRequest.PlayRemoteAudio(idUser, 2, 2, transform.position, -1, -1, feedbackNow);
            }
        }

        lastCollidingObject = collidingObject = collisionInfo.gameObject;
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        int feedbackNow = GetComponent<Logs>().whichFeedback;
        print("Feedback on collider: " + feedbackNow);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        var objTag = collisionInfo.gameObject.tag;

        if (collidingObject == null)
        {
            if (objTag == "square")
            {
                audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position, - 1, -1, feedbackNow);
            }
            else if (objTag == "circle")
            {
                audioRequest.PlayRemoteAudio(idUser, 2, 2, transform.position, -1, -1, feedbackNow);
            }
        }

        lastCollidingObject = collidingObject = collisionInfo.gameObject;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        int feedbackNow = GetComponent<Logs>().whichFeedback;
        print("Feedback on collider: " + feedbackNow);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        var objTag = collisionInfo.gameObject.tag;
        audioRequest.StopRemoteAudio(idUser);

        if (isBeingDragged) {
            //audioRequest.PlayRemoteAudio(idUser, 8, 5, transform.position);

        }

        collidingObject = null;
    }

    public void SelectObject()
    {
        int feedbackNow = GetComponent<Logs>().whichFeedback;
        print("Feedback on collider: " + feedbackNow);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        if (errorTap)
        {
            audioRequest.PlayRemoteAudio(idUser, -1, 6, transform.position, -1, -1, feedbackNow);
        }
        else
        {
            if (lastCollidingObject.tag == "square")
            {
                squares_inc++;
                audioRequest.PlayRemoteAudio(idUser, 1, 4, transform.position, squares_inc, squares_findTotal, feedbackNow);
                print("Selecionou " + squares_inc + " de " + squares_findTotal + " quadrados.");
            }

            else if(lastCollidingObject.tag == "circle")
            {
                circles_inc++;
                audioRequest.PlayRemoteAudio(idUser, 2, 4, transform.position, circles_inc, circles_findTotal, feedbackNow);
                print("Selecionou " + circles_inc + " de " + circles_findTotal + "circulos.");
            }

            Destroy(lastCollidingObject);
            lastCollidingObject = collidingObject = null;
        }    
        errorTap = false;
    }
}
