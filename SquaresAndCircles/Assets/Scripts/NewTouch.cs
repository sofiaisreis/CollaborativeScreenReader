using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTouch : MonoBehaviour
{

    public GameObject TouchInput;
    public GameObject Hand1;
    public GameObject Hand2;
    //public GameObject Hand3;
    //public GameObject Hand4;
    public int numHands = 0;
    //public Transform touchPosition;

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
                numHands++;
                if (touch.phase == TouchPhase.Began)
                {

                    //Suportar multiplos toques
                    MyTouch ourT = Hand1.GetComponent<UserTouch>().touch;
                        if (ourT == null)
                        {
                            GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                            touchGO.GetComponent<MyTouch>().touchID = touch.fingerId;
                            //print("Touch Position: " + touch.position.magnitude);
                            //print("Hand Position: " + GameObject.FindObjectsOfType(GetClosestMiniCube()).transform.position);

                            Hand1.GetComponent<UserTouch>().NewTouchStarts(touchGO);

                            //Debug.Log("Objeto eh: " + GetClosestMiniCube());
                            numHands++;
                        }
                     //o toque ja existe
                    else
                    {
                        GameObject touchGO = Instantiate(TouchInput, Vector3.zero, Quaternion.identity);
                        touchGO.GetComponent<MyTouch>().touchID = touch.fingerId;
                        
                    }   
                }
            }
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
