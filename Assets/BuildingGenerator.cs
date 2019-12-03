using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public float height, width, botsize, midsize, topsize;
    public int numPieces, numBuildings;
    public GameObject street, bottom, middle, top;
    Vector3 loc = new Vector3();
    public string spawnNo, BuildingSpawn;
    void Start()
    {
        street = this.gameObject;
        //Instantiate(street, gameObject.transform);
        numPieces = 2;
        numBuildings = 4;
        for (int i = 0; i < numBuildings; i++)
        {
            spawnNo = i.ToString();
            BuildingSpawn = "BuildingSpawn" + spawnNo;
            loc = street.transform.Find(BuildingSpawn).position;
            Debug.Log(spawnNo);
            Debug.Log(BuildingSpawn);
            loc += new Vector3(0, 0.5f, 0);
            bottom = (GameObject.CreatePrimitive(PrimitiveType.Cube));
            bottom.transform.position = loc;
            botsize = Random.Range(1.5f, 3.5f);
            bottom.transform.localScale = new Vector3(botsize, Random.Range(1.5f, 2.5f), botsize);
            
            Debug.Log(loc);
            for (int j = 0; j < numPieces; j++)
            {
                loc += new Vector3(0, 1.5f, 0);
                midsize = Random.Range(1.0f, 3.0f);
                middle = (GameObject.CreatePrimitive(PrimitiveType.Cube));
                middle.transform.position = loc;
                middle.transform.localScale = new Vector3(midsize, Random.Range(1.5f, 2.5f), midsize);
                
            }

        
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
