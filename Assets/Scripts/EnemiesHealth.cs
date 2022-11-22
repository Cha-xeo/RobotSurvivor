using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    public void healthUpdate(float dmg)
    {
        if (dmg > 0 ){
            // TODO enemies disolve effect
        }
        GetComponent<EnemiesStats>().Health += dmg;
        // Debug.Log($"Player changed by {dmg} he now has {gameObject.GetComponent<PlayerStats>().Health}");
    }

    public float GetHealth()
    {
        return GetComponent<EnemiesStats>().Health;
    }
}
