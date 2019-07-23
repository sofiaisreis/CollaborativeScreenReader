using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterMaster : MonoBehaviour
{
    public GameObject cubinhoHand1;
    public GameObject cubinhoHand2;
    public int counterSquares;
    public int counterCircles;
    public int squares_findTotal;
    public int circles_findTotal;
    public int squares_inc;
    public int circles_inc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            squares_findTotal = 5;
            circles_findTotal = 5;
            squares_inc = 0;
            circles_inc = 0;

        }
    }

    public int GetSquaresTotal()
    {
        return squares_findTotal;
    }

    public int GetCirclesTotal()
    {
        return circles_findTotal;
    }

    public void AddSquares()
    {
        squares_inc++;
    }

    public void AddCircles()
    {
        circles_inc++;
    }

    public int GetSquaresInc()
    {
        return squares_inc;
    }

    public int GetCirclesInc()
    {
        return circles_inc;
    }

    public void UpdateLastColliding(int IDuser)
    {
        if(IDuser == 1)
        {
            cubinhoHand1.GetComponent<ColliderObj>().lastCollidingObject = cubinhoHand1.GetComponent<ColliderObj>().collidingObject = cubinhoHand1.GetComponent<ColliderObj>().lastCollidingObjectGlobal = null;
        }
        else if(IDuser == 2)
        {
            cubinhoHand2.GetComponent<ColliderObj>().lastCollidingObject = cubinhoHand2.GetComponent<ColliderObj>().collidingObject = cubinhoHand2.GetComponent<ColliderObj>().lastCollidingObjectGlobal = null;

        }
    }
}
