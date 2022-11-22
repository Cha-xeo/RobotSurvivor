using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{

    private InputHandler _input;
    [SerializeField]
    private Camera Camera;
    private Animator anime;
    private float speedLimit = 1f;
    private LaseGun _gun1;
    private AssaultRifle _gun;
    public bool choosegun;

    private PlayerStats _stats;
    private void Awake() {
        _stats = GetComponent<PlayerStats>();
        _input = GetComponent<InputHandler>();
        anime = GetComponent<Animator>();
        _gun1 = transform.GetChild(1).GetComponent<LaseGun>();
        _gun = transform.GetChild(1).GetComponent<AssaultRifle>();
    }

    void Update()
    {
        Vector3 targetVector = new Vector3(_input.InputVector.x, 0,_input.InputVector.y);
        if (_input.Reload){
            if (choosegun){
                    StartCoroutine(_gun.reload());
                }else{
                    StartCoroutine(_gun1.reload());
                }
        }
        if (_input.Submit) choosegun = !choosegun;
        if(_input.Fire || _input.Look){
            if (_input.Fire){
                if (choosegun){
                    _gun.Shoot();
                }else{
                    _gun1.Shoot();
                }
            }if (_input.Look){
                if (choosegun){
                  _gun.Look();
                }else{
                  _gun1.Look();
                }
            }else{
                if (choosegun){
                  _gun.UnLook();
                }else{
                  _gun1.UnLook();
                }
            }
            speedLimit = 0.5f;
            MoveTowardTarget(targetVector);
            RotateTowardMouseVector();
        }else{
            _gun.UnLook();
            speedLimit = 1f;
            Vector3 movementVector = MoveTowardTarget(targetVector);
            RotateTowardMovementVector(movementVector);
        }
        anima(targetVector);
    }

    private void anima(Vector3 targetVector)
    {
        anime.SetFloat("zSpeed", targetVector.z * speedLimit);
        anime.SetFloat("xSpeed", targetVector.x * speedLimit);
        anime.SetFloat("Speed", targetVector.x*targetVector.x+targetVector.z+targetVector.z);
    }
    
    private void RotateTowardMouseVector()
    {

        Quaternion rotation = Quaternion.LookRotation(_input.MousePositionGround - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _stats.lookTurnSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        float speed = (_input.Shift) ? (_stats.moveSpeed+_stats.sprintBoost) * Time.deltaTime : _stats.moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed * speedLimit;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 targetVector)
    {   
        if (targetVector.magnitude == 0) {return;}
        Quaternion rotation = Quaternion.LookRotation(targetVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _stats.turnSpeed);
    }
}
