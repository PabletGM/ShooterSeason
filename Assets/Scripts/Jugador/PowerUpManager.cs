using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//gestiona PowerUps y consumibles
public class PowerUpManager : MonoBehaviour
{
    GameManager _myGameManager;

    //comunica al GameManager el aumento de Tiempo
    public void AumentoTiempo(float ExtraTime)
    {
        _myGameManager.AumentoTiempo(ExtraTime);
    }
    //paraliza el tiempo porque ya no es un nivel cronometrado
    public void QuitarNivelCronometrado()
    {
        _myGameManager._nivelCronometrado = false;
    }

    //comenzar timer
    public void ComenzarTimer()
    {
        _myGameManager.SetNivelCronometrado(true);
    }
    void Start()
    {
        _myGameManager = GameManager.GetInstance();
    }
}


