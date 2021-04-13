using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Portal[] portals;

    void Awake()
    {
        portals = FindObjectsOfType<Portal>();
    }
}
