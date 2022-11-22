using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaseBullet : MonoBehaviour
{
    public void shoot(Vector3 origin, Vector3 target)
    {
        if (Physics.Raycast(origin, transform.TransformDirection(target), out RaycastHit hitInfo, maxDistance: 300f)){
            Debug.DrawRay(transform.position, transform.TransformDirection(target) * hitInfo.distance, Color.yellow);
            if (hitInfo.transform.gameObject.tag == "Enemie")
            {
                Debug.Log("Enemie hit");
            }
        }
    }
}
