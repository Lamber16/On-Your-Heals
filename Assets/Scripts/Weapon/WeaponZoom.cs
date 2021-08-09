using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera playerCamera;
    [SerializeField] RigidbodyFirstPersonController playerController;
    [SerializeField] float zoomedInFOV = 40f;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInSensitivity = 1f;
    [SerializeField] float zoomedOutSensitivity = 2f;

    bool zoomedInToggle;

    void OnEnable() 
    {
        zoomedInToggle = false;
    }

    void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            zoomedInToggle = !zoomedInToggle;
        }

        if(zoomedInToggle)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        playerCamera.fieldOfView = zoomedInFOV;
        playerController.mouseLook.XSensitivity = zoomedInSensitivity;
        playerController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    void ZoomOut()
    {
        playerCamera.fieldOfView = zoomedOutFOV;
        playerController.mouseLook.XSensitivity = zoomedOutSensitivity;
        playerController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }
}
