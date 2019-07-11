using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewTouch : MonoBehaviour
{
    public int userID;
    public GameObject TouchInput;
    public User User1;
    public User User2;
    public float distanceThreshold;

    public int reprocessInterval;
    private DateTime lastReprocess;
    public int repro = 0;
    public bool isRep = false;

    void Start()
    {
        lastReprocess = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReprocessTouches();
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            repro++;
            isRep = true;
        }
        isRep = false;
        if (Input.touchCount > 0)
        {
            //  print("Touch!");

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    ProcessNewTouch(touch);
                }
            }

            if (reprocessInterval >= 0)
            {
                if ((DateTime.Now - lastReprocess).TotalMilliseconds > reprocessInterval)
                {
                    if (
                        ((User1.handRight.userTouch.touch == null && !User1.handRight.userTouch.possibleDoubleTap) || (User1.handRight.userTouch.touch != null && User1.handRight.userTouch.touch.isDrag)) &&
                        ((User2.handRight.userTouch.touch == null && !User2.handRight.userTouch.possibleDoubleTap) || (User2.handRight.userTouch.touch != null && User2.handRight.userTouch.touch.isDrag))
                        )
                    {
                        if (Vector3.Distance(User1.handRight.transform.position, User2.handRight.transform.position) > distanceThreshold &&
                            Vector3.Distance(User1.handLeft.transform.position, User2.handRight.transform.position) > distanceThreshold &&
                            Vector3.Distance(User1.handRight.transform.position, User2.handLeft.transform.position) > distanceThreshold &&
                            Vector3.Distance(User1.handLeft.transform.position, User2.handLeft.transform.position) > distanceThreshold
                            )
                        {
                            lastReprocess = DateTime.Now;
                            ReprocessTouches();
                        }
                    }
                }
            }
        }
    }

    private void ReprocessTouches()
    {
        if (User1.handRight.userTouch.touch != null)
            Destroy(User1.handRight.userTouch.touch.gameObject);

        if (User2.handRight.userTouch.touch != null)
            Destroy(User2.handRight.userTouch.touch.gameObject);

        User1.handRight.userTouch.touch = User2.handRight.userTouch.touch = null;

        foreach (Touch touch in Input.touches)
        {
            MyTouch mt = ProcessNewTouch(touch);
            if (mt != null)
                mt.setDrag();
        }
    }

    private MyTouch ProcessNewTouch(Touch touch)
    {
        //Suportar multiplos toques
        MyTouch touchUser1 = User1.handRight.userTouch.touch;
        MyTouch touchUser2 = User2.handRight.userTouch.touch;

        Vector3 user1RightHPos = User1.handRight.transform.position;
        Vector3 user1LeftHPos = User1.handLeft.transform.position;
        Vector3 user2RightHPos = User2.handRight.transform.position;
        Vector3 user2LeftHPos = User2.handLeft.transform.position;

        Vector3 touchPos = MyTouch.GetTouchWorldPosition(touch);

        // distancias User 1
        float dUser1 = Mathf.Min(Vector3.Distance(user1RightHPos, touchPos), Vector3.Distance(user1LeftHPos, touchPos));

        // distancias User 2
        float dUser2 = Mathf.Min(Vector3.Distance(user2RightHPos, touchPos), Vector3.Distance(user2LeftHPos, touchPos));

        //Nada esta a tocar ainda
        if (touchUser1 == null && touchUser2 == null)// && ourT3 == null && ourT4 == null)
        {
            //Se estah mais perto da hand1, associar a hand1. CC o oposto
            GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
            touchGO.GetComponent<MyTouch>().Init(touch);

            // escolhe mao 1
            if (dUser1 < dUser2)
            {
                User1.handRight.userTouch.NewTouchStarts(touchGO);
                //Hand3.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                //print("entrei 1: A");
            }
            else
            {
                User2.handRight.userTouch.NewTouchStarts(touchGO);
                //Hand4.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                //print("entrei 2: A");
            }

            return touchGO.GetComponent<MyTouch>();
        }
        // User 1 esta a tocar
        else if (touchUser1 != null && touchUser2 == null)
        {
            // sera o User 2
            if (dUser2 < distanceThreshold)
            {
                GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                touchGO.GetComponent<MyTouch>().Init(touch);
                User2.handRight.userTouch.NewTouchStarts(touchGO);
                //Hand4.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                //print("entrei 2: B");

                return touchGO.GetComponent<MyTouch>();
            }
        }
        // User 2 esta a tocar
        else if (touchUser1 == null && touchUser2 != null)
        {
            // sera o User 1
            if (dUser1 < distanceThreshold)
            {
                GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                touchGO.GetComponent<MyTouch>().Init(touch);
                User1.handRight.userTouch.NewTouchStarts(touchGO);
                // Hand3.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                //print("entrei 1: C");

                return touchGO.GetComponent<MyTouch>();
            }
        }

        return null;
    }
}

