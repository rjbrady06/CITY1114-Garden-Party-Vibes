using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public Transform orderTriggerPoint;
    public Transform walkAwayPoint;


    private OrderTrigger.TriggerPoint currentTriggerPoint;
    private NavMeshAgent agent;
    private OrderTrigger orderTrigger;

    private bool hasOrdered = false;
    private bool orderCompletedOrExpired = false;
    private bool isWalkingAway = false;
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void AssignTriggerPoint(OrderTrigger.TriggerPoint point)
    {
        currentTriggerPoint = point;
        agent.SetDestination(currentTriggerPoint.triggerTransform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        

        if (currentTriggerPoint == null )
        {
            Debug.LogWarning("No free trigger points available. Destroying AI");
            Destroy(gameObject);
            return;
        }

        
        
    }

    private void OnDrawGizmos()
    {
        if (walkAwayPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(walkAwayPoint.position, 0.3f);
            Gizmos.DrawLine(transform.position,walkAwayPoint.position);
        }
    }

    void MoveAway()
    {
        if (walkAwayPoint != null)
        {
            agent.SetDestination(walkAwayPoint.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasOrdered && hasReached(agent, currentTriggerPoint.triggerTransform.position))
        {
            hasOrdered = true;

            int index = System.Array.IndexOf(orderTrigger.triggerPoints, currentTriggerPoint);
            Debug.Log($"[AI] triggering order at index {index}");
            orderTrigger.TriggerOrderAtIndex(index);   
            
        }

        if (hasOrdered && !orderCompletedOrExpired)
        {
            int orderIdx = currentTriggerPoint.orderIndex;

            if (GameFlow.orderCompleted[orderIdx]) 
            {
                Debug.Log($"[AI] Order {orderIdx} completed. walking away.");
                orderCompletedOrExpired = true;
                isWalkingAway = true;
                MoveAway();
            }
            else if (GameFlow.orderTimer[orderIdx] <= 0)
            {
                Debug.Log($"[AI] Order {orderIdx} expired. Walking away.");
                orderCompletedOrExpired= true;
                isWalkingAway = true;
                MoveAway();
            }
        }


        if (isWalkingAway && hasReached(agent, walkAwayPoint.position)) 
        {
            Debug.Log($"{gameObject.name} reached WalkAwayPoint. Despawning");

            orderTrigger.FreeTriggerPoint(currentTriggerPoint);
            currentTriggerPoint.assignedAI = null;
            Destroy(gameObject);
            AIManager.Instance.SpawnNewAI();

        }

    }

    bool hasReached(NavMeshAgent agent, Vector3 destination)
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }

    public void SetOrderTrigger(OrderTrigger trigger)
    {
        orderTrigger = trigger;
    }

    public void ForceWalkAway()
    {
        if (isWalkingAway || orderCompletedOrExpired) return;

        Debug.Log("[AI] Recieved wrong order. Walking away.");
        isWalkingAway = true;
        orderCompletedOrExpired = true;
        MoveAway();
    }
}
