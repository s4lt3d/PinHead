using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Sub Behaviours")]
    public PlayerMovementBehaviour playerMovementBehaviour;

    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    private bool jump = false;
    private bool swingccw = false;
    private bool swingcw = false;

    public Camera mainCamera;

    [Header("Input Settings")]
    public PlayerInput playerInput;

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnJump(InputAction.CallbackContext value)
    {

        jump = value.ReadValueAsButton();

    }

    public void OnSwing(InputAction.CallbackContext value)
    {
        swingccw = value.ReadValueAsButton();
    }

    public void OnSwingCW(InputAction.CallbackContext value)
    {
        swingcw = value.ReadValueAsButton();
    }

    private void Update()
    {
        UpdatePlayerMovement();
    }


    void UpdatePlayerMovement()
    {
        playerMovementBehaviour.UpdateMovementData(rawInputMovement);
        playerMovementBehaviour.UpdateJumpData(jump);
        playerMovementBehaviour.UpdateSwingCCWData(swingccw);
        playerMovementBehaviour.UpdateSwingCWData(swingcw);
    }


}
