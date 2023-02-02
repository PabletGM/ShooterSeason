using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemyDron : MonoBehaviour
{
    public Slider sliderDron;
    public Gradient gradientDron;
    public Image fillDron;

    public void SetDronHealth(int health)
    {
        sliderDron.value = health;
        //rellena el color segun el valor del slider por el gradiente y los intervalos
        fillDron.color = gradientDron.Evaluate(sliderDron.normalizedValue);
    }

    public void SetDronMaxHealth(int health)
    {
        //pones el valor de salud a el valor maximo y el actual del slider
        sliderDron.maxValue = health;
        sliderDron.value = health;
        //rellenar el color
        fillDron.color = gradientDron.Evaluate(1f);
    }
}
