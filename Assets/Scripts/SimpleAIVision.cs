using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIVision : MonoBehaviour
{
    // This handles seeing the player character
    public GameObject playerCharacter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCharacter = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCharacter = null;
        }
    }
}
