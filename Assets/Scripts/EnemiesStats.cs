using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesStats : MonoBehaviour
{
    private float _health = 0f;
    public float Health {
        set{
            _health = value;
            if (_health > MaxHealth){
                // Debug.LogWarning("Exceeding maxHealth");
                _health = MaxHealth;
            }else if (_health <= 0f) {
                _health = 0f;
                // Debug.Log("Ennemy dies");
                Destroy(gameObject);
            }
            // Debug.Log($"Ennemy has {_health} health");
        }
        get => _health;
    }

    [SerializeField]private float _maxHealth = 100f;
    public float MaxHealth {
        set{
            _maxHealth = value;
            // Debug.Log($"player has {_maxHealth} MaxHealth");
        }
        get => _maxHealth;
    }
    // [SerializeField]private float _moveSpeed = 6f;
    // public float MoveSpeed {
    //     set{
    //         _moveSpeed = value;
    //         // transform.parent.gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed = _moveSpeed;
    //         // Debug.Log($"player has {_moveSpeed} MaxHealth");
    //     }
    //     get => _moveSpeed;
    // }
    // [SerializeField]private float _attackRange = 6f;
    // public float AttackRange {
    //     set{
    //         _attackRange = value;
    //         // transform.parent.gameObject.GetComponent<Pathfinding.AIPath>().slowdownDistance = _attackRange;
    //         // Debug.Log($"player has {_moveSpeed} MaxHealth");
    //     }
    //     get => _attackRange;
    // }

    // [SerializeField]private float _stoppingRange = 6f;
    // public float StoppingRange {
    //     set{
    //         _stoppingRange = value;
    //         // gameObject.GetComponent<Pathfinding.AIPath>().endReachedDistance = _stoppingRange;
    //         // Debug.Log($"player has {_moveSpeed} MaxHealth");
    //     }
    //     get => _stoppingRange;
    // }

    private void Awake() {
        MaxHealth = _maxHealth;
        // MoveSpeed = _moveSpeed;
        
        Health = MaxHealth;
    }
}
