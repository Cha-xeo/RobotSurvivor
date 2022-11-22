using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    private Vector3 mousePosition = Vector3.zero;
    private bool interactPressed = false;
    private bool submitPressed = false;
    private bool rightMousePressed = false;
    private bool leftMousePressed = false;
    private bool jumpPressed = false;
    private bool escapePressed = false;

    private static InputManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static InputManager GetInstance() 
    {
        return instance;
    }

    /* Move */
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
    public Vector2 GetMoveDirection() 
    {
        return moveDirection;
    }

    /* Mouse Move */
    public void MousePressed(InputAction.CallbackContext context)
    {
        // Debug.Log(context);
        if (context.performed)
        {
            mousePosition = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            mousePosition = context.ReadValue<Vector2>();
        } 
    }
    public Vector2 GetMousePosition() 
    {
        // return (PlayerInput.Camera) ? PlayerInput.Camera.ScreenToWorldPoint(mousePosition) : Camera.main.ScreenToWorldPoint(mousePosition);
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    public Vector2 GetRawMousePosition() 
    {
        // return (PlayerInput.Camera) ? PlayerInput.Camera.ScreenToWorldPoint(mousePosition) : Camera.main.ScreenToWorldPoint(mousePosition);
        return mousePosition;
    }

    /* Right Click */
    public void RightMouseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rightMousePressed = true;
        }
        else if (context.canceled)
        {
            rightMousePressed = false;
        } 
    }

    public bool GetRightMousePressed() 
    {
        bool result = rightMousePressed;
        rightMousePressed = false;
        return result;
    }

    /* Left Click */
    public void LeftMouseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            leftMousePressed = true;
        }
        else if (context.canceled)
        {
            leftMousePressed = false;
        } 
    }
    public bool GetLeftMousePressed() 
    {
        bool result = leftMousePressed;
        leftMousePressed = false;
        return result;
    }

    /* Interact */
    public void InteractButtonPressed(InputAction.CallbackContext context)
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

    public bool GetInteractPressed() 
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    
    /* Submit */
    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        } 
    }

    public bool GetSubmitPressed() 
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    public void RegisterSubmitPressed() 
    {
        submitPressed = false;
    }
    /* Jump */
    public void JumpButtonPressed(InputAction.CallbackContext context)
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

    public bool GetJumpPressed() 
    {
        bool result = jumpPressed;
        jumpPressed = false;
        return result;
    }
    
    /* Escape */
    public void EscapeButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            escapePressed = true;
        }
        else if (context.canceled)
        {
            escapePressed = false;
        } 
    }

    public bool GetEscapePressed() 
    {
        bool result = escapePressed;
        escapePressed = false;
        return result;
    }

    /* Save */
    private bool savePressed = false;
    public void SaveButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            savePressed = true;
        }
        else if (context.canceled)
        {
            savePressed = false;
        } 
    }

    public bool GetSavePressed() 
    {
        bool result = savePressed;
        savePressed = false;
        return result;
    }

    /* Load */
    private bool loadPressed = false;
    public void LoadButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            loadPressed = true;
        }
        else if (context.canceled)
        {
            loadPressed = false;
        } 
    }

    public bool GetLoadPressed() 
    {
        bool result = loadPressed;
        loadPressed = false;
        return result;
    }
    
    /* Up */
    private bool upPressed = false;
    public void UpButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            upPressed = true;
        }
        else if (context.canceled)
        {
            upPressed = false;
        } 
    }

    public bool GetUpPressed() 
    {
        bool result = upPressed;
        upPressed = false;
        return result;
    }
    
    /* Right */
    private bool rightPressed = false;
    public void RightButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rightPressed = true;
        }
        else if (context.canceled)
        {
            rightPressed = false;
        } 
    }

    public bool GetRightPressed() 
    {
        bool result = rightPressed;
        rightPressed = false;
        return result;
    }
    
    /* Left */
    private bool leftPressed = false;
    public void LeftButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            leftPressed = true;
        }
        else if (context.canceled)
        {
            leftPressed = false;
        } 
    }

    public bool GetLeftPressed() 
    {
        bool result = leftPressed;
        leftPressed = false;
        return result;
    }
    
    /* Down */
    private bool downPressed = false;
    public void DownButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            downPressed = true;
        }
        else if (context.canceled)
        {
            downPressed = false;
        } 
    }

    public bool GetDownPressed() 
    {
        bool result = downPressed;
        downPressed = false;
        return result;
    }
    
    /* Shift */
    private bool shiftPressed = false;
    public void ShiftButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shiftPressed = true;
        }
        else if (context.canceled)
        {
            shiftPressed = false;
        } 
    }

    // Hold
    public bool GetShiftPressed() 
    {
        bool result = shiftPressed;
        return result;
    }

    // Fire
    private bool firePressed = false;
    public void FireButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            firePressed = true;
        }
        else if (context.canceled)
        {
            firePressed = false;
        } 
    }

    public bool GetFirePressed() 
    {
        bool result = firePressed;
        // firePressed = false;
        return result;
    }


    // Look
    private bool lookPressed = false;
    public void LookButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lookPressed = true;
        }
        else if (context.canceled)
        {
            lookPressed = false;
        } 
    }

    public bool GetLookPressed() 
    {
        bool result = lookPressed;
        // lookPressed = false;
        return result;
    }
    /* Reload */
    private bool reloadPressed = false;
    public void ReloadButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            reloadPressed = true;
        }
        else if (context.canceled)
        {
            reloadPressed = false;
        } 
    }

    public bool GetReloadPressed() 
    {
        bool result = reloadPressed;
        reloadPressed = false;
        return result;
    }
}
