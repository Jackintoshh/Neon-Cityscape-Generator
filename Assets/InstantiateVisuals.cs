using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateVisuals : MonoBehaviour
{
    public GameObject sampleCube;
    GameObject[] cubes = new GameObject[512];
    GameObject[] cubes2 = new GameObject[8];
    public float scale, cubescale;
    // Start is called before the first frame update
    void Start()
    {
        cubescale = 1f;
        scale = 5f;
        /*for(int i = 0; i < 512; i++)
        {
            GameObject instanceCube = (GameObject)Instantiate(sampleCube);
            instanceCube.transform.position = this.transform.position;
            instanceCube.transform.SetParent(this.transform);
            instanceCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceCube.transform.position = Vector3.forward * 100;
            cubes[i] = instanceCube;
        }
        */
        Vector3 startpos1 = new Vector3(this.GetComponent<Renderer>().bounds.min.x + 2, this.GetComponent<Renderer>().bounds.max.y, this.GetComponent<Renderer>().bounds.min.z + 1);
        int count = 0;
        for(int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                
                Debug.Log(this.GetComponent<Renderer>().bounds.min.x + "This one here!!!" );
                GameObject instanceCube = (GameObject)Instantiate(sampleCube);
                //instanceCube.transform.position = this.transform.position;
                instanceCube.transform.localScale = new Vector3(cubescale, cubescale, cubescale);
                Debug.Log(instanceCube.transform.localScale);
                instanceCube.transform.position = startpos1;
                Debug.Log(instanceCube.transform.localScale);
                instanceCube.transform.SetParent(this.transform);
                instanceCube.name = "BandCube" + count;
                cubes2[count] = instanceCube;
                count++;
                startpos1 = new Vector3(startpos1.x, startpos1.y, startpos1.z + 1.2f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*for(int i = 0; i < 512; i++)
        {
            if(sampleCube != null)
            {
                cubes[i].transform.localScale = new Vector3(10, AudioVisualizer.samples[i] * (scale + 2), 10);
            }
        }
        */
        for(int i = 0; i < 8; i++)
        {
            cubes2[i].transform.localScale = new Vector3(cubes2[i].transform.localScale.x, (AudioVisualizer.freqBand[i] * (scale + 2)), cubes2[i].transform.localScale.z);
        }
    }
}
