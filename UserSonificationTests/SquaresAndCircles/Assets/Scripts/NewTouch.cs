using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTouch : MonoBehaviour
{
    public int userID;
    public GameObject TouchInput;
    public GameObject Hand1;
    public GameObject Hand2;
    // for 2 more hands
   /* public GameObject Hand3;
    public GameObject Hand4;*/

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
                    MyTouch ourT1 = Hand1.GetComponent<UserHand>().userTouch.touch;
                    MyTouch ourT2 = Hand2.GetComponent<UserHand>().userTouch.touch;
                    // more 2 touches, since we have 4 hands
                    /* MyTouch ourT3 = Hand3.GetComponent<UserHand>().userTouch.touch;
                     MyTouch ourT4 = Hand4.GetComponent<UserHand>().userTouch.touch;
                     */

                    //Nada esta a tocar ainda
                    if (ourT1 == null && ourT2 == null)// && ourT3 == null && ourT4 == null)
                    {
                        //Se estah mais perto da hand1, associar a hand1. CC o oposto
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().Init(touch);
                        Vector3 hand1Pos = Hand1.transform.position;
                        Vector3 hand2Pos = Hand2.transform.position;
                        //Vector3 hand3Pos = Hand3.transform.position;
                        //Vector3 hand4Pos = Hand4.transform.position;
                        Vector3 touchPos = touchGO.transform.position;
                        //print("Touch Position:" + touchPos);
                        
                        // escolhe mao 1
                        if (Vector3.Distance(hand1Pos, touchPos) <= Vector3.Distance(hand2Pos, touchPos))
                        {
                            Hand1.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                            //Hand3.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                            //print("entrei 1: A");
                        }
                        else
                        {
                            Hand2.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                            //Hand4.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                            //print("entrei 2: A");
                        }
                    }
                    else if (ourT1 != null && ourT2 == null)
                    {
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().Init(touch);
                        Hand2.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                        //Hand4.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                        //print("entrei 2: B");
                    }
                    else if (ourT1 == null && ourT2 != null)
                    {
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().Init(touch);
                        Hand1.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                       // Hand3.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                        //print("entrei 1: C");
                    }
                }
            }
        }
    }
}

