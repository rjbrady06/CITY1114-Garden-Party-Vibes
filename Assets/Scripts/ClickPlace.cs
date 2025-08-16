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
            Instantiate(cloneObj, new Vector3(GameFlow.plateXpos, 0.9f, 1f), cloneObj.rotation);

        if(gameObject.name == "bunTop")
            Instantiate (cloneObj, new Vector3(GameFlow.plateXpos, 1.5f, 1f), cloneObj.rotation);

        if (gameObject.name == "Cheese")
            Instantiate (cloneObj, new Vector3(GameFlow.plateXpos, 1.3f, 1f), cloneObj.rotation);

        if (gameObject.name == "Bacon")
        {
            Instantiate(cloneObj, new Vector3(GameFlow.plateXpos - .1f, 1.4f, 1f), cloneObj.rotation);
            Instantiate(cloneObj, new Vector3(GameFlow.plateXpos + .1f, 1.4f, 1f), cloneObj.rotation);
        }

        GameFlow.plateValue[GameFlow.plateNum] += foodValue;
        Debug.Log(GameFlow.plateValue[GameFlow.plateNum]+"  " + GameFlow.orderValue[GameFlow.plateNum]);
    }
}
