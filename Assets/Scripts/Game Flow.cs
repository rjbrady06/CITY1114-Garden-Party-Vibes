using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static int[] orderValue = { 11111, 10001, 12001 };
    public static int[] plateValue = { 0, 0, 0 };
    public static float[] orderTimer = { 60, 60, 60 };

    public static int plateNum = 0;
    public static float plateXpos = 1;

    public Transform plateSelector;

    public MeshRenderer[] currentPic;

    public Texture[] orderPics;

    public static float emptyPlateNow = -1;

    public static float totalCash = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int rep = 0; rep < 3; rep += 1)
        {
            if (orderValue[rep] == 11001)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[0];

            if (orderValue[rep] == 11011)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[1];

            if (orderValue[rep] == 11101)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[2];

            if (orderValue[rep] == 11111)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[3];

            if (orderValue[rep] == 12001)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[4];

            if (orderValue[rep] == 12011)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[5];

            if (orderValue[rep] == 12101)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[6];

            if (orderValue[rep] == 12111)
                currentPic[rep].GetComponent<MeshRenderer>().material.mainTexture = orderPics[7];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            plateNum += 1;
            plateXpos += 1;

            if (plateNum > 2)
            {
                plateNum = 0;
                plateXpos = 1;
            }
        }

        orderTimer[0] -= Time.deltaTime;
        orderTimer[1] -= Time.deltaTime;
        orderTimer[2] -= Time.deltaTime;

        plateSelector.transform.position = new Vector3(plateXpos, 0.9f, 1);
    }
}
