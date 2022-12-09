using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public BoxCollider axeHitBox;
    [SerializeField] private float _axeDamage;
    public float axeDamage { set { _axeDamage = value; } get => _axeDamage; }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player"){
            float wielderDamage = transform.parent.parent.GetComponent<Stats>().force;
            other.gameObject.GetComponent<Health>().healthUpdate(-(_axeDamage + wielderDamage));    
        }
    }
}
