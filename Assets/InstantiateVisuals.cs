using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateVisuals : MonoBehaviour
{
    public GameObject sampleCube;
    GameObject[] cubes = new GameObject[512];
    GameObject[] cubes2 = new GameObject[8];
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 512; i++)
        {
            GameObject instanceCube = (GameObject)Instantiate(sampleCube);
            instanceCube.transform.position = this.transform.position;
            instanceCube.transform.SetParent(this.transform);
            instanceCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceCube.transform.position = Vector3.forward * 100;
            cubes[i] = instanceCube;
        }

        for(int i = 0; i < 8; i++)
        {
            GameObject instanceCube = (GameObject)Instantiate(sampleCube);
            //instanceCube.transform.position = this.transform.position;
            instanceCube.transform.position = new Vector3((this.transform.position.x + (i * 3)), 0, 0);
            instanceCube.transform.SetParent(this.transform);
            instanceCube.name = "BandCube" + i;
            cubes2[i] = instanceCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 512; i++)
        {
            if(sampleCube != null)
            {
                cubes[i].transform.localScale = new Vector3(10, AudioVisualizer.samples[i] * (scale + 2), 10);
            }
        }

        for(int i = 0; i < 8; i++)
        {
            cubes2[i].transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.freqBand[i] * (scale + 2)), transform.localScale.z);
        }
    }
}
