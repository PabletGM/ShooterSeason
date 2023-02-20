using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EjecutorCinematicaCuernos : MonoBehaviour
{
    //creamos un evento
    [SerializeField]
    private protected UnityEvent evento;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
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
