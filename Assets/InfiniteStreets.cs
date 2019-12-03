using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStreets : MonoBehaviour
{
    public GameObject street;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(street, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
