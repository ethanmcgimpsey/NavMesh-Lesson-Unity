using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAISquad : MonoBehaviour
{
    // Handles AI squad movement
    // If the AI is moving as a squad,
    // set destinations to each squad position

    [SerializeField] private List<NavMeshAgent> squadMemebers;
    [SerializeField] private Transform[] squadPositions;
    [SerializeField] private float squadPositionsDistance;

    void Update()
    {
        // Cycle through all squad members
        // and make them move to squad positions!
        for (int i = 0; i < squadMemebers.Count; i++)
        {
            if (squadMemebers[i].GetComponent<SimpleAIBrain>().currentTactics == SimpleAIBrain.Tactics.SquadPattern)
            {
                squadMemebers[i].SetDestination(squadPositions[i].position);
            }
        }
    }

    private void OnDrawGizmos()
    {
        //squadPositions = GetComponentsInChildren<Transform>();
        if (squadPositions != null)
        {
            Gizmos.color = Color.red;
            for (int i = 1; i < squadPositions.Length - 1; i++)
            {
                Transform pointA = squadPositions[i];
                Transform pointB = squadPositions[i + 1];
                Gizmos.DrawLine(pointA.position, pointB.position);
            }

            for (int i = 1; i < squadPositions.Length; i++)
            {
                Gizmos.DrawSphere(squadPositions[i].position, squadPositionsDistance);
            }
        }
    }
}
