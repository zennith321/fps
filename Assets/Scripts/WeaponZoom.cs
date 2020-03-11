using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutSens = 2f;
    [SerializeField] float zoomedInSens = 0.5f;

    RigidbodyFirstPersonController firstPersonController;

    bool zoomedInToggle = false;

    private void Start()
    {
        firstPersonController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomedInToggle)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
                firstPersonController.mouseLook.XSensitivity = zoomedInSens;
                firstPersonController.mouseLook.YSensitivity = zoomedInSens;
            }
            else 
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
                firstPersonController.mouseLook.XSensitivity = zoomedOutSens;
                firstPersonController.mouseLook.YSensitivity = zoomedOutSens;
            }
        }
    }
}
