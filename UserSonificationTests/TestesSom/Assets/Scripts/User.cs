using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public UserHand hand1;

    // Start is called before the first frame update
    void Start()
    {
        hand1.theUser = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

