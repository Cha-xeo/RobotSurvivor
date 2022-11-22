using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public float damage = 10f;
    public float impactForce = 100f;
    public ParticleSystem Explosion;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemie"){
            collision.gameObject.GetComponent<Health>().healthUpdate(-damage);
            var aled = Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(aled, 0.2f);
        }
        Destroy(gameObject);
    }
        private void OnDestroy() {
        }
}
