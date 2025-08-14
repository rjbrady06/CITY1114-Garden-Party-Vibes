using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMove : MonoBehaviour
{
    private int foodValue = 0;
    private MeshRenderer meatMat;
    private string stillcooking = "y";

    // Start is called before the first frame update
    void Start()
    {
        meatMat = GetComponent<MeshRenderer>();
        StartCoroutine(cookTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GetComponent<Transform>().position = new Vector3(1f, 1.2f, 1.2f);
        GameFlow.plateValue += foodValue;
        stillcooking = "n";
    }


    IEnumerator cookTimer()
    {
        yield return new WaitForSeconds(10);
        foodValue = 1000;
        if (stillcooking == "y")
            meatMat.material.color = new Color(.3f, .3f, .3f);
    }
}
