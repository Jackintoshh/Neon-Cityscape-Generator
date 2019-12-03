using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStreets : MonoBehaviour
{
    public GameObject street;
    int planeSize = 10;
    int halfTilesX = 10;
    int halfTilesY = 10;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(street, gameObject.transform);
        startPos = Vector3.zero;

        for(int x = 0; x < halfTilesX; x++)
        {
            for(int z = 0; z < halfTilesY; z++)
            {
                Vector3 pos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));
                GameObject t = (GameObject)Instantiate(street, pos, Quaternion.identity);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
