using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // [SerializeField] private Image HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthUpdate(float dmg)
    {
        gameObject.GetComponent<PlayerStats>().health += dmg;
        // Debug.Log($"Player changed by {dmg} he now has {gameObject.GetComponent<PlayerStats>().Health}");
    }

    public float GetHealth()
    {
        return gameObject.GetComponent<PlayerStats>().health;
    }

    
}
