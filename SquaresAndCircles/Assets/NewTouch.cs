using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTouch : MonoBehaviour
{

    public GameObject TouchInput;
    public GameObject Hand; //vou ter mais instancias
    // Start is called before the first frame update
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
                    }
                    // É preciso escolher a mão livre mais próxima
                }
            }
        }
    }
}
