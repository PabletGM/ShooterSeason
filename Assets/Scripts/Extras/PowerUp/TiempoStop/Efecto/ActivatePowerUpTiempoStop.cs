using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerUpTiempoStop : MonoBehaviour
{
    #region references
    GameManager _myGameManager;
    #endregion 
    //si el GO que toca este objeto el tiempo desaparece
    private void OnTriggerEnter(Collider collision)
    {
        //si el objeto que colisiona tiene el script PowerUpManager es que es el jugador
        if (collision.gameObject.GetComponent<PowerUpManager>())
        {
            //accedemos al script del Player PowerUpManager y a su metodo AumentoTiempo
            collision.gameObject.GetComponent<PowerUpManager>().QuitarNivelCronometrado();

            //activamos del GameManager el _myNivelAcabado1 = true
            _myGameManager._myNivel1Acabado = true;
            //lo destruyes 
            Destroy(this.gameObject);
            //actualizas numero  de enemigos level 2
            _myGameManager.NumEnemiesLevel2();
        }
    }
    
     void Start()
     {
        _myGameManager = GameManager.GetInstance();
     }
}
