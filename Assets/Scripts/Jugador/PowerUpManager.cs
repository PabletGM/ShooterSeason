using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//gestiona PowerUps y consumibles
public class PowerUpManager : MonoBehaviour
{
    GameManager _myGameManager; 

    //instancia unica singleton
    static private PowerUpManager _instance;


    ///habilita escalera entrada camino y salir del templo
    [SerializeField]
    private GameObject _habilitarEscalera;


    //habilitarZonaEscalera
    public void HabilitarZonaEscaleraLevel1()
    {
        //queremos habilitar el isTrigger del boxCollider del GO habilitarEscaleras para que el player pueda pasar
        Destroy(_habilitarEscalera);
    }

    static public PowerUpManager GetInstance()
    {
        return _instance;
    }
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

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        //si la instancia existe , destruimos la copia
        else
        {
            Destroy(this.gameObject);
        }

    }
}


