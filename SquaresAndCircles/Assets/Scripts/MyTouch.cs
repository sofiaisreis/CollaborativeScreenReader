using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyTouch : MonoBehaviour
{
    public MyHand hand;
    public GameObject TouchInput;
    
    public DateTime timestart;
    public Vector3 positionstart;
    public bool isDrag = false;
    public int touchID;

    public GameObject stalkingGO1;
    public GameObject stalkingGO2;
    public Transform user1;
    public Transform userProjection1;
    public Transform user2;
    public Transform userProjection2;

    void Start()
    {
        timestart = DateTime.Now;
        positionstart = GetTouchWorldPosition(Input.GetTouch(0));
        transform.position = positionstart;
        isDrag = false;
    }
    
    void Update()
{
        Touch touch = Input.GetTouch(0);
        bool foundTouch = false;
        // ir buscar o toque com o id certo
        foreach (Touch t in Input.touches)
        {
            if (t.fingerId == touchID)
            {
                foundTouch = true;
                touch = t;
            }
        }

        if (!foundTouch)
        {
            print("cocó");
            hand.touch = null;
            Destroy(gameObject);
        }
        else
        {

            Vector3 touchPosition = GetTouchWorldPosition(touch);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved || Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                TimeSpan difTime = DateTime.Now - timestart;
                float difDist = (touchPosition - positionstart).magnitude;

                if (!isDrag)
                {
                    if (difTime.TotalMilliseconds >= 250 || difDist >= 10)
                    {
                        isDrag = true;
                        hand.BeginDrag(touchPosition);
                    }
                }
                else
                {
                    hand.Drag(touchPosition);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                TimeSpan difTime = DateTime.Now - timestart;
                float difDist = (touchPosition - positionstart).magnitude;

                if (isDrag)
                {
                    hand.EndDrag(touchPosition);
                }
                else
                {
                    hand.Tap(touchPosition);
                }
                hand.touch = null;
                Destroy(gameObject);
            }
        }
    }

    public Vector3 GetTouchWorldPosition(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        Transform tableTransform = GameObject.Find("PlaneTable").transform;
        Plane table = new Plane(tableTransform.up, tableTransform.position);
        float enter;
        if (table.Raycast(ray, out enter))
        {
            Vector3 lh1, rh1, lh2, rh2;
            Hands hands;
            hands = user1.GetComponent<Hands>();
            lh1 = hands.leftHand;
            rh1 = hands.rightHand;
            hands = user2.GetComponent<Hands>();
            lh2 = hands.leftHand;
            rh2 = hands.rightHand;

            return ray.GetPoint(enter);
        }
        return Vector3.zero;
    }

}
