using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTouch : MonoBehaviour
{
    public int userID;
    public GameObject TouchInput;
    public User User1;
    public User User2;
    public float distanceThreshold;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            //  print("Touch!");

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
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
                        }
                    }
                }
            }
        }
    }
}

