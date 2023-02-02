using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    public Slider sliderEnemy;
    public Gradient gradientEnemy;
    public Image fillEnemy;

    public void SetEnemyHealth(int health)
    {
        sliderEnemy.value = health;
        //rellena el color segun el valor del slider por el gradiente y los intervalos
        fillEnemy.color = gradientEnemy.Evaluate(sliderEnemy.normalizedValue);
    }

    public void SetEnemyMaxHealth(int health)
    {
        //pones el valor de salud a el valor maximo y el actual del slider
        sliderEnemy.maxValue = health;
        sliderEnemy.value = health;
        //rellenar el color
        fillEnemy.color = gradientEnemy.Evaluate(1f);
    }
    
}
