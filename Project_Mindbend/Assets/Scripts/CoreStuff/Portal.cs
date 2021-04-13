using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public MeshRenderer screen;
    Camera playerCam;
    Camera portalCam;
    RenderTexture viewTexture;

    void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
        screen.enabled = true;
    }

    void CreateViewTexture()
    {
        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height)
        {
            if (viewTexture != null)
            {
                viewTexture.Release();
            }
            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
            // Renders the view from the portal camera to the view of the texture
            portalCam.targetTexture = viewTexture; 
            //Displays the view texture of the linked portal onto the screen
            linkedPortal.screen.material.SetTexture("_MainTex", viewTexture);
        }
    }

    // This is called before the player camera has been rendered
    public void Render() 
    {
        screen.enabled = false;
        CreateViewTexture();

        //Make portal cam position and rotation the same relative to this portal as the player cam is relative to the linked portal
        var m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix * playerCam.transform.localToWorldMatrix;
        portalCam.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);

        //Render the camera
        portalCam.Render();

        screen.enabled = true;
    }
}
