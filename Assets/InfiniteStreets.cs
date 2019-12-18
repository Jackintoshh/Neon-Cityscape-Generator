using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject theTile;
    public float timeCreated;

    public Tile(GameObject t, float tc)
    {
        theTile = t;
        timeCreated = tc;
    }
}
public class InfiniteStreets : MonoBehaviour
{
    public GameObject street;
    public GameObject player, streetLight;
    int streetSize = 50;
    int halfStreetX = 3;
    int halfStreetZ = 4;
    Vector3 startPos;
    Hashtable tiles = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        //Adapted from: https://www.youtube.com/watch?v=dycHQFEz8VI
        Instantiate(street, gameObject.transform);
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for(int x = -halfStreetX; x < halfStreetX; x++)
        {
            for(int z = -halfStreetZ; z < halfStreetZ; z++)
            {
                Vector3 pos = new Vector3((x * streetSize + startPos.x), 0, (z * streetSize + startPos.z));
                GameObject t = (GameObject)Instantiate(street, pos, Quaternion.identity);

                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if (Mathf.Abs(xMove) >= streetSize || Mathf.Abs(zMove) >= streetSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            int playerX = (int)(Mathf.Floor(player.transform.position.x / streetSize) * streetSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z / streetSize) * streetSize);

            for (int x = -halfStreetX; x < halfStreetX; x++)
            {
                for (int z = -halfStreetZ; z < halfStreetZ; z++)
                {
                    Vector3 pos = new Vector3((x * streetSize + playerX), 0, (z * streetSize + playerZ));
                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    if (!tiles.ContainsKey(tilename))
                    {
                        GameObject t = (GameObject)Instantiate(street, pos, Quaternion.identity);
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tilename, tile);
                    }
                    else
                    {
                        (tiles[tilename] as Tile).timeCreated = updateTime;
                    }
                    
                    
                }
            }

            Hashtable newTerrain = new Hashtable();
            foreach(Tile tls in tiles.Values)
            {
                if(tls.timeCreated != updateTime)
                {
                    Destroy(tls.theTile);
                }
                else
                {
                    newTerrain.Add(tls.theTile.name, tls);
                }
            }

            tiles = newTerrain;
            startPos = player.transform.position;
        }
    }
}
