using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceCalib : MonoBehaviour {


    private float width;
    private float height;

    public float Width
    {
        get
        {
            return width;
        }
    }

    public float Height
    {
        get
        {
            return height;
        }
    }
    
    void Start ()
    {
        
    }
	
	void Update ()
    {
		
	}

    public void Calibrate(SurfaceRectangle r)
    {
        // Position and Orientation
        Vector3 up = r.SurfaceTopLeft - r.SurfaceBottomLeft;
        Vector3 right = r.SurfaceTopRight - r.SurfaceTopLeft;
        Vector3 center = (r.SurfaceTopLeft + r.SurfaceBottomRight) * 0.5f;

        transform.rotation = Quaternion.LookRotation(Vector3.Cross(right, up), up);
        transform.position = center;

        width = (r.SurfaceTopRight - r.SurfaceTopLeft).magnitude;
        height = (r.SurfaceTopRight - r.SurfaceBottomRight).magnitude;

        // Camera
        Camera.main.orthographicSize = (r.SurfaceTopLeft - r.SurfaceBottomLeft).magnitude * 0.5f;
        // not only camera... EVERYTHING!
        float scale = (r.SurfaceTopLeft - r.SurfaceBottomLeft).magnitude * 0.5f;
        transform.localScale = new Vector3(scale, scale, scale);

        print("calibrei");
    }
}
