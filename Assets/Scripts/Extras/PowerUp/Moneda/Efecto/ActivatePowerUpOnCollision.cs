using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  //componente que tendrán los powerUps que permitiran al tocarlos activar su funcion
public class ActivatePowerUpOnCollision : MonoBehaviour
{
    #region references
    private SoundManager soundManager;
    #endregion

    #region parameters
    public float TiempoExtra = 5f;
    #endregion

    void Awake()
    {
        //sonido, busca objeto de tipo sonido
        soundManager = FindObjectOfType<SoundManager>();
    }
    //si el GO que toca este objeto posee el script PowerUpManager
    private void OnTriggerEnter(Collider collision)
    {
        //si el objeto que colisiona tiene el script PowerUpManager es que es el jugador
        if (collision.gameObject.GetComponent<PowerUpManager>())
        {
            //accedemos al script del Player PowerUpManager y a su metodo AumentoTiempo
            collision.gameObject.GetComponent<PowerUpManager>().AumentoTiempo(TiempoExtra);
            //lo pones por consola

            //pones sonido de moneda la posicion 0 a mitad de sonido 
            soundManager.SeleccionAudio(0, 0.5f);
            
            //lo destruyes 
            Destroy(this.gameObject);
        }
    }
}

