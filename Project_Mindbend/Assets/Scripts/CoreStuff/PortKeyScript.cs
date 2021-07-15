using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortKeyScript : MonoBehaviour
{

    public CharacterController player;
    public Transform reciever;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping == true)
        {
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.forward, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
                // Teleport
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.transform.Rotate(Vector3.forward, rotationDiff);

                Vector3 stepOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.transform.position = reciever.position + stepOffset;

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
