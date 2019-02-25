using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    public float distance = 3.0f;
    public bool useInitialCameraDistance = false;
    private float actualDistance;
   
    void Start()
    {
        if (useInitialCameraDistance)
        {
            //projecao de vetor
            Vector3 toObjectVector = transform.position - Camera.main.transform.position;
            Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
            actualDistance = (transform.position - Camera.main.transform.position).magnitude;
        }
        else
        {
            actualDistance = distance;
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0)){
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distance;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
