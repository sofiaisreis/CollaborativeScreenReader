using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowMouse : MonoBehaviour
{
    public float distance = 1.0f;
    public bool useInitalCameraDistance = false;
    private float actualDistance;
    private DateTime timestart;
    private Vector3 positionstart;
    private DateTime lastTapTime;
    private Vector3 lastTapPosition;
    private bool possibleDoubleTap = false;
    private int touchType = -1;
    /* 0 - Tap; 
     * 1 - Double Tap; 
     * 2 - Drag*/

    // Use this for initialization
    void Start()
    {
        if (useInitalCameraDistance)
        {
            Vector3 toObjectVector = transform.position - Camera.main.transform.position;
            Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
            actualDistance = linearDistanceVector.magnitude;
        }
        else
        {
            actualDistance = distance;
        }
        print("lastTapTime:" + lastTapTime + " and pos: " + lastTapPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timestart = DateTime.Now;
            positionstart = Input.mousePosition;
            touchType = -1;
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            // Debug.Log(transform.position);
            TimeSpan difTime = DateTime.Now - timestart;
            float difDist = (Input.mousePosition - positionstart).magnitude;

            if (touchType == -1)
            {
                if (difTime.TotalMilliseconds >= 250 || difDist >= 10)
                {
                    print("Eh um DRAG");
                    touchType = 2;
                }
            }

            if (touchType == 2)
            {
                Drag();
            }
        }
        
        //printing timestamp
        //Debug.Log(DateTime.Now.ToString("yyyyMMddHHmmssffff"));

        if (Input.GetMouseButtonUp(0))
        {
            TimeSpan difTime = DateTime.Now - timestart;
            float difDist = (Input.mousePosition - positionstart).magnitude;
            //print("DifTime: " + difTime.TotalMilliseconds + " DifPos: " + difDist);

            if(difTime.TotalMilliseconds < 250 && difDist < 10)
            {
                //print("Eh um TAP");
                //touchType = 1;

                if (possibleDoubleTap)
                {
                    TimeSpan difLastNowTime = timestart - lastTapTime;
                    float difLastNowPosition = (positionstart - lastTapPosition).magnitude;

                    if (difLastNowTime.TotalMilliseconds < 249 && difLastNowPosition < 15)
                    {
                        print("Eh DOUBLE TAP");
                        touchType = 2;
                        possibleDoubleTap = false;

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
                lastTapPosition = Input.mousePosition;
            }
        }

        if(!Input.GetMouseButton(0))
        {
            if (possibleDoubleTap && touchType == -1 && (DateTime.Now - lastTapTime).TotalMilliseconds >= 249)
            {
                print("Eh um TAP");
                touchType = 1;
                GetComponent<ColliderObj>().tapToProcess = true;

                Tap();
            }

            else if (touchType == 1)
            {
                Tap();
            }
        }
    }

    private void Drag()
    {
        moveTheMiniCube(Input.mousePosition);
    }

    private void DoubleTap()
    {

    }

    private void Tap()
    {
        moveTheMiniCube(lastTapPosition);
    }

    private void moveTheMiniCube(Vector3 position)
    {
        Vector3 mousePosition = position;
        mousePosition.z = actualDistance;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}