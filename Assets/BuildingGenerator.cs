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
            loc += new Vector3(0, 2.5f, 0);
            r = Random.Range(25f, 160f)/255;
            g = 4f/255;
            b = Random.Range(160f, 170f)/255;
            Color botColour = new Color(r, g, b);
            Debug.Log(botColour);
            bottom = (GameObject.CreatePrimitive(PrimitiveType.Cube));
            bottom.GetComponent<Renderer>().material.SetColor("_Color", botColour);
            bottom.transform.SetParent(this.gameObject.transform);
            bottom.transform.position = loc;
            //GameObject bLight = Instantiate(buildingLight, loc, Quaternion.identity);
            //bLight.transform.SetParent(this.gameObject.transform);
            botsize = Random.Range(1.5f, 3.5f);
            bottom.transform.localScale = new Vector3(botsize, Random.Range(1.5f, 2.5f), botsize);
            
            Debug.Log(loc);
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

            //loc = new Vector3(loc.x, middle.GetComponent<Renderer>().bounds.max.y + 1, loc.z);
            //GameObject topper = Instantiate(top, loc, Quaternion.identity);
            //topper.transform.parent = this.gameObject.transform;
        
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
