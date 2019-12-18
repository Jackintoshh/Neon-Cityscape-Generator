using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{

    public float speed = 5.0f;
    public Color startColour, endColour;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) * speed;
        Debug.Log(GetComponent<Light>().color);
        GetComponent<Light>().color = Color.Lerp(startColour, endColour, t);
        //GetComponent<Light>().intensity = 20;
        //Flash();
        if(GetComponent<Light>().color == endColour)
        {
            GetComponent<Light>().color = startColour;
            startTime = Time.time;
        }
        //GetComponent<Light>().color = Color.Lerp(startColour, endColour, t);
    }

    void Flash()
    {
        GetComponent<Light>().intensity = Mathf.MoveTowards(0, 20, 20);
    }
}
