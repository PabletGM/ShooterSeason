using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivarPortales : MonoBehaviour
{
    //creamos un evento
    [SerializeField]
    private protected UnityEvent eventoPortales;

    #region candados
    [SerializeField]
    private protected GameObject candadoAbiertoIsla1;
    [SerializeField]
    private protected GameObject candadoCerradoIsla1;
    [SerializeField]
    private protected GameObject candadoAbiertoIsla11;
    [SerializeField]
    private protected GameObject candadoCerradoIsla12;

    [SerializeField]
    private protected GameObject candadoAbiertoIsla2;
    [SerializeField]
    private protected GameObject candadoCerradoIsla2;
    [SerializeField]
    private protected GameObject candadoAbiertoIsla21;
    [SerializeField]
    private protected GameObject candadoCerradoIsla22;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        SetGizmoCandados(false);
        //desactivamos manualmente los GizmoController de los candados antes del cinematica
        //hacer evento que haga inicio de portales
        //si se choca el player invocamos evento
        //este evento en cada portal---> quita efecto de particulas y desactiva TeletransporteCollide
        //desactiva icono cerrado candado y pone candado abierto
        eventoPortales.Invoke();
    }

    ////al salir del collider
    //private void OnTriggerExit(Collider other)
    //{
    //    SetGizmoCandados(true);
    //}

    //activa o desactiva el componente GizmoController de el GameObject candado correspondiente
    private void SetGizmoCandados(bool set)
    {
        candadoAbiertoIsla1.GetComponent<GizmoController>().enabled = set;
        candadoCerradoIsla1.GetComponent<GizmoController>().enabled = set;
        candadoAbiertoIsla11.GetComponent<GizmoController>().enabled = set;
        candadoCerradoIsla12.GetComponent<GizmoController>().enabled = set;
        candadoAbiertoIsla2.GetComponent<GizmoController>().enabled = set;
        candadoCerradoIsla2.GetComponent<GizmoController>().enabled = set;
        candadoAbiertoIsla21.GetComponent<GizmoController>().enabled = set;
        candadoCerradoIsla22.GetComponent<GizmoController>().enabled = set;
    }
}
