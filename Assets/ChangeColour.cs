using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{

    public float speed = 5.0f;
    public Color startColour, endColour;
    float startTime, BPMCalc;
    public int BPM = 95;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        BPMCalc = BPM / 60;
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("Flash", 0, BPMCalc);
    }

    void Flash()
    {
        float t = (Time.time - startTime) * speed;
        
        GetComponent<Light>().color = Color.Lerp(startColour, endColour, t);
        
        if (GetComponent<Light>().color == endColour)
        {
            GetComponent<Light>().color = startColour;
            startTime = Time.time;

            return;
        }

        
    }
}
