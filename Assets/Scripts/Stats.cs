using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public GameObject HealthBar;
    [SerializeField]private float _health;
    public float health {
        set{
            _health = value;
            if (_health > maxHealth){
                Debug.LogWarning("Exceeding maxHealth");
                _health = maxHealth;
            }else if (_health <= 0f) {
                _health = 0f;
                // Debug.Log("Player dies");
                Destroy(gameObject);
            }
            if (HealthBar)
                HealthBar.GetComponent<HealthBar>().SetHealth(_health, maxHealth);
            // Debug.Log($"player has {_health} health");
        }
        get => _health;
    }

    [SerializeField]private float _maxHealth;
    public float maxHealth { set{_maxHealth = value; health = value;} get => _maxHealth; }

    [SerializeField]private float _moveSpeed;
    public float moveSpeed {set{_moveSpeed = value;}get => _moveSpeed;}

    [SerializeField]private float _sprintBoost;
    public float sprintBoost {set{_sprintBoost = value;}get => _sprintBoost;}

    [SerializeField]private float _turnSpeed;
    public float turnSpeed {set{_turnSpeed = value;}get => _turnSpeed;}

    [SerializeField]private float _lookTurnSpeed;
    public float lookTurnSpeed {set{_lookTurnSpeed = value;}get => _lookTurnSpeed;}

    // damage
    [SerializeField]private float _force;
    public float force {set{_force = value;}get => _force;}

    // can the move
    [SerializeField]private bool _canMove;
    public bool canMove { set{ _canMove = value;}get => _canMove; }
    // attack range
    [SerializeField]private float _range;
    public float range { set{ _range = value;}get => _range; }
    // attack speed
    [SerializeField]private float _attackSpeed;
    public float attackSpeed { set{ _attackSpeed = value;}get => _attackSpeed; }

    // private bool slowed = false;
    // private bool doted = false;
    // public float dotRate = 1f;
    // public float nextDotTick = 0.0f;
    // private float dotDamage = 0.0f;
    private void Awake() {
        // maxHealth = _maxHealth;
        // moveSpeed = _moveSpeed;
        // ALED
        health = maxHealth;
    }

    // private void Update() {
    //     if (doted)
    //     {
    //         if (Time.time > nextDotTick) {
    //             nextDotTick = Time.time  + dotRate;
    //             gameObject.GetComponent<Health>().healthUpdate(-dotDamage);
    //             // Health -= dotDamage;
    //         }
    //     }
    // }

    // public void Affliction(int type/* change to a enum */, float duration, float potency = 0f)
    // {
    //     switch (type)
    //     {
    //         case 1:
    //             if (!doted){
    //                 DebuffBar.GetComponent<DebuffBar>().BeginDebuff(1, duration);
    //                 StartCoroutine(DotDamage(duration, potency));
    //             }
    //             break;
    //         case 2:
    //             if (!slowed){
    //                 DebuffBar.GetComponent<DebuffBar>().BeginDebuff(2, duration);
    //                 StartCoroutine(ChangeMS(duration, potency));
    //             }
    //             // slow
    //             break;
    //         case 3:
    //             // heal
    //             break;
    //         case 4  :
    //             // break def
    //             break;
    //         default:
    //             Debug.LogWarning($"type: {type} not implemented");
    //             break;
    //     }
    // }

    // private IEnumerator ChangeMS(float duration, float potency = 0f)
    // {
    //     float basems = MoveSpeed;
    //     MoveSpeed -= (potency*MoveSpeed)/100;
    //     slowed = true;
    //     yield return new WaitForSeconds(duration);
    //     slowed = false;
    //     MoveSpeed = basems;
    // } 
    // private IEnumerator DotDamage(float duration, float potency = 0f)
    // {
    //     doted = true;
    //     dotDamage = potency;
    //     yield return new WaitForSeconds(duration);
    //     dotDamage = 0f;
    //     doted = false;
    // } 
}
