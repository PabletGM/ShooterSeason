using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTorret : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetTurretHealth(int health)
    {
        slider.value = health;
        //rellena el color segun el valor del slider por el gradiente y los intervalos
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetTurretMaxHealth(int health)
    {
        //pones el valor de salud a el valor maximo y el actual del slider
        slider.maxValue = health;
        slider.value = health;
        //rellenar el color
        fill.color = gradient.Evaluate(1f);
    }
}
