using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public float damage = 10f;
    public float impactForce = 100f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.GetComponent<Rigidbody>()){
        //     collision.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * impactForce);
        // }
        if (collision.gameObject.tag == "Enemie"){
            collision.gameObject.GetComponent<EnemiesHealth>().healthUpdate(-damage);
            // var aled = Instantiate(collision.gameObject.GetComponent<HitImpact>().Impact, collision.position, Quaternion.LookRotation(hit.normal));
            // Destroy(aled, 0.5f);
        }
        Destroy(gameObject, 0.5f);
    }  
}
