using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTouch : MonoBehaviour
{

    public GameObject TouchInput;
    public GameObject Hand;
    public GameObject Hand2;
    public GameObject Hand3;
    public GameObject Hand4;
    public int numHands = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {

                    //Suportar multiplos toques
                    if (Hand.GetComponent<MyHand>().touch == null)
                    {
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().touchID = touch.fingerId;

                        Hand.GetComponent<MyHand>().NewTouchStarts(touchGO);
                        numHands=1;
                    }
                    else
                    {
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().touchID = touch.fingerId;

                        if (numHands == 1) {

                            Hand2.GetComponent<MyHand>().NewTouchStarts(touchGO);
                        }
                        else if (numHands == 2)
                        {
                            Hand3.GetComponent<MyHand>().NewTouchStarts(touchGO);
                        }
                        else if (numHands == 3)
                        {
                            Hand4.GetComponent<MyHand>().NewTouchStarts(touchGO);
                        }

                        numHands++;
                        print("Mais que uma mao: " + numHands);
                    }
                    // É preciso escolher a mão livre mais próxima
                }
            }
        }
    }
}
