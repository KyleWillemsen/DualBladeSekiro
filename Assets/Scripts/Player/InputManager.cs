using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    PlayerControls playerControls;
    AnimatorManager animManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraVerticalInput;
    public float cameraHorizontalInput;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            return;
        }
        instance = this;

        animManager = GetComponent<AnimatorManager>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraVerticalInput = cameraInput.y;
        cameraHorizontalInput = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animManager.UpdateAnimatorValues(0, moveAmount);
    }
}
