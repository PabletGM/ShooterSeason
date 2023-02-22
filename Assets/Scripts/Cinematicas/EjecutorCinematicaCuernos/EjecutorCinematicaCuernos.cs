using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EjecutorCinematicaCuernos : MonoBehaviour
{
    //creamos un evento
    [SerializeField]
    private protected UnityEvent evento;

    [SerializeField]
    private protected GameObject zonaPuebloHieloDesbloqueada;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //desbloqueamos su script
            zonaPuebloHieloDesbloqueada.GetComponent<EventoZonaPuebloHelado>().enabled = true;
            //desbloqueamos zona desfiladero y su BoxCollider para que se pueda hacer recuento enemigos
            zonaPuebloHieloDesbloqueada.GetComponent<BoxCollider>().enabled = true;
            //si se choca el player invocamos evento
            evento.Invoke();
        }
    }

    public void HabilitarCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
