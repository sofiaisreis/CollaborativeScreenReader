using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceCalib : MonoBehaviour {


    private float width;
    private float height;

    public Transform border1;
    public Transform border2;
    public Transform border3;
    public Transform border4;

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

        // borders
        border1.localPosition = new Vector3(-width / scale / 2.0f, 0, 0);
        border2.localPosition = new Vector3(width / scale / 2.0f, 0, 0);
        border3.localPosition = new Vector3(0, -height / scale / 2.0f, 0);
        border4.localPosition = new Vector3(0, height / scale / 2.0f, 0);

        border1.localScale = new Vector3(height / scale - 0.1f, 0.1f, 0.1f);
        border2.localScale = new Vector3(height / scale - 0.1f, 0.1f, 0.1f);
        border3.localScale = new Vector3(width / scale - 0.1f, 0.1f, 0.1f);
        border4.localScale = new Vector3(width / scale - 0.1f, 0.1f, 0.1f);

        border1.LookAt(center, Vector3.Cross(up, right));
        border2.LookAt(center, Vector3.Cross(up, right));
        border3.LookAt(center, Vector3.Cross(up, right));
        border4.LookAt(center, Vector3.Cross(up, right));
    }
}
