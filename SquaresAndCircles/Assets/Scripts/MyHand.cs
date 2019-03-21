using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyHand : MonoBehaviour
{
    public MyTouch touch;
    
    private DateTime lastTapTime;
    private Vector3 lastTapPosition;
    private bool possibleDoubleTap = false;


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
    }
    
    public void NewTouchStarts(GameObject touchStart)
    {
        touch = touchStart.GetComponent<MyTouch>(); //Ponteiro para a classe MyTouch
        touch.hand = this;

    }


    public void Drag(Vector3 position)
    {
        transform.position = position;
    }

    public void DoubleTap()
    {
        if (GetComponent<ColliderObj>().collidingObject != null)
        {
            GetComponent<ColliderObj>().SelectObject();
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
                print("DOUBLE TAP");
                possibleDoubleTap = false;

                DoubleTap();
            }
            else
            {
                SingleTap(position);
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
        print("TAP");
    }

    public void BeginDrag(Vector3 position)
    {
        GetComponent<ColliderObj>().isBeingDragged = true;
        Drag(position);
        print("DRAG");
    }

    public void EndDrag(Vector3 position)
    {
        GetComponent<ColliderObj>().isBeingDragged = false;
    }

}
