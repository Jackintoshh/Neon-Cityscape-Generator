using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public float height, width, botsize, midsize, topsize, r, g, b;
    public int numPieces, numBuildings;
    public GameObject street, bottom, middle, buildingLight;
    Vector3 loc = new Vector3();
    public string spawnNo, BuildingSpawn;
    void Start()
    {
        street = this.gameObject;
        numPieces = 2;
        numBuildings = 4;

        GenerateBuildings();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateBuildings()
    {
        for (int i = 0; i < numBuildings; i++)
        {
            //Get correct spawn location from Spawnpoint name
            spawnNo = i.ToString();
            BuildingSpawn = "BuildingSpawn" + spawnNo;
            loc = street.transform.Find(BuildingSpawn).position;
            loc += new Vector3(0, 2.5f, 0);

            //Calculate random blue/pinkish colour
            r = Random.Range(25f, 160f) / 255;
            g = 4f / 255;
            b = Random.Range(160f, 170f) / 255;
            Color botColour = new Color(r, g, b);
            
            //Create bottom of building
            bottom = (GameObject.CreatePrimitive(PrimitiveType.Cube));
            bottom.GetComponent<Renderer>().material.SetColor("_Color", botColour);
            bottom.transform.SetParent(this.gameObject.transform);
            bottom.transform.position = loc;
            botsize = Random.Range(1.5f, 3.5f);
            bottom.transform.localScale = new Vector3(botsize, Random.Range(1.5f, 2.5f), botsize);

            //Create rest of the building pieces
            for (int j = 0; j < numPieces; j++)
            {
                loc += new Vector3(0, 7.5f, 0);
                midsize = Random.Range(1.0f, 2.0f);
                middle = (GameObject.CreatePrimitive(PrimitiveType.Cube));
                middle.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                middle.transform.SetParent(this.gameObject.transform);
                middle.transform.position = loc;
                middle.transform.localScale = new Vector3(midsize, Random.Range(1.5f, 2.5f), midsize);
            }

        }
    }
}
