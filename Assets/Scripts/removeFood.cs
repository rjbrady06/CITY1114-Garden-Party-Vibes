using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeFood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameFlow.emptyPlateNow>transform.position.x-.4f) && (GameFlow.emptyPlateNow < transform.position.x + .4f))
        {
            Destroy(gameObject);
        }
    }
}
