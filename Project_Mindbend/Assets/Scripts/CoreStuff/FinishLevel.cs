using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    void Start()
    {
        gameObject.tag = "Player";
    }
    void OnTriggerEnter(Collider collider)
    {
        if (gameObject.tag == "Player")
        {
            Application.LoadLevel(0);
        }
    }
}
