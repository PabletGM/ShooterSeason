using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderPlayer;
    public Gradient gradientPlayer;
    public Image fillPlayer;

    //scripts health bar player
    public void SetHealth(int health)
    {
        sliderPlayer.value = health;
        //rellena el color segun el valor del slider por el gradiente y los intervalos
        fillPlayer.color = gradientPlayer.Evaluate(sliderPlayer.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        //pones el valor de salud a el valor maximo y el actual del slider
        sliderPlayer.maxValue = health;
        sliderPlayer.value = health;
        //rellenar el color
        fillPlayer.color = gradientPlayer.Evaluate(1f);
    }
    
}
