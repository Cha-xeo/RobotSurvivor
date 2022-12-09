using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Vector2 InputVector {get; private set;}
    public Vector3 MousePosition {get; private set;}
    public Vector3 RawMousePosition {get; private set;}
    public Vector3 MousePositionGround {get; private set;}
    public bool LeftClick {get; private set;}
    public bool Shift {get; private set;}
    public bool Fire {get; private set;}
    public bool Look {get; private set;}
    public bool Reload {get; private set;}
    public bool Submit {get; private set;}
    public Transform barel;

    [SerializeField]
    private Camera Camera;
    private void FixedUpdate()
    {
        Submit = InputManager.GetInstance().GetSubmitPressed();
        InputVector = InputManager.GetInstance().GetMoveDirection();
        MousePosition = InputManager.GetInstance().GetMousePosition();
        RawMousePosition = InputManager.GetInstance().GetRawMousePosition();
        // LeftClick = InputManager.GetInstance().GetLeftMousePressed();
        Reload = InputManager.GetInstance().GetReloadPressed();
        Shift = InputManager.GetInstance().GetShiftPressed();
        Fire = InputManager.GetInstance().GetFirePressed();
        Look = InputManager.GetInstance().GetLookPressed();
        Ray ray = Camera.ScreenPointToRay(RawMousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f)){
            var target = hitInfo.point; 
            target.y = transform.position.y;
            MousePositionGround = target;
        }
    }
}
