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

    public void IncrementSquares() { squares_inc++; }

    public void IncrementCircles() { circles_inc++; }

    public int GetSquaresInit() { return GameObject.FindGameObjectsWithTag("square").Length; ; }

    public int GetCirclesInit() { return GameObject.FindGameObjectsWithTag("circle").Length; ; }

    public int GetSquaresAtual() { return squares_inc; }

    public int GetCirclesAtual() { return circles_inc; }

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
    * 9 - ErrorTap
    */

    /* CODE OF OBJECTS
     * 1 - square
     * 2 - circle
     * 3 - triangle
     * 4 - select
     * 5 - exit
     * 6 - error
     */

    void OnCollisionEnter(Collision collisionInfo) {

            int idUser = GetComponent<UserTouch>().hand.theUser.userID;

            var objTag = collisionInfo.gameObject.tag;

            if (collidingObject == null)
            { 
                if (objTag == "square")
                {
                    //userIDstring = u.GetComponent<User>().humanID;
                    audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position, -1, -1);
                    //print("ID OF USER: " + u.humanID);
                }
                else if (objTag == "circle")
                {
                    audioRequest.PlayRemoteAudio(idUser, 3, 2, transform.position, - 1, -1);
                }
            }

            lastCollidingObject = collidingObject = collisionInfo.gameObject;
        }

    void OnCollisionStay(Collision collisionInfo)
    {

        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        var objTag = collisionInfo.gameObject.tag;

        if (collidingObject == null)
        {
            if (objTag == "square")
            {
                audioRequest.PlayRemoteAudio(idUser, 1, 1, transform.position, - 1, -1);
            }
            else if (objTag == "circle")
            {
                audioRequest.PlayRemoteAudio(idUser, 3, 2, transform.position, -1, -1);
            }
        }

        lastCollidingObject = collidingObject = collisionInfo.gameObject;
    }

    void OnCollisionExit(Collision collisionInfo)
    {

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

        int idUser = GetComponent<UserTouch>().hand.theUser.userID;

        if (errorTap)
        {
            audioRequest.PlayRemoteAudio(idUser, 9, 6, transform.position, -1, -1);
        }
        else
        {
            if (lastCollidingObject.tag == "square")
            {
                IncrementSquares();
                audioRequest.PlayRemoteAudio(idUser, 7, 4, transform.position, GetSquaresAtual(), squares_findTotal);
                print("Selecionou " + GetSquaresAtual() + "de " + squares_findTotal + ".");
            }

            else if(lastCollidingObject.tag == "circle")
            {
                IncrementCircles();
                audioRequest.PlayRemoteAudio(idUser, 7, 4, transform.position, GetCirclesAtual(), circles_findTotal);
                print("Selecionou " + GetCirclesAtual() + "de " + circles_findTotal + ".");
            }

            Destroy(lastCollidingObject);
            lastCollidingObject = collidingObject = null;
        }    
        errorTap = false;

        // Se já selecionaram tudo, manda mensagem de parabens
        if (GetSquaresAtual() == squares_findTotal && GetCirclesAtual() == circles_findTotal)
        {
            audioRequest.PlayRemoteAudio(idUser, 7, 4, transform.position, 30, 30);
        }
    }
}
