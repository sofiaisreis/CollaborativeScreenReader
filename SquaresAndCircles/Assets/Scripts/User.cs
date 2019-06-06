using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShapeType
{
    Square,
    Circle
};

public class User : MonoBehaviour
{

    public string humanID; // é ID do tracker
    public UserHand handRight;
    public UserHand handLeft;
    public TrackerClient theUser;
    public int userID;
    public ShapeType shapeType;

    // Start is called before the first frame update
    void Start()
    {
        handRight.theUser = this;
        handLeft.theUser = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

