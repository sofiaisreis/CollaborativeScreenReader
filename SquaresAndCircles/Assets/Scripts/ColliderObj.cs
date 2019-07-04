using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ColliderObj : MonoBehaviour
{
    public static int feedbackType;

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
    public string objectName;
    public string actionIsNow = null;
    public int numErros = 0;

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
        actionIsNow = null;
        //int feedbackNow = GetComponent<Logs>().whichFeedback;
        //print("Feedback on collider: " + feedbackType);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        var objTag = collisionInfo.gameObject.tag;

        if (collidingObject == null)
        {
            if (objTag == "square")
            {
                //userIDstring = u.GetComponent<User>().humanID;
                audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position, -1, -1, feedbackType);
                //print("ID OF USER: " + u.humanID);
                objectName = "square";
            }
            else if (objTag == "circle")
            {
                audioRequest.PlayRemoteAudio(idUser, 2, 2, transform.position, -1, -1, feedbackType);
                objectName = "circle";
            }
            else if (objTag == "triangle")
            {
                audioRequest.PlayRemoteAudio(idUser, 3, 3, transform.position, -1, -1, feedbackType);
                objectName = "triangle";
            }
        }

        lastCollidingObject = collidingObject = collisionInfo.gameObject;
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        actionIsNow = null;
        //int feedbackNow = GetComponent<Logs>().whichFeedback;
        //print("Feedback on collider: " + feedbackType);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        var objTag = collisionInfo.gameObject.tag;

        if (collidingObject == null)
        {
            if (objTag == "square")
            {
                audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position, - 1, -1, feedbackType);
                objectName = "square";
            }
            else if (objTag == "circle")
            {
                audioRequest.PlayRemoteAudio(idUser, 2, 2, transform.position, -1, -1, feedbackType);
                objectName = "circle";
            }
            else if (objTag == "triangle")
            {
                audioRequest.PlayRemoteAudio(idUser, 3, 3, transform.position, -1, -1, feedbackType);
                objectName = "triangle";
            }
        }

        lastCollidingObject = collidingObject = collisionInfo.gameObject;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        //int feedbackNow = GetComponent<Logs>().whichFeedback;
        //print("Feedback on collider: " + feedbackType);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        var objTag = collisionInfo.gameObject.tag;
        audioRequest.StopRemoteAudio(idUser);
        objectName = null;

        if (isBeingDragged) {
            //audioRequest.PlayRemoteAudio(idUser, 8, 5, transform.position);

        }

        collidingObject = null;
        actionIsNow = "exit";
    }

    public void SelectObject()
    {
        //int feedbackNow = GetComponent<Logs>().whichFeedback;
        //print("Feedback on collider: " + feedbackType);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        if (errorTap)
        {
            audioRequest.PlayRemoteAudio(idUser, -1, 6, transform.position, -1, -1, feedbackType);
            actionIsNow = "error";
            numErros++; //TO DO , passar
        }
        else
        {
            actionIsNow = "error";
            if (lastCollidingObject.tag == "square")
            {
                actionIsNow = "selected";
                squares_inc++;
                audioRequest.PlayRemoteAudio(idUser, 1, 4, transform.position, squares_inc, squares_findTotal, feedbackType);
                print("Selecionou " + squares_inc + " de " + squares_findTotal + " quadrados.");
            }

            else if(lastCollidingObject.tag == "circle")
            {
                actionIsNow = "selected";
                circles_inc++;
                audioRequest.PlayRemoteAudio(idUser, 2, 4, transform.position, circles_inc, circles_findTotal, feedbackType);
                print("Selecionou " + circles_inc + " de " + circles_findTotal + "circulos.");
            }
            else if(lastCollidingObject.tag == "triangle")
            {
                actionIsNow = "selected";
                numErros++;
                audioRequest.PlayRemoteAudio(idUser, 3, 6, transform.position, -1, -1, feedbackType);
            }

            Destroy(lastCollidingObject);
            lastCollidingObject = collidingObject = null;
        }    
        errorTap = false;
    }
}
