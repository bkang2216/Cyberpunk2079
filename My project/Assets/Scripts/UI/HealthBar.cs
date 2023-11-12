using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;
    private Slider slider;
    void Awake() 
    {
        slider = GetComponent<Slider>();
    }
    void Update() 
    {
        // if the health is less than 0, turn off the fill
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        // if the health is greater than 0, and the fill is off, turn it back on
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = playerHealth.currentHealth;

        // if the health is at 50, turn the fill yellow
        if (fillValue <= slider.maxValue / 2)
        {
            fillImage.color = Color.yellow;
        }

        // if the health is at 30, turn the fill white, else turn red
        if (fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.white;
        }
        else if(fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }
        slider.value = fillValue;  
    }
}
