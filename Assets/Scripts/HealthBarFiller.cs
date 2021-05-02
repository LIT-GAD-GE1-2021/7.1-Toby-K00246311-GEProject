using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFiller : MonoBehaviour
{
    public HealthAndDeath healthAndDeath;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        float fillvalue = healthAndDeath.charHealth / healthAndDeath.charMaxHealth;
        slider.value = fillvalue;
    }
}
