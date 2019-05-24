using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTouch : MonoBehaviour
{
    public GameObject TouchInput;
    public GameObject Hand1;

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
                    MyTouch ourTouch = Hand1.GetComponent<UserHand>().userTouch.touch;

                    //Nada esta a tocar ainda
                    if (ourTouch == null)// && ourT3 == null && ourT4 == null)
                    {
                        //Se estah mais perto da hand1, associar a hand1. CC o oposto
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().Init(touch);
                        Vector3 hand1Pos = Hand1.transform.position;
                        Vector3 touchPos = touchGO.transform.position;
                        Hand1.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                    }
                }
            }
        }
    }
}

