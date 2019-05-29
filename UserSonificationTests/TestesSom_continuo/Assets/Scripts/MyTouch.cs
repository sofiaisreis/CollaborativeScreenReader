using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyTouch : MonoBehaviour
{
    //um toque so tem uma mao
    public UserTouch hand1;
    public GameObject TouchInput;

    public DateTime timestart;
    public Vector3 positionstart;
    public bool isDrag = false;
    public int touchID;
    static int maxTouches = 2;
    static Vector2[] touchPos;


    public void Init(Touch touch)
    {
        timestart = DateTime.Now;
        touchPos = new Vector2[maxTouches];
        positionstart = GetTouchWorldPosition(touch);
        transform.position = positionstart;
        touchID = touch.fingerId;
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
            hand1.touch = null;
            Destroy(gameObject);
        }
        else
        {
            Vector3 touchPosition = GetTouchWorldPosition(touch);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                TimeSpan difTime = DateTime.Now - timestart;
                float difDist = (touchPosition - positionstart).magnitude;

                if (!isDrag)
                {
                    if (difTime.TotalMilliseconds >= 250 || difDist >= 10)
                    {
                        isDrag = true;
                        hand1.BeginDrag(touchPosition);
                    }
                }
                else
                {
                    hand1.Drag(touchPosition);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                TimeSpan difTime = DateTime.Now - timestart;
                float difDist = (touchPosition - positionstart).magnitude;

                if (isDrag)
                {
                    hand1.EndDrag(touchPosition);
                }
                else
                {
                    hand1.Tap(touchPosition);
                }
                hand1.touch = null;
                Destroy(gameObject);
            }
        }
    }

    public Vector3 GetTouchWorldPosition(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        Transform tableTransform = GameObject.Find("Plane").transform;
        Plane table = new Plane(tableTransform.up, tableTransform.position);
        float enter;
        if (table.Raycast(ray, out enter))
        {
            return ray.GetPoint(enter);
        }
        return Vector3.zero;
       
    }

}