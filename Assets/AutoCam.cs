using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCam : MonoBehaviour
{
    public float speed;
    float turnangle;
    GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject;
        speed = 15f;
        
        //Offset camera position so that it doesn't rotate immediately
        cam.transform.position = new Vector3(1, 1, 1);
        turnangle = 90f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move camera forward
        cam.transform.position += cam.transform.forward * (Time.deltaTime * speed);

        //After camera reaches a certain point, turn down another street
        /*
        if ((int)cam.transform.position.z % 200 == 0 || (int)cam.transform.position.x % 200 == 0)
        {
            cam.transform.eulerAngles += new Vector3(0, turnangle, 0);
            cam.transform.position += new Vector3(1, 0, 1);
        }
        */
    }
}
