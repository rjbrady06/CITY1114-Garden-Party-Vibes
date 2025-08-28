using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTrigger : MonoBehaviour
{
    [System.Serializable]
    public class TriggerPoint
    {
        public Transform triggerTransform;
        public int orderIndex;
        
        [HideInInspector] public bool isOccupied = false;

        [HideInInspector] public CustomerAI assignedAI = null;
    }

    public TriggerPoint[] triggerPoints;
    public GameFlow gameFlow;

    

    
    // Start is called before the first frame update
    void Start()
    {
        if (gameFlow == null)
        {
            gameFlow = FindObjectOfType<GameFlow>();
        }

        foreach (var point in triggerPoints)
        {
            point.isOccupied = false;
        }
    }

    public TriggerPoint GetRandomFreeTriggerPoint()
    {
        List<TriggerPoint> freePoints = new List<TriggerPoint>();

        foreach (var point in triggerPoints)
        {
            if (!point.isOccupied)
                freePoints.Add(point);
        }

        if (freePoints.Count == 0)
            return null;

        var selected = freePoints[Random.Range(0, freePoints.Count)];
        selected.isOccupied = true; 
        return selected;
    }

    public void FreeTriggerPoint(TriggerPoint point)
    {
        if (point == null) return;
        point.isOccupied = false;
    }


    public void TriggerOrderAtIndex(int index)
    {
        if (index < 0 || index >= triggerPoints.Length) return;

        int orderSlot = triggerPoints[index].orderIndex;

        Debug.Log("Order triggered at index " + index + " by AI arrival");
        gameFlow.GenerateRandomOrder(orderSlot);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerOrder()
    {
        Debug.Log("Order triggered. ");
        gameFlow.GenerateNextAvailableOrder();
    }
}
