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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GameFlow.orderValue[thisPlate] == GameFlow.plateValue[thisPlate])
        {
            Debug.Log("Correct plate served. +" + correctScoreReward + " points");
            GameFlow.score += correctScoreReward; 
        }
        else
        {
            Debug.Log("Incorrect plate served. -" + wrongScorePenalty + " points");
            GameFlow.score -= wrongScorePenalty;
            if (GameFlow.score < 0) GameFlow.score = 0;
        }

        // Generate a new order for this plate
        FindObjectOfType<GameFlow>().GenerateRandomOrder(thisPlate);

        GameFlow.emptyPlateNow = transform.position.x;
        StartCoroutine(platereset());
    }

    IEnumerator platereset()
    {
        yield return new WaitForSeconds(0.2f);
        GameFlow.emptyPlateNow = -1;
    }
}

