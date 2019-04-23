using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    public UserHand userHands;
    public int userID;
    public Transform user1;
    public Transform user2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Touch touch = Input.GetTouch(0);
        if (Input.touchCount > 0)
        {
          //Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            /*{
                Vector3 lh1, rh1, lh2, rh2;
                UserHand hands;

                hands = user1.GetComponent<UserHand>();
                lh1 = hands.leftHand;
                rh1 = hands.rightHand;

                hands = user2.GetComponent<UserHand>();
                lh2 = hands.leftHand;
                rh2 = hands.rightHand;
            }*/
        }
    }
}
