using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMaker : MonoBehaviour
{
    Mesh mesh;
    MeshRenderer meshRenderer;
    Vector3[] vertices;
    int[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new[]
        {
            new Vector3(0,0,-0.01f),
            new Vector3(0.5f,0.866025404f,-0.01f),
            new Vector3(1,0,-0.01f),
        };
        mesh.vertices = vertices;

        triangles = new[] { 0, 1, 2 };
        mesh.triangles = triangles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
