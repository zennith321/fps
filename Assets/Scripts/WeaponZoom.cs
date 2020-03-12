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

    private bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

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
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        firstPersonController.mouseLook.XSensitivity = zoomedOutSens;
        firstPersonController.mouseLook.YSensitivity = zoomedOutSens;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        firstPersonController.mouseLook.XSensitivity = zoomedInSens;
        firstPersonController.mouseLook.YSensitivity = zoomedInSens;
    }
}
