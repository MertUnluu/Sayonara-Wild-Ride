using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{


    // Update is called once per frame
    void Start()
    {
        RenderSettings.fogMode = FogMode.Exponential;
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0.03f;
       


    }
}
