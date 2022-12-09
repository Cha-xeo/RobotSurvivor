using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform targetGo;
    [SerializeField] private Transform _thisTranform;
    [SerializeField] private Animator _anime;
    [SerializeField] private Stats _stats;
    [SerializeField] private BoxCollider _axeHitBox;
    public float axeDamage;
    private float distance;
    private float nextSwing;

    private void FixedUpdate()
    {
        distance = Vector3.Distance(targetGo.position, _thisTranform.position);
        if (distance <= _stats.range)
        {
            if (nextSwing + _stats.attackSpeed < Time.time)
            {
                _anime.SetTrigger("Attack");
                nextSwing = Time.time;
            }
        }
    }

    public void attack()
    {
        _axeHitBox.enabled = !_axeHitBox.enabled;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().healthUpdate(-(axeDamage + _stats.force));
        }
    }
}
