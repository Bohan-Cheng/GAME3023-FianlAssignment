using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Script_Daynight : MonoBehaviour
{
    private Light2D light;
    private bool ReachedDay = false;
    [SerializeField] float TimeSpeed;
    [SerializeField] float MinIntensity;
    [SerializeField] float MaxIntensity;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ReachedDay)
        {
            if (light.intensity < MaxIntensity)
            {
                light.intensity += TimeSpeed/100;
            }
            else
            {
                ReachedDay = true;
            }
        }
        else
        {
            if (light.intensity > MinIntensity)
            {
                light.intensity -= TimeSpeed/100;
            }
            else
            {
                ReachedDay = false;
            }
        }


    }
}
