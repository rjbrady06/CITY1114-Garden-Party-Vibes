using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ServePlate : MonoBehaviour
{

    public int thisPlate;
    

    [SerializeField] private int correctScoreReward = 10;
    [SerializeField] public int wrongScorePenalty = 5;

    

    // Start is called before the first frame update
    void Start()
    {
        UpdateColliderState();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColliderState();
    }

    private void UpdateColliderState()
    {
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = GameFlow.orderTimer[thisPlate] > 0f;
        }
    }

    private void OnMouseDown()
    {
        if (GameFlow.orderTimer[thisPlate] <= 0f)
        {
            Debug.Log("No active order on plate " + thisPlate + ". Click ignored");
            return;
        }

        if (GameFlow.orderValue[thisPlate] == GameFlow.plateValue[thisPlate])
        {
            Debug.Log("Correct plate served. +" + correctScoreReward + " points");
            GameFlow.score += correctScoreReward;

            FindObjectOfType<GameFlow>().CompleteOrder(thisPlate);
        }
        else
        {
            Debug.Log("Incorrect plate served. -" + wrongScorePenalty + " points");
            GameFlow.score -= wrongScorePenalty;
            if (GameFlow.score < 0) GameFlow.score = 0;

            var orderTrigger = FindObjectOfType<OrderTrigger>();
            foreach (var point in orderTrigger.triggerPoints)
            {
                if (point.orderIndex == thisPlate && point.assignedAI != null)
                {
                    Debug.Log($"[ServePlate] Wrong order for slot {thisPlate}. Telling AI to leave");
                    point.assignedAI.ForceWalkAway();
                    break;
                }
            }

            FindObjectOfType<GameFlow>().ClearOrder(thisPlate);
        }

        GameFlow.emptyPlateNow = transform.position.x;
        StartCoroutine(platereset());
    }

    IEnumerator platereset()
    {
        yield return new WaitForSeconds(0.2f);
        GameFlow.emptyPlateNow = -1;
    }
}

