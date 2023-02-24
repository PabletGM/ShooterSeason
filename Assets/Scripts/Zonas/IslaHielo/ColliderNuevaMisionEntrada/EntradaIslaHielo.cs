using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaIslaHielo : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
            //si detecta a jugador damos nueva señal para cambio de mision
            LogicaObjetivosTemplo.GetInstance().SetNewMission("Sube a la cima de la montaña");        
    }
}
