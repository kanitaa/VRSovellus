using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleMovement : MonoBehaviour
{
    public InputActionReference movementToggleReference = null;

    [SerializeField]
    TeleportationProvider teleportationProvider;

    [SerializeField]
    ActionBasedContinuousMoveProvider continuousMoveProvider;



    private void Awake()
    {
        movementToggleReference.action.started += Toggle;
    }

    private void OnDestroy()
    {
        movementToggleReference.action.started -= Toggle;
    }

    void Toggle(InputAction.CallbackContext context)
    {
        if (teleportationProvider.enabled)
        {
            teleportationProvider.enabled = false;

            continuousMoveProvider.enabled = true;

        }
        else
        {
            teleportationProvider.enabled = true;

            continuousMoveProvider.enabled = false;
        }

    }
}
