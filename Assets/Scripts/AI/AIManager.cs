using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    public static AIManager Instance;
    public NavMeshAgent agent;

    public GameObject aiPrefab;
    public Transform aiSpawnPoint;
    public OrderTrigger orderTrigger;
    public Transform walkAwayPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnNewAI()
    {
        var triggerPoint = orderTrigger.GetRandomFreeTriggerPoint();

        if (triggerPoint == null)
        {
            Debug.Log("No free trigger points - not spawning AI");
            return;
        }

        GameObject ai = Instantiate(aiPrefab);
        var aiMovement = ai.GetComponent<CustomerAI>();

        aiMovement.walkAwayPoint = walkAwayPoint;
        aiMovement.SetOrderTrigger(orderTrigger);
        aiMovement.AssignTriggerPoint(triggerPoint);

        triggerPoint.assignedAI = aiMovement;
    }

  


    // Start is called before the first frame update
    private void Start()
    {
        SpawnNewAI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
