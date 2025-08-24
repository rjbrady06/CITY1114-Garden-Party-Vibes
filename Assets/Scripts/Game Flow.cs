using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    // All possible order values matching the textures
    private int[] possibleOrderValues = { 11001, 11011, 11101, 11111, 12001, 12011, 12101, 12111 };

    public static int[] orderValue = new int[3];
    public static int[] plateValue = new int[3];
    public static float[] orderTimer = { 60, 60, 60 };

    public static int plateNum = 0;
    public static float plateXpos = 1;

    public Transform plateSelector;

    public MeshRenderer[] currentPic;

    public Texture[] orderPics;

    public static float emptyPlateNow = -1;
    public static float totalCash = 0;

    private Dictionary<int, Texture> orderTextureMap;

    void Start()
    {
        // Build dictionary for cleaner assignment
        orderTextureMap = new Dictionary<int, Texture>
        {
            { 11001, orderPics[0] },
            { 11011, orderPics[1] },
            { 11101, orderPics[2] },
            { 11111, orderPics[3] },
            { 12001, orderPics[4] },
            { 12011, orderPics[5] },
            { 12101, orderPics[6] },
            { 12111, orderPics[7] }
        };

        // Generate initial random orders
        for (int i = 0; i < 3; i++)
        {
            GenerateRandomOrder(i);
        }
    }

    void Update()
    {
        // Plate selection
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

        plateSelector.transform.position = new Vector3(plateXpos, 0.9f, 1);

        // Decrease order timers
        for (int i = 0; i < orderTimer.Length; i++)
        {
            orderTimer[i] -= Time.deltaTime;

            if (orderTimer[i] <= 0)
            {
                Debug.Log("Order " + i + " expired. Replacing with new order.");
                GenerateRandomOrder(i);
            }
        }

        // Simulate completing an order using number keys 1, 2, 3 (optional)
        if (Input.GetKeyDown(KeyCode.Alpha1)) CompleteOrder(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) CompleteOrder(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) CompleteOrder(2);
    }

    public void GenerateRandomOrder(int index)
    {
        int randomOrder = possibleOrderValues[Random.Range(0, possibleOrderValues.Length)];
        orderValue[index] = randomOrder;
        orderTimer[index] = 60f;

        if (orderTextureMap.ContainsKey(randomOrder))
        {
            currentPic[index].material.mainTexture = orderTextureMap[randomOrder];
        }
    }

    void CompleteOrder(int index)
    {
        Debug.Log("Order " + index + " completed!");
        totalCash += 10f; // Add cash for completing
        GenerateRandomOrder(index); // Replace with a new one
    }
}
