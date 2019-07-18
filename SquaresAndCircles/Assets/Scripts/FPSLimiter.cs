using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int fps = 30;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;
    }

    // Update is called once per frame
    void Update()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;
    }
}
