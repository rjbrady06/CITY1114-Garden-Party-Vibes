using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatcon : MonoBehaviour
{
    public Transform cloneObj;

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
        if (gameObject.name == "Burger")
            Instantiate(cloneObj, new Vector3(0f, 1.2f, .6f), cloneObj.rotation);
    }
}
