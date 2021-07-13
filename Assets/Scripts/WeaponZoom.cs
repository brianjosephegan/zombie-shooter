using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = 0.5f;

    RigidbodyFirstPersonController fpsController;
    bool zoomedInToggle = false;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle)
            {
                ZoomOut();
            }
            else
            {
                ZoomIn();
            }
        }
    }

    void OnEnable()
    {
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    void OnDisable()
    {
        ZoomOut();
    }

    private void ZoomOut()
    {
        fpCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
        zoomedInToggle = false;
    }

    private void ZoomIn()
    {
        fpCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
        zoomedInToggle = true;
    }
}
