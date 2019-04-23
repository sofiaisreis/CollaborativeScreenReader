using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTouch : MonoBehaviour
{

    public GameObject TouchInput;
    public GameObject Hand1;
    public GameObject Hand2;
    public int userID;
    public int numTouches = 0;
    public int trackTouch;
    private Random rnd = new Random();

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
           /*     
                if (Input.touches.Length == 1)
                    Debug.Log("    " + Input.touches[0].fingerId);

                if (Input.touches.Length == 2)
                    Debug.Log("    " + Input.touches[0].fingerId
                            + "    " + Input.touches[1].fingerId
                            );

                if (Input.touches.Length == 3)
                    Debug.Log("    " + Input.touches[0].fingerId
                            + "    " + Input.touches[1].fingerId
                            + "    " + Input.touches[2].fingerId
                            );
                
                for (int i = 0; i < Input.touches.Length; i++)
                {
                    processATouchPerFingerCodeNumber(Input.touches[i], Input.touches[i].fingerId);
                }
                */
                if (touch.phase == TouchPhase.Began)
                {
                    //Suportar multiplos toques
                    // Ver logo hand do player, eventualmente seguir o player e depois o toque mais perto do corpo dele 
                    // significa que eh essa a sua mao
                    MyTouch ourT1 = Hand1.GetComponent<UserHand>().userTouch.touch;
                    MyTouch ourT2 = Hand2.GetComponent<UserHand>().userTouch.touch;

                    //Nada esta a tocar ainda
                    if (ourT1 == null && ourT2 == null)
                    {
                        //Se estah mais perto da hand1, associar a hand1. CC o oposto
                        // if ((ourT1.GetTouchWorldPosition(touch) - Hand1.transform.position).magnitude <= (ourT2.GetTouchWorldPosition(touch) - Hand2.transform.position).magnitude) 
                        {
                            GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                            touchGO.GetComponent<MyTouch>().Init(touch);
                            Vector3 hand1Pos = Hand1.transform.position;
                            Vector3 hand2Pos = Hand2.transform.position;
                            Vector3 touchPos = touchGO.transform.position;
                            print("Touch Position:" + touchPos);

                            // escolhe mao 1
                            if (Vector3.Distance(hand1Pos, touchPos) <= Vector3.Distance(hand2Pos, touchPos))
                            {
                                Hand1.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                                print("entrei 1: A");
                            }
                            else
                            {
                                Hand2.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                                print("entrei 2: A");
                            }
                            //id da mao
                            userID = 1;
                        }
                    }
                    else if (ourT1 != null && ourT2 == null)
                    {
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().Init(touch);
                        Hand2.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                        numTouches = 2;
                        //id da mao
                        print("entrei 2: B");
                        userID = 2;
                    }
                    else if (ourT1 == null && ourT2 != null)
                    {
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().Init(touch);
                        Hand1.GetComponent<UserHand>().userTouch.NewTouchStarts(touchGO);
                        numTouches = 2;
                        //id da mao
                        userID = 2;
                        print("entrei 1: C");
                    }

                    /*Ja ha toques
                    else
                    {
                        if (numTouches > 0)
                        {
                            GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                            print("TOUCH GO : " + touchGO);
                            touchGO.GetComponent<MyTouch>().touchID = touch.fingerId;
                            Hand2.GetComponent<UserTouch>().NewTouchStarts(touchGO);
                            numTouches = 2;
                            //id da mao
                            userID = 2;
                            print("2 maos");
                        }
                    }*/
                }

                //o toque ja existe
               /* else VER
                {
                    GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                    touchGO.GetComponent<MyTouch>().touchID = touch.fingerId;
                }*/
            }
        }
        else
        {
            
        }
    }
    //print("Ha " + numHands + " maos." );


   public void processATouchPerFingerCodeNumber(Touch t, int n)
    {
        if (t.phase == TouchPhase.Began)
        {
            Debug.Log("A finger has ARRIVED.  it's arbitrary code number is: " + n);
        }
        if (t.phase == TouchPhase.Ended ||t.phase == TouchPhase.Canceled)
        {
            Debug.Log("A finger has ARRIVED.  it's arbitrary code number is: " + n);
        }
        if (t.phase == TouchPhase.Moved)
        {
            Debug.Log("You moved this finger: " + n);
        }

        }

   GameObject GetClosestMiniCube()
    {
        GameObject[] gameObjs;
        gameObjs = GameObject.FindGameObjectsWithTag("handdown");
        GameObject closest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject gameObj in gameObjs)
        {
            Vector3 diff = gameObj.transform.position - currentPos;
            float currentDis = diff.sqrMagnitude;
            if (currentDis < minDist)
            {
                closest = gameObj;
                minDist = currentDis;
            }
        }
        return closest;
    }
}
