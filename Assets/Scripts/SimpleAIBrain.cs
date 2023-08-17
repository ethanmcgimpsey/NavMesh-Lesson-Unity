using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIBrain : MonoBehaviour
{
    [SerializeField] private SimpleAIVision vision;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 targetPosition = new Vector3(8, 0, 8);

    public enum Tactics { Undefined, NoPattern, SquadPattern }
    public Tactics currentTactics = Tactics.Undefined;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTactics == Tactics.NoPattern) 
        {
            if (vision != null)
            {
                if (vision.playerCharacter != null)
                {
                    agent.SetDestination(vision.playerCharacter.transform.position);
                }
            }
        }
        // if the agent gets near its destination, tell it to STOP MOVING
        /*if(Vector3.Distance(transform.position, targetPosition) < 2)
        {
            agent.isStopped = true;
        }*/
    }
}
