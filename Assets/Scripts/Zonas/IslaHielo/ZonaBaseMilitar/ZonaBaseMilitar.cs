using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaBaseMilitar : MonoBehaviour
{
    [SerializeField]
    private protected GameObject humos;

    [SerializeField]
    private protected GameObject chispas;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            LogicaObjetivosTemplo.GetInstance().SetNewMission("Investiga la base militar");
            //activamos canvas Objetos Interactuables
            GameManager.GetInstance().SetObjetosInteractivosLeft(true);
        }
       
        
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            //activamos humo y efectos de particulas
            humos.SetActive(true);
            chispas.SetActive(true);
            LogicaObjetivosTemplo.GetInstance().SetNewMission("Interactua con todos los elementos");
        }
        
    }

   

    private void Update()
    {
       
    }
}
