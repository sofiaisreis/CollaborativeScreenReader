using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHand : MonoBehaviour
{
    public UserTouch userTouch;
    public Vector3 userHand;
    
    public User theUser;

    // Start is called before the first frame update
    void Start()
    {
        userTouch.hand = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

}
