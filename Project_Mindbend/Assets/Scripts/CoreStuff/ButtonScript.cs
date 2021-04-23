using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private Animator doorOpen = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GrabMe"))
        {
            if (openTrigger)
            {
                doorOpen.Play("DoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
