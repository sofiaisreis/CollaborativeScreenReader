using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TrackerClient : MonoBehaviour
{

    private Dictionary<string, Human> _humans;

    public GameObject hand;
    public GameObject user1;
    public Transform surfaceCenter;

    void Start()
    {
        _humans = new Dictionary<string, Human>();
    }

    void Update()
    {
        User u1 = user1.GetComponent<User>();
        
        if (_humans.Count > 0)
        {
            foreach (Human h in _humans.Values)
            {
                updateUser(u1, h);
            }
            
        }

        // finally
        _cleanDeadHumans();
    }

    private void setUser(User u)
    {
        foreach (Human h in _humans.Values)
        {
            Vector3 head = h.body.Joints[BodyJointType.head];
            Vector3 hand = h.body.Joints[BodyJointType.rightHand];

            // qualquer uma das maos da para calibrar
            // mas depois óh associa ah mao direita
            if (hand.y > head.y )
            {
                print("human id is " + h.id);
                break;
            }
        }
    }

    private void updateUser(User u, Human h)
    {
        u.hand1.transform.position = h.body.Joints[BodyJointType.rightHandTip];
        u.transform.position = h.body.Joints[BodyJointType.head];
        u.transform.localPosition = new Vector3(u.transform.localPosition.x, u.transform.localPosition.y, 0);
        u.transform.LookAt(surfaceCenter);
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