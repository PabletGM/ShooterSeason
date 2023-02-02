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
    //paraliza el tiempo para modo ruta ilimitado
    public void ParalizarTiempoModoRuta()
    {
        _myGameManager._myModoRutaLibre = true;
    }
    void Start()
    {
        _myGameManager = GameManager.GetInstance();
    }
}


