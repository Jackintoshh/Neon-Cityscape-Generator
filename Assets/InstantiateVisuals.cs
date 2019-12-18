using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateVisuals : MonoBehaviour
{
    public GameObject sampleCube;
    public float scale, cubescale;
    GameObject[] cubes2 = new GameObject[8];
    

    // Start is called before the first frame update
    void Start()
    {
        cubescale = 1f;
        scale = 5f;

        InstantiateCubes();
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 8; i++)
        {
            cubes2[i].transform.localScale = new Vector3(cubes2[i].transform.localScale.x, (AudioVisualizer.freqBand[i] * (scale + 2)), cubes2[i].transform.localScale.z);
        }
    }

    void InstantiateCubes()
    {
        Vector3 startpos1 = this.transform.position;
        int count = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                //Instantiate cube prefab
                GameObject instanceCube = (GameObject)Instantiate(sampleCube);

                //Set position and scale of cubes
                instanceCube.transform.position = startpos1;
                instanceCube.transform.localScale = new Vector3(cubescale, cubescale, cubescale);
                instanceCube.transform.SetParent(this.transform);
                instanceCube.name = "BandCube" + count;

                //Add each cube to array so we can deal with each one
                cubes2[count] = instanceCube;
                count++;
                startpos1 = new Vector3(startpos1.x, startpos1.y, startpos1.z + 1.2f);
            }
        }
    }
}
