using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosZonaNPC : MonoBehaviour
{

    #region references
    private LogicaObjetivosTemplo logicaMisiones;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        logicaMisiones = LogicaObjetivosTemplo.GetInstance();
    }

    private void OnTriggerEnter(Collider collision)
    {


        //si entra jugador cambia mision
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            Debug.Log("Entro jugador");
            //activando misiones
            GameManager.GetInstance().SetMisiones(true);
            //si detecta a jugador damos nueva señal para cambio de mision
            LogicaObjetivosTemplo.GetInstance().SetNewMission("Interactua con el NPC");


        }
    }
}