using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPlace : MonoBehaviour
{
    public Transform cloneObj;
    public int foodValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameObject.name == "bunBottom")
            Instantiate(cloneObj, new Vector3(1, .10f, 1.2f), cloneObj.rotation);

        if(gameObject.name == "bunTop")
            Instantiate (cloneObj, new Vector3(1, .60f, 1.2f), cloneObj.rotation);

        if (gameObject.name == "Cheese")
            Instantiate (cloneObj, new Vector3(1, .62f, -.05f), cloneObj.rotation);

        if (gameObject.name == "Bacon")
        {
            Instantiate(cloneObj, new Vector3(-.1f, .62f, 0), cloneObj.rotation);
            Instantiate(cloneObj, new Vector3(.1f, .62f, 0), cloneObj.rotation);
        }

        GameFlow.plateValue += foodValue;
        Debug.Log(GameFlow.plateValue + "  " + GameFlow.orderValue);
    }
}
