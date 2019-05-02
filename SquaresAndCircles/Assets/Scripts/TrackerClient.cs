using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TrackerClient : MonoBehaviour
{

    private Dictionary<string, Human> _humans;

    public GameObject user1;
    public GameObject user2;

    void Start()
    {
        _humans = new Dictionary<string, Human>();
    }

    void Update()
    {

        Human human;
        UserHand hands;

        if (_humans.Count > 0)
        {
            human = _humans.ElementAt(0).Value;
            user1.transform.position = human.body.Joints[BodyJointType.spineBase];
            hands = user1.GetComponent<UserHand>();
            hands.userHand = human.body.Joints[BodyJointType.rightHand]; //suppose right TO DO
        }
        else
        {
            hands = user1.GetComponent<UserHand>();
            hands.userHand = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        }

        if (_humans.Count > 1)
        {
            human = _humans.ElementAt(1).Value;
            user2.transform.position = human.body.Joints[BodyJointType.spineBase];
            hands = user2.GetComponent<UserHand>();
            hands.userHand = human.body.Joints[BodyJointType.rightHand];
        }
        else
        {
            hands = user2.GetComponent<UserHand>();
            hands.userHand = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        }

        // finally
        _cleanDeadHumans();
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
        //GUI.Label(new Rect(10, 10, 200, 35), "Number of users: " + _humans.Count);
    }
}