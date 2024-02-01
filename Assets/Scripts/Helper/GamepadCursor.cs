using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class GamepadCursor : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private RectTransform cursorTransform;
    [SerializeField] private RectTransform canvasTransform;

    private Mouse virtualMouse;
    private float cursorSpeed = 1000f;
    private bool previousMouseState;
    private float padding = 10f;

    private string previousControlScheme = "";
    private Mouse currentMouse;
    private const string gamepadScheme = "Gamepad";
    private const string mouseScheme = "Keyboard&Mouse";

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Cursor.visible = false;
        if (previousControlScheme != playerInput.currentControlScheme)
        {
            cursorTransform.gameObject.SetActive(true);
            InputState.Change(virtualMouse.position, currentMouse.position.ReadValue());
            AnchorCursor(currentMouse.position.ReadValue());
        }
        if ( playerInput.currentControlScheme == mouseScheme )
        {
            cursorTransform.position = Input.mousePosition;
        }
        previousControlScheme = playerInput.currentControlScheme;
    }

    private void OnEnable()
    {
        currentMouse = Mouse.current;

        if ( virtualMouse == null )
        {
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        }
        else if ( ! virtualMouse.added )
        {
            InputSystem.AddDevice(virtualMouse);
        }

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if ( cursorTransform != null )
        {
            Vector2 position = cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, position);
        }
        Cursor.lockState = CursorLockMode.Confined;

        InputSystem.onAfterUpdate += UpdateMotion;

    }

    private void OnDisable()
    {
        if ( virtualMouse != null && virtualMouse.added)
        {
            //playerInput.user.UnpairDevice(virtualMouse);
            InputSystem.RemoveDevice(virtualMouse);
        }
        InputSystem.onAfterUpdate -= UpdateMotion;
    }

    private void UpdateMotion()
    {
        if ( virtualMouse == null || Gamepad.current == null )
        {
            return;
        }

        Vector2 deltaValue = Gamepad.current.rightStick.ReadValue();
        deltaValue *= cursorSpeed * Time.deltaTime;

        Vector2 currentPosition = virtualMouse.position.ReadValue();
        Vector2 newPosition = currentPosition + deltaValue;

        newPosition.x = Mathf.Clamp(newPosition.x, padding, Screen.width - padding);
        newPosition.y = Mathf.Clamp(newPosition.y, padding, Screen.height - padding) ;

        InputState.Change(virtualMouse.position, newPosition);
        InputState.Change(virtualMouse.delta, deltaValue);


        bool buttonPressed = Gamepad.current.aButton.isPressed;
        if (previousMouseState != buttonPressed)
        {
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, buttonPressed);
            InputState.Change(virtualMouse, mouseState);
            previousMouseState = buttonPressed;
        }

        AnchorCursor(newPosition);
    }

    private void AnchorCursor( Vector2 position )
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform, position, null, out anchoredPosition);
        cursorTransform.anchoredPosition = anchoredPosition;
    }

}

