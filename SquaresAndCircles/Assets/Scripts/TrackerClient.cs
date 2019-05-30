using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TrackerClient : MonoBehaviour
{

    private Dictionary<string, Human> _humans;

    public GameObject handRightU1;
    public GameObject handLeftU1;
    public GameObject handRightU2;
    public GameObject handLeftU2;
    public GameObject user1;
    public GameObject user2;
    public Transform surfaceCenter;
    public Transform borders;

    void Start()
    {
        _humans = new Dictionary<string, Human>();
    }

    void Update()
    {
        //Human human;
        //UserHand hands;

        User u1 = user1.GetComponent<User>();
        User u2 = user2.GetComponent<User>();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            setUser(u1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            setUser(u2);
        }
        
        if (_humans.Count > 0)
        {
            foreach (Human h in _humans.Values)
            {
                if(h.id == u1.humanID)
                {
                    updateUser(u1, h);
                }
                else if(h.id == u2.humanID)
                {
                    updateUser(u2, h);
                }
            }}

        // finally
        _cleanDeadHumans();
    }

    private void setUser(User u)
    {
        foreach (Human h in _humans.Values)
        {
            Vector3 head = h.body.Joints[BodyJointType.head];
            Vector3 hand1 = h.body.Joints[BodyJointType.rightHand];
            Vector3 hand2 = h.body.Joints[BodyJointType.leftHand];

            // qualquer uma das maos da para calibrar
            // mas depois óh associa ah mao direita
            if (hand1.y > head.y || hand2.y > head.y)
            {
                u.humanID = h.id;
                print("human id is " + h.id );
                break;
            }
        }
    }

    private void updateUser(User u, Human h)
    {
        u.hand1.transform.position = h.body.Joints[BodyJointType.rightHandTip];
        u.hand2.transform.position = h.body.Joints[BodyJointType.leftHandTip];
        u.transform.position = h.body.Joints[BodyJointType.head];
        Vector3 spine = h.body.Joints[BodyJointType.spineBase];

        // por cabeça ao nivel da mesa
        u.transform.parent = surfaceCenter;
        u.transform.localPosition = new Vector3(u.transform.localPosition.x, u.transform.localPosition.y, 0);
        u.transform.parent = null;

        // olhar em frente
        float shortestD = float.PositiveInfinity;
        Transform closestB = null;
        for(int i = 0; i < borders.childCount; i++)
        {
            Transform b = borders.GetChild(i);
            float d = Vector3.Distance(b.GetComponent<BoxCollider>().ClosestPoint(spine), spine);
            if(d < shortestD)
            {
                shortestD = d;
                closestB = b;
            }
        }
        u.transform.LookAt(u.transform.position + closestB.forward, -surfaceCenter.forward);

    }

    public void setNewFrame(Body[] bodies)
    {
        foreach (Body b in bodies)
        {
            try
            {
                string bodyID = b.Properties[BodyPropertiesType.UID];
                if (!_humans.Keys.Contains(bodyID))
                {
                    _humans.Add(bodyID, new Human());
                }
                _humans[bodyID].Update(b);
            }
            catch (Exception) { }
        }
    }

    void _cleanDeadHumans()
    {
        List<Human> deadhumans = new List<Human>();

        foreach (Human h in _humans.Values)
        {
            if (DateTime.Now > h.lastUpdated.AddMilliseconds(1000))
                deadhumans.Add(h);
        }

        foreach (Human h in deadhumans)
        {
            _humans.Remove(h.id);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 35), "Number of users: " + _humans.Count);
    }
}