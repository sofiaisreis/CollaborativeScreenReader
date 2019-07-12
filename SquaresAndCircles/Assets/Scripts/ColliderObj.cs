using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ColliderObj : MonoBehaviour
{
    public int feedbackType;
    public int feedbackTypeLast;

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
    public bool GodOn = false;
    public int pressGod = 0;
    public bool isG = false;

    public static GameObject lastCollidingObjectGlobal = null;


    private void Start()
    {
        squares_inc = 0;
        circles_inc = 0;
        objectName = "";
    }

    /* CODE OF OBJECT TYPE SOUND
     * 1 - square
     * 2 - circle
     * 3 - triangle
     * 4 - select
     * 5 - exit
     * 6 - errorT
     * 7 - vazio
     */

    // (userID, lastObj, objTypeSound, relativePos1, relativePos2, selecionados, totais);

    private void Update()
    {
        //Private
        if (Input.GetKeyDown(KeyCode.Z))
        {
            feedbackType = 1;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType);
        }
        //Task-Dependent
        if (Input.GetKeyDown(KeyCode.X))
        {
            feedbackType = 2;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType);
        }
        //Public
        if (Input.GetKeyDown(KeyCode.C))
        {
            feedbackType = 3;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType);
        }
        // GOD mode
        if (Input.GetKeyDown(KeyCode.G))
        {
            feedbackTypeLast = feedbackType;
            feedbackType = 4;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType);
            GodOn = true;
            isG = true;
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            feedbackType = feedbackTypeLast;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType);
            GodOn = false;
            pressGod++;
        }
        isG = false;
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

        lastCollidingObject = collidingObject = lastCollidingObjectGlobal = collisionInfo.gameObject;
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

        lastCollidingObject = collidingObject = lastCollidingObjectGlobal = collisionInfo.gameObject;
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

    public void GodSelects()
    {
        int idUser = -1;

        if (lastCollidingObjectGlobal != null)
        {
            if(lastCollidingObjectGlobal.tag == "square")
            {
                actionIsNow = "selected";
                squares_inc++;
                audioRequest.PlayRemoteAudio(idUser, 1, 4, transform.position, squares_inc, squares_findTotal, feedbackType);
                print("Selecionou " + squares_inc + " de " + squares_findTotal + " quadrados.");

                //Destroy(lastCollidingObject);
                lastCollidingObject.SetActive(false);
                lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
            }
            else if (lastCollidingObjectGlobal.tag == "circle")
            {
                actionIsNow = "selected";
                circles_inc++;
                audioRequest.PlayRemoteAudio(idUser, 2, 4, transform.position, circles_inc, circles_findTotal, feedbackType);
                print("Selecionou " + circles_inc + " de " + circles_findTotal + " circulos.");

                //Destroy(lastCollidingObject);
                lastCollidingObject.SetActive(false);
                lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
            }
            else if (lastCollidingObjectGlobal.tag == "triangle")
            {
                actionIsNow = "selected";
                numErros++;
                audioRequest.PlayRemoteAudio(idUser, 3, 6, transform.position, -1, -1, feedbackType);
            }
        }
        else
        {
            audioRequest.PlayRemoteAudio(idUser, -1, 6, transform.position, -1, -1, feedbackType);
            actionIsNow = "error";
        }
    }

    public void SelectObject()
    {
        //int feedbackNow = GetComponent<Logs>().whichFeedback;
        //print("Feedback on collider: " + feedbackType);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        if (errorTap)
        {
            //vazio
            if (lastCollidingObject == null)
            {
                audioRequest.PlayRemoteAudio(idUser, -1, 7, transform.position, -1, -1, feedbackType);
            }
            else
            {
                audioRequest.PlayRemoteAudio(idUser, -1, 6, transform.position, -1, -1, feedbackType);
            }
            actionIsNow = "error";
            numErros++;
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
                actionIsNow = "error";
                numErros++;
                audioRequest.PlayRemoteAudio(idUser, 3, 6, transform.position, -1, -1, feedbackType);
            }

            //Destroy(lastCollidingObject);
            lastCollidingObject.SetActive(false);
            lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
        }    
        errorTap = false;
    }

    private void OnGUI()
    {
        if (feedbackType == 1)
        {
            GUI.Label(new Rect(10, 30, 200, 35), "Feedback Type: Private");
        }
        if (feedbackType == 2)
        {
            GUI.Label(new Rect(10, 30, 200, 35), "Feedback Type: Task-Dependent");
        }
        if (feedbackType == 3)
        {
            GUI.Label(new Rect(10, 30, 200, 35), "Feedback Type: Public");
        }
        if (feedbackType == 4)
        {
            GUI.Label(new Rect(10, 30, 200, 35), "Feedback Type: God knows...");
        }

        if (GodOn) GUI.Label(new Rect(10, 130, 200, 35), "God ON!");
    }
}
