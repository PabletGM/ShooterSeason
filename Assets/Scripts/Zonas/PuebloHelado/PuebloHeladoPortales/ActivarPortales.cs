using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivarPortales : MonoBehaviour
{
    //creamos un evento
    [SerializeField]
    private protected UnityEvent eventoPortales;

    private void OnTriggerEnter(Collider other)
    {
        //hacer evento que haga inicio de portales
        //si se choca el player invocamos evento
        //este evento en cada portal---> quita efecto de particulas y desactiva TeletransporteCollide
        //desactiva icono cerrado candado y pone candado abierto
        eventoPortales.Invoke();
    }
}
