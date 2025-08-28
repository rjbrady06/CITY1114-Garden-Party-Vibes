using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameFlow : MonoBehaviour
{
    // All possible order values matching the textures
    private int[] possibleOrderValues = { 11001, 11011, 11101, 11111, 12001, 12011, 12101, 12111 };

    public static int[] orderValue = new int[3];
    public static int[] plateValue = new int[3];
    public static float[] orderTimer = { 20, 20, 20 };

    public static bool[] orderCompleted = new bool[3];

    public static int plateNum = 0;
    public static float plateXpos = 1;

    public Transform plateSelector;

    public MeshRenderer[] currentPic;

    public Texture[] orderPics;

    [SerializeField] private Texture blankTexture;

    public static float emptyPlateNow = -1;
    public static int score = 50;

    [SerializeField] private TMP_Text[] orderTimerTexts = new TMP_Text[3];

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
            currentPic[i].material.mainTexture = blankTexture;
            orderValue[i] = 0;
            orderTimer[i] = 0f;
            orderTimerTexts[i].text = "";
            
        }
        for (int i = 0; i < orderCompleted.Length; i++)
        {
            orderCompleted[i] = false;
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
            if (orderValue[i] == 0 || orderCompleted[i]) continue;

            orderTimer[i] -= Time.deltaTime;

            if (orderTimer[i] <= 0)
            {
                Debug.Log("Order " + i + " expired. Replacing with new order.");
                ClearOrder(i);
                continue;
            }

            int secondsLeft = Mathf.CeilToInt(orderTimer[i]);
            orderTimerTexts[i].text = secondsLeft.ToString();

            if (orderTimer[i] < 10f)
            {
                orderTimerTexts[i].color = Color.red;
            }
            else
            {
                orderTimerTexts[i].color = Color.white;
            }
        }

       

    }

    public void GenerateRandomOrder(int index)
    {
        int randomOrder = possibleOrderValues[Random.Range(0, possibleOrderValues.Length)];
        orderValue[index] = randomOrder;
        plateValue[index] = 0;
        orderTimer[index] = 20f;
        orderCompleted[index] = false;

        if (orderTextureMap.ContainsKey(randomOrder))
        {
            currentPic[index].material.mainTexture = orderTextureMap[randomOrder];
            orderTimerTexts[index].text = "60";
            orderTimerTexts[index].color = Color.white;
        }
    }

    public void GenerateNextAvailableOrder()
    {
        for(int i = 0; i < orderValue.Length; i++)
        {
            if (orderTimer[i] <= 0f || currentPic[i].material.mainTexture == blankTexture)
            {
                GenerateRandomOrder(i);
                return;
            }
        }

        Debug.Log("No available empty order slot.");
    }

    public void CompleteOrder(int index)
    {
        Debug.Log("Order " + index + " completed");

        orderCompleted[index] = true;
        ClearOrder(index);
    }

    public void ClearOrder(int index)
    {
        orderTimer[index] = 0f;
        orderValue[index] = 0;
        plateValue[index] = 0;

        

        currentPic[index].material.mainTexture = blankTexture;
        orderTimerTexts[index].text = "";
        orderTimerTexts[index].color = Color.white;
    }

    private IEnumerator DelayedOrderGeneration(int index)
    {
        yield return new WaitForSeconds(2f);

        if (!orderCompleted[index])
        {
            yield break;
        }

        GenerateRandomOrder(index);
        orderCompleted[index] = false;
    }
}
