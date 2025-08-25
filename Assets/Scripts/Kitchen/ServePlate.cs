using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServePlate : MonoBehaviour
{

    public int thisPlate;

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
        if (GameFlow.orderValue[thisPlate] == GameFlow.plateValue[thisPlate])
        {
            Debug.Log("correct" + "  " + GameFlow.orderTimer[thisPlate]);
            GameFlow.totalCash += GameFlow.orderTimer[thisPlate] * 0.10f; // Reward cash for serving
        }
        else
        {
            Debug.Log("Incorrect plate served.");
            // Optional: penalty or no cash
        }

        // Generate a new order for this plate
        FindObjectOfType<GameFlow>().GenerateRandomOrder(thisPlate);

        GameFlow.emptyPlateNow = transform.position.x;
        StartCoroutine(platereset());
    }

    IEnumerator platereset()
    {
        yield return new WaitForSeconds(.2f);
        GameFlow.emptyPlateNow = -1;
    }
}

