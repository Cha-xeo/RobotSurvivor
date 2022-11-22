using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitImpact : MonoBehaviour
{
    public GameObject HitEffect;
    public GameObject Impact;

    private void Awake()
    {
        Impact = HitEffect.transform.GetChild(0).gameObject;
    }
}
