using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This script acts as a single point for all other scripts to get
// the current input from. It uses Unity's new Input System and
// functions should be mapped to their corresponding controls
// using a PlayerInput component with Unity Events.

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    private bool interactPressed = false;
    private bool jumpPressed = false;
    private bool settingsPressed = false;
    private bool menuPressed = false;
    private bool menuMoveLeftPressed = false;
    private bool menuMoveRightPressed = false;
    private bool closePressed = false;
    private bool confirmPressed = false;

    private static InputManager instance;
    private PlayerInput playerInput;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Input Manager in the scene.");
        }
        instance = this;
        playerInput = GetComponent<PlayerInput>();
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }
    public void InteractPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }

    public void JumpPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpPressed = true;
        }
        else if (context.canceled)
        {
            jumpPressed = false;
        }
    }

    public void SettingsPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            settingsPressed = true;
        }
        else if (context.canceled)
        {
            settingsPressed = false;
        }
    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            menuPressed = true;
        }
        else if (context.canceled)
        {
            menuPressed = false;
        }
    }
    public void MenuMoveLeftPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            menuMoveLeftPressed = true;
        }
        else if (context.canceled)
        {
            menuMoveLeftPressed = false;
        }
    }
    public void MenuMoveRightPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            menuMoveRightPressed = true;
        }
        else if (context.canceled)
        {
            menuMoveRightPressed = false;
        }
    }
    public void ClosePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            closePressed = true;
        }
        else if (context.canceled)
        {
            closePressed = false;
        }
    }
    public void ConfirmPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            confirmPressed = true;
        }
        else if (context.canceled)
        {
            confirmPressed = false;
        }
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }
    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetJumpPressed()
    {
        bool result = jumpPressed;
        jumpPressed = false;
        return result;
    }
    public bool GetSettingsPressed()
    {
        bool result = settingsPressed;
        settingsPressed = false;
        return result;
    }
    public bool GetMenuPressed()
    {
        bool result = menuPressed;
        menuPressed = false;
        return result;
    }
    public bool GetMenuMoveLeftPressed()
    {
        bool result = menuMoveLeftPressed;
        menuMoveLeftPressed = false;
        return result;
    }
    public bool GetMenuMoveRightPressed()
    {
        bool result = menuMoveRightPressed;
        menuMoveRightPressed = false;
        return result;
    }
    public bool GetClosePressed()
    {
        bool result = closePressed;
        closePressed = false;
        return result;
    }
    public bool GetConfirmPressed()
    {
        bool result = confirmPressed;
        confirmPressed = false;
        return result;
    }

    public PlayerInput GetPlayerInput()
    {
        return playerInput;
    }
}
