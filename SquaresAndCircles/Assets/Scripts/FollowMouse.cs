using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// DOUBLE TAP E DRAG FUNCIONAN
// TAP NEM SEMPRE
// TAPS SEPARADAS EM OBJETOS CONCORRENTES NAO ENTRA EM COLISION

public class FollowMouse : MonoBehaviour
{
    //public GameObject TouchInput;
    public float distance = 1.0f;
    public bool useInitalCameraDistance = false;
    private float actualDistance;
    private DateTime timestart;
    private Vector3 positionstart;
    private DateTime lastTapTime;
    private Vector3 lastTapPosition;
    private bool possibleDoubleTap = false;
    private int touchType = -1;
    /* 1 - Tap; 
     * 2 - Double Tap; 
     * 3 - Drag*/

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
        //print("lastTapTime:" + lastTapTime + " and pos: " + lastTapPosition);

       /* for (int i = 0; i < 3; i++)
        {
            Instantiate(gameObject, new Vector3(i*1,0,4), Quaternion.identity);
        }*/

    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.touchCount > 0)
        {
            //print("In: " + (Input.GetTouch(0).position).magnitude);
            // O fingerId mostra o numero de dedos a moverem/na mesa
            //Debug.Log("Touch Struct: " + touch.position.magnitude);
            //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Touch touchStruct = Input.touches[0];
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = touch.position;

            //Buttondown

            if (touch.phase == TouchPhase.Began)
            {
                timestart = DateTime.Now;
                positionstart = touchPosition;
                //Instantiate(TouchInput, positionstart, Quaternion.identity);
                //Debug.Log("Identity is: " + Quaternion.identity);
                touchType = -1;
            }

        //Input.GetMouseButton(0) || //Estah ou sempre a mover ou selecionado parado 
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved || Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                // Debug.Log(transform.position);
                TimeSpan difTime = DateTime.Now - timestart;
                float difDist = (touchPosition - positionstart).magnitude;

             
                    if (difTime.TotalMilliseconds >= 250 || difDist >= 10)
                    {
                        GetComponent<ColliderObj>().isBeingDragged = true;
                        //print(GetComponent<ColliderObj>().isBeingDragged);
                        touchType = 3;
                        print("DRAG: " + touchType);
                }
                   
                    if (touchType == 3)
                    {
                        Vector3 begginDrag = touch.position;
                        Drag();
                    }
            }

            //printing timestamp
            //Debug.Log(DateTime.Now.ToString("yyyyMMddHHmmssffff"));

            //Button up
            if (touch.phase == TouchPhase.Ended)
            {
                TimeSpan difTime = DateTime.Now - timestart;
                float difDist = (touchPosition - positionstart).magnitude;
                //print("DifTime: " + difTime.TotalMilliseconds + " DifPos: " + difDist);
                GetComponent<ColliderObj>().isBeingDragged = false;
                if (difTime.TotalMilliseconds < 250 && difDist < 10)
                {
                    if (possibleDoubleTap)
                    {
                        TimeSpan difLastNowTime = timestart - lastTapTime;
                        float difLastNowPosition = (positionstart - lastTapPosition).magnitude;

                        if (difLastNowTime.TotalMilliseconds < 249 && difLastNowPosition < 15)
                        {
                            touchType = 2;
                            print("DOUBLE TAP: " + touchType);
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
                    lastTapPosition = touchPosition;
                }
            }

            // if(touch.phase != TouchPhase.Stationary)
            //{
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary || Input.touchCount > 0)
            {
                if (possibleDoubleTap && touchType == -1 && (DateTime.Now - lastTapTime).TotalMilliseconds >= 249)
                {
                    touchType = 1;
                    print("TAP: " + touchType);
                    GetComponent<ColliderObj>().tapToProcess = true;

                    Tap();
                }
                else if (touchType == 1)
                {
                    Tap();
                }
            }
        //Debug.Log("touch type: " + touchType);
        }
    }

    private void Drag()
    {
        moveTheMiniCube(Input.GetTouch(0).position);
    }

    private void DoubleTap()
    {
        if(GetComponent<ColliderObj>().collidingObject != null)
        {
            GetComponent<ColliderObj>().SelectObject();
        }
    }

    private void Tap()
    {
        moveTheMiniCube(lastTapPosition);
    }

    private void moveTheMiniCube(Vector3 position)
    {
        Vector3 touchPosition = position;
        touchPosition.z = actualDistance;
        transform.position = Camera.main.ScreenToWorldPoint(touchPosition);
    }
}