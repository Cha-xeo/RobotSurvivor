using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    // public GameObject player;
    public TMP_Text HPtext;
    public TMP_ColorGradient Green;
    public TMP_ColorGradient Red;

    private void Start()
    {
        // Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        // healthBar = GetComponent<Slider>();
        // healthBar.fillAmount = Mathf.InverseLerp(0, Health.health, Health.MaxHealth);
        // healthBar.fillAmount = 0;
        // healthBar.value = Health.maxHealth;
    }

    public void SetHealth(float act, float max)
    {
        // Debug.Log("aled");
        if ((act*100)/max > 50){
            HPtext.colorGradientPreset = Green;
        }else{
            HPtext.colorGradientPreset = Red;
        }
        HPtext.text = act.ToString();
        healthBar.fillAmount = act/max;//act/max;
        // healthBar.fillAmount = Mathf.InverseLerp(0, act, 3f);
    }
}