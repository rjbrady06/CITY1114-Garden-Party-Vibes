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
        if (GameFlow.orderValue[GameFlow.plateNum] == GameFlow.plateValue[GameFlow.plateNum])
        {
            Debug.Log("correct" +"  "+GameFlow.orderTimer[GameFlow.plateNum]);
        }

        GameFlow.emptyPlateNow = transform.position.x;
        StartCoroutine(platereset());
    }

    IEnumerator platereset()
    {
        yield return new WaitForSeconds(.2f);
        GameFlow.emptyPlateNow = -1;
        GameFlow.totalCash += GameFlow.orderTimer[thisPlate] * .10f;
    }
}
