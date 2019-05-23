using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public string humanID; // é ID do tracker
    public UserHand hand1;
    public UserHand hand2;
    public TrackerClient theUser;
    public int userID;

    // Start is called before the first frame update
    void Start()
    {
        hand1.theUser = this;
        hand2.theUser = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

