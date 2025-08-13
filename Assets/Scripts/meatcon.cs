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
            Instantiate(cloneObj, new Vector3(-0.1f, 1f, 1.4f), cloneObj.rotation);
    }
}
