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
    public int lastFeedbackPress = -1;
    public bool isBeingDragged = false;
    public bool errorTap = false;
    public bool ignoreNextExit = false;
    public GameObject collidingObject = null;
    public AudioRequest audioRequest;
    public Logs loggs;
    public User u;
    public TrackerClient trackedUser;
    public UserHand uHand;
    public int squares_inc = 0;
    public int circles_inc = 0;
    public int squares_findTotal = 5;
    public int circles_findTotal = 5;
    public GameObject lastCollidingObject = null;
    public string objectLastCollidingName;
    public string objectHoverName;
    public string actionIsNow = null;
    public int numErros = 0;
    public bool GodOn = false;
    public int pressGod = 0;
    public bool isG = false;
    public bool PressingG = false;
    public bool godUp = true;
    public bool LuciUp = true;
    public bool LuciOn = false;
    public DateTime haveTime;
    public TimeSpan startG;
    public TimeSpan endG;
    public DateTime haveTimeLuci;
    public TimeSpan startLuci;
    public TimeSpan endLuci;
    public GameObject theTouch;
    public bool TooCloseGoesLuci;
    public int lastObjectType = -2;
    public bool LuciSwitch = false;

    public double LuciTempo;

    public static GameObject lastCollidingObjectGlobal = null;


    private void Start()
    {
        objectLastCollidingName = "";
        objectHoverName = "";
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

        squares_findTotal = 5;
        circles_findTotal = 5;
        if (Input.GetKeyDown(KeyCode.A))
        {
            squares_findTotal = 5;
            circles_findTotal = 5;
            circles_inc = 0;
            squares_inc = 0;
            haveTime = DateTime.Now;
            haveTimeLuci = DateTime.Now;
            audioRequest.PlayRemoteAudio(-1, -2, -1, transform.position, -1, -1, feedbackType, -2, lastFeedbackPress);
            LuciTempo = 0;
        }
        //Reiniciar valores de incrementos no som:  passar -2 no lastObj

            //Private
            if (Input.GetKeyDown(KeyCode.Z))
        {
            feedbackType = 1;
            lastFeedbackPress = 1;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
        }
        //Task-Dependent
        if (Input.GetKeyDown(KeyCode.X))
        {
            feedbackType = 2;
            lastFeedbackPress = 2;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
        }
        //Public
        if (Input.GetKeyDown(KeyCode.C))
        {
            feedbackType = 3;
            lastFeedbackPress = 3;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
        }
        // GOD mode
        if (Input.GetKeyDown(KeyCode.G))
        {
            feedbackTypeLast = feedbackType;
            feedbackType = 4;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
            GodOn = true;
            PressingG = true;
            startG = DateTime.Now - haveTime;
            godUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            feedbackType = feedbackTypeLast;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
            GodOn = false;
            PressingG = false;
            isG = false;
            pressGod++;
            godUp = false;
            endG = DateTime.Now - haveTime;
        }
        /*// Emergency and for Testing Luci Mode
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Luci On");
            feedbackTypeLast = feedbackType;
            feedbackType = 6;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
            LuciOn = true;
            startLuci = DateTime.Now - haveTimeLuci;
            LuciUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            print("Luci Off");
            feedbackType = feedbackTypeLast;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
            LuciOn = false;
            endLuci = DateTime.Now - haveTimeLuci;
            LuciTempo += (endLuci - startLuci).TotalMilliseconds;
            LuciUp = false;
        }
      */ ///* 
        if (theTouch.GetComponent<NewTouch>().handsTooCloseLuci && feedbackType != 6) {
            //LuciMode
            feedbackTypeLast = feedbackType;
            feedbackType = 6;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
            startLuci = DateTime.Now - haveTimeLuci;
            LuciOn = true;
        }
        if (!theTouch.GetComponent<NewTouch>().handsTooCloseLuci && feedbackType == 6) {
            //LuciModeEnds
            print("Saiu do Luci");
            feedbackType = feedbackTypeLast;
            audioRequest.PlayRemoteAudio(-1, -1, -1, transform.position, -1, -1, feedbackType, lastObjectType, lastFeedbackPress);
            endLuci = DateTime.Now - haveTimeLuci;
            LuciOn = false;
            LuciTempo += (endLuci - startLuci).TotalMilliseconds;
        }
    //    */
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        actionIsNow = "in_objeto";
        //int feedbackNow = GetComponent<Logs>().whichFeedback;
        //print("Feedback on collider: " + feedbackType);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;
        var objTag = collisionInfo.gameObject.tag;

         //Verificar logo se é Luci
        if (feedbackType == 6)
        {
            if (collidingObject == null)
            {
                if (objTag == "square")
                {
                    //userIDstring = u.GetComponent<User>().humanID;
                    lastObjectType = 1;
                    audioRequest.PlayRemoteAudio(1, 1, 1, transform.position, -1, -1, feedbackType, 1, lastFeedbackPress);
                    //print("ID OF USER: " + u.humanID);
                    objectLastCollidingName = "square";
                    objectHoverName = "square";
                }
                else if (objTag == "circle")
                {
                    lastObjectType = 2;
                    audioRequest.PlayRemoteAudio(2, 2, 2, transform.position, -1, -1, feedbackType, 2, lastFeedbackPress);
                    objectLastCollidingName = "circle";
                    objectHoverName = "circle";
                }
                //ignora os triangulos
                print("lastObjectType: " + lastObjectType);
            }

            lastCollidingObject = collidingObject = lastCollidingObjectGlobal = collisionInfo.gameObject;
        }
        else
        {
            if (collidingObject == null)
            {
                if (objTag == "square")
                {
                    //userIDstring = u.GetComponent<User>().humanID;
                    audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position, -1, -1, feedbackType, 1, lastFeedbackPress);
                    //print("ID OF USER: " + u.humanID);
                    objectLastCollidingName = "square";
                    objectHoverName = "square";
                }
                else if (objTag == "circle")
                {
                    audioRequest.PlayRemoteAudio(idUser, 2, 2, transform.position, -1, -1, feedbackType, 2, lastFeedbackPress);
                    objectLastCollidingName = "circle";
                    objectHoverName = "circle";
                }
                else if (objTag == "triangle")
                {
                    audioRequest.PlayRemoteAudio(idUser, 3, 3, transform.position, -1, -1, feedbackType, 3, lastFeedbackPress);
                    objectLastCollidingName = "triangle";
                    objectHoverName = "triangle";
                }
            }

            lastCollidingObject = collidingObject = lastCollidingObjectGlobal = collisionInfo.gameObject;
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        //int feedbackNow = GetComponent<Logs>().whichFeedback;
        //print("Feedback on collider: " + feedbackType);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;
        var objTag = collisionInfo.gameObject.tag;
        actionIsNow = "in_objeto";

        //Luci Mode
        if (feedbackType == 6)
        {
            if (collidingObject == null)
            {
                if (objTag == "square")
                {
                    lastObjectType = 1;
                    //userIDstring = u.GetComponent<User>().humanID;
                    audioRequest.PlayRemoteAudio(1, 1, 1, transform.position, -1, -1, feedbackType, 1, lastFeedbackPress);
                    //print("ID OF USER: " + u.humanID);
                    objectLastCollidingName = "square";
                    objectHoverName = "square";
                }
                else if (objTag == "circle")
                {
                    lastObjectType = 2;
                    audioRequest.PlayRemoteAudio(2, 2, 2, transform.position, -1, -1, feedbackType, 2, lastFeedbackPress);
                    objectLastCollidingName = "circle";
                    objectHoverName = "circle";
                }
                //ignora os triangulos
            }

            lastCollidingObject = collidingObject = lastCollidingObjectGlobal = collisionInfo.gameObject;
        }
        else
        {
            if (collidingObject == null)
            {
                if (objTag == "square")
                {
                    audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position, -1, -1, feedbackType, 1, lastFeedbackPress);
                    objectLastCollidingName = "square";
                    objectHoverName = "square";
                }
                else if (objTag == "circle")
                {
                    audioRequest.PlayRemoteAudio(idUser, 2, 2, transform.position, -1, -1, feedbackType, 2, lastFeedbackPress);
                    objectLastCollidingName = "circle";
                    objectHoverName = "circle";
                }
                else if (objTag == "triangle")
                {
                    audioRequest.PlayRemoteAudio(idUser, 3, 3, transform.position, -1, -1, feedbackType, 3, lastFeedbackPress);
                    objectLastCollidingName = "triangle";
                    objectHoverName = "triangle";
                }
            }
            lastCollidingObject = collidingObject = lastCollidingObjectGlobal = collisionInfo.gameObject;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        actionIsNow = "exit";
        objectHoverName = "";
        //int feedbackNow = GetComponent<Logs>().whichFeedback;
        //print("Feedback on collider: " + feedbackType);
        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        var objTag = collisionInfo.gameObject.tag;

        if (!ignoreNextExit)
        {
            audioRequest.StopRemoteAudio(idUser);
        }
        else
        {
            ignoreNextExit = false;
        }

        if (isBeingDragged) {
            //audioRequest.PlayRemoteAudio(idUser, 8, 5, transform.position);

        }
        collidingObject = null;
    }

    public void SelectObject()
    {
        int idUser;

        //para Modo Normal
        idUser = GetComponent<UserTouch>().hand.theUser.userID;

        // God Mode
        if (feedbackType == 4)
        {
            idUser = -1;
            isG = true;

            if (lastCollidingObjectGlobal != null)
            {
                if (lastCollidingObjectGlobal.tag == "square")
                {
                    actionIsNow = "selected";
                    squares_inc++;
                    audioRequest.PlayRemoteAudio(idUser, 1, 4, transform.position, squares_inc, squares_findTotal, feedbackType, 1, lastFeedbackPress);
                    print("Selecionou " + squares_inc + " de " + squares_findTotal + " quadrados.");

                    //Destroy(lastCollidingObject);
                    lastCollidingObject.SetActive(false);
                    objectHoverName = "";
                    objectLastCollidingName = "square";
                    lastObjectType = -1;
                    lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
                }
                else if (lastCollidingObjectGlobal.tag == "circle")
                {
                    actionIsNow = "selected";
                    circles_inc++;
                    audioRequest.PlayRemoteAudio(idUser, 2, 4, transform.position, circles_inc, circles_findTotal, feedbackType, 2, lastFeedbackPress);
                    print("Selecionou " + circles_inc + " de " + circles_findTotal + " circulos.");

                    //Destroy(lastCollidingObject);
                    lastCollidingObject.SetActive(false);
                    objectHoverName = "";
                    objectLastCollidingName = "circle";
                    lastObjectType = -1;
                    lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
                }
                else if (lastCollidingObjectGlobal.tag == "triangle")
                {
                    actionIsNow = "error";
                    numErros++;
                    objectHoverName = "";
                    objectLastCollidingName = "triangle";
                    audioRequest.PlayRemoteAudio(idUser, 3, 6, transform.position, -1, -1, feedbackType, 3, lastFeedbackPress);
                }
                //Destroy(lastCollidingObject);
                lastCollidingObject.SetActive(false);
                lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
            }
            else
            {
                audioRequest.PlayRemoteAudio(idUser, -1, 6, transform.position, -1, -1, feedbackType, -1, lastFeedbackPress);
                actionIsNow = "error";
            }
        }
        // Luci Mode TODO
        if (feedbackType == 6)
        {
            if (lastCollidingObjectGlobal != null)
            {
                if (lastCollidingObjectGlobal.tag == "square")
                {
                    actionIsNow = "selected";
                    squares_inc++;
                    audioRequest.PlayRemoteAudio(1, 1, 4, transform.position, squares_inc, squares_findTotal, feedbackType, 1, lastFeedbackPress);
                    print("Selecionou " + squares_inc + " de " + squares_findTotal + " quadrados.");

                    //Destroy(lastCollidingObject);
                    lastCollidingObject.SetActive(false);
                    objectHoverName = "";
                    objectLastCollidingName = "square";
                    lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
                    lastObjectType = 1;
                    if(idUser == 2)
                    {
                        objectLastCollidingName = "";
                    }
                }
                else if (lastCollidingObjectGlobal.tag == "circle")
                {
                    actionIsNow = "selected";
                    circles_inc++;
                    audioRequest.PlayRemoteAudio(2, 2, 4, transform.position, circles_inc, circles_findTotal, feedbackType, 2, lastFeedbackPress);
                    print("Selecionou " + circles_inc + " de " + circles_findTotal + " circulos.");

                    //Destroy(lastCollidingObject);
                    lastCollidingObject.SetActive(false);
                    objectHoverName = "";
                    objectLastCollidingName = "circle";
                    lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
                    lastObjectType = 2;
                    if (idUser == 1)
                    {
                        objectLastCollidingName = "";
                    }
                }
            }
        }
        else
        {
            if (errorTap)
            {
                //vazio
                if (lastCollidingObject == null)
                {
                    audioRequest.PlayRemoteAudio(idUser, -1, 7, transform.position, -1, -1, feedbackType, -1, lastFeedbackPress);
                    actionIsNow = "vazio";
                }
                else
                {
                    audioRequest.PlayRemoteAudio(idUser, -1, 6, transform.position, -1, -1, feedbackType, -1, lastFeedbackPress);
                    actionIsNow = "error";
                }
                numErros++;
            }
            else
            {
                if (lastCollidingObject.tag == "square")
                {
                    actionIsNow = "selected";
                    squares_inc++;
                    audioRequest.PlayRemoteAudio(idUser, 1, 4, transform.position, squares_inc, squares_findTotal, feedbackType, 1, lastFeedbackPress);
                    print("Selecionou " + squares_inc + " de " + squares_findTotal + " quadrados.");
                    objectLastCollidingName = "square";
                    objectHoverName = "";
                }

                else if (lastCollidingObject.tag == "circle")
                {
                    actionIsNow = "selected";
                    circles_inc++;
                    audioRequest.PlayRemoteAudio(idUser, 2, 4, transform.position, circles_inc, circles_findTotal, feedbackType, 2, lastFeedbackPress);
                    print("Selecionou " + circles_inc + " de " + circles_findTotal + "circulos.");
                    objectLastCollidingName = "circle";
                    objectHoverName = "";
                }
                else if (lastCollidingObject.tag == "triangle")
                {
                    actionIsNow = "error";
                    numErros++;
                    objectLastCollidingName = "triangle";
                    objectHoverName = "triangle";
                    audioRequest.PlayRemoteAudio(idUser, 3, 6, transform.position, -1, -1, feedbackType, 3, lastFeedbackPress);
                }

                //Destroy(lastCollidingObject);
                lastCollidingObject.SetActive(false);
                lastCollidingObject = collidingObject = lastCollidingObjectGlobal = null;
            }
            errorTap = false;
        }
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
        if (feedbackType == 6)
        {
            GUI.Label(new Rect(260, 30, 700, 35), "Feedback Type: Luci Mode ; " + "Last Feedback Pressed: " + lastFeedbackPress);
        }
        if (LuciOn)
        {
            GUI.Label(new Rect(260, 30, 700, 35), "Feedback Type: Luci Mode ; Last Object Type: " + lastObjectType + "Last Feedback Pressed: " + lastFeedbackPress);
        }
        if (GodOn) GUI.Label(new Rect(10, 130, 200, 35), "God ON!");
    }
}
