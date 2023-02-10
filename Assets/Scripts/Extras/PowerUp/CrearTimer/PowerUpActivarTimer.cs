using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivarTimer : MonoBehaviour
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
            //accedemos al script del Player PowerUpManager y a su metodo ComenzarTimer
            collision.gameObject.GetComponent<PowerUpManager>().ComenzarTimer();
            //lo destruyes 
            Destroy(this.gameObject);

        }
    }

    void Start()
    {
        _myGameManager = GameManager.GetInstance();
    }
}
