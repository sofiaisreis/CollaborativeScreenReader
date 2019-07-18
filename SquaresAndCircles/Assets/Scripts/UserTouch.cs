﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//it's like hands. Old MyHand
public class UserTouch : MonoBehaviour
{
    public MyTouch touch;
    
    private DateTime lastTapTime;
    private Vector3 lastTapPosition;
    public bool possibleDoubleTap = false;
    public string typeOfTouch = null;

    public UserHand hand;
    //public UserHand uHand2;

    private bool goAway = false;
    private DateTime goAwayTime;
    private Vector3 goAwayPos;

    void Start()
    {
        
    }

    void Update()
    {
        if (touch == null && possibleDoubleTap)
        {
            TimeSpan difLastNowTime = DateTime.Now - lastTapTime;

            if (difLastNowTime.TotalMilliseconds >= 250)
            {
                SingleTap(lastTapPosition);
                possibleDoubleTap = false;
            }
        }

        if(goAway)
        {
            if(goAwayPos != transform.position)
            {
                goAway = false;
            }
            else if((DateTime.Now - goAwayTime).TotalMilliseconds > 100)
            {
                goAway = false;
                GetComponent<ColliderObj>().ignoreNextExit = true;
                transform.position = new Vector3(-1000, -1000, -1000);
            }
        }
    }
    
    public void NewTouchStarts(GameObject touchStart)
    {
        touch = touchStart.GetComponent<MyTouch>(); //Ponteiro para a classe MyTouch
        touch.hand = this; //O MyTouch vai saber que esta mao agora eh dele

    }
    
    public void Drag(Vector3 position)
    {
        transform.position = position;
        typeOfTouch = "drag";
    }

    public void DoubleTap()
    {
        ColliderObj collider = GetComponent<ColliderObj>();

        if (collider.GodOn)
        {
            collider.isG = true;
            collider.GodSelects();
        }
        else
        {
            if (collider.lastCollidingObject != null)
            {
                if ((collider.lastCollidingObject.tag == "square" && hand.theUser.shapeType == ShapeType.Square) ||
                    (collider.lastCollidingObject.tag == "circle" && hand.theUser.shapeType == ShapeType.Circle))
                {
                    collider.SelectObject();
                }
                else
                {
                    // som erro!
                    collider.errorTap = true;
                    collider.SelectObject();
                }
            }
            else
            {
                // seleccao vazia
                collider.lastCollidingObject = null;
                collider.errorTap = true;
                // Som erro
                collider.SelectObject();
                collider.objectHoverName = null;
            }
        }
    }

    public void Tap(Vector3 position)
    {
        if (possibleDoubleTap)
        {
            TimeSpan difLastNowTime = DateTime.Now - lastTapTime;
            float difLastNowPosition = (position - lastTapPosition).magnitude;

            if (difLastNowTime.TotalMilliseconds < 500 && difLastNowPosition < 15) //ver o 15 em coordenadas do mundo
            {
                //print("DOUBLE TAP");
                possibleDoubleTap = false;
                typeOfTouch = "double-tap";
                DoubleTap();
            }
            else
            {
                possibleDoubleTap = true;
            }
        }
        else
        {
            possibleDoubleTap = true;
        }

        lastTapTime = DateTime.Now;
        lastTapPosition = position;
    }

    public void SingleTap(Vector3 position)
    {
        transform.position = position;
        //print("TAP");
        typeOfTouch = "tap";

        goAway = true;
        goAwayTime = DateTime.Now;
        goAwayPos = position;
    }

    public void BeginDrag(Vector3 position)
    {
        possibleDoubleTap = false;
        GetComponent<ColliderObj>().isBeingDragged = true;
        Drag(position);
        //print("DRAG");
    }

    public void EndDrag(Vector3 position)
    {
        GetComponent<ColliderObj>().isBeingDragged = false;
        typeOfTouch = null;

        GetComponent<ColliderObj>().ignoreNextExit = true;
        transform.position = new Vector3(-1000, -1000, -1000);
    }
}

