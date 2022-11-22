using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private InputHandler _input;
    public GameObject[] _guns;
    public bool guns;
    private void Awake() {
        _input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(guns){
        //     _gun.GetComponent<AssaultRifle>().enabled = true;
        //     _gun.GetComponent<LaseGun>().enabled = false;
        //  }else{
        //     _gun.GetComponent<AssaultRifle>().enabled = false;
        //     _gun.GetComponent<LaseGun>().enabled = true;
        //  }
        // if (_input.Submit){
        //     guns = !guns;
        // }
    }
}
