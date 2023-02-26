using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaBaseMilitar : MonoBehaviour
{
    [SerializeField]
    private protected GameObject humos;

    [SerializeField]
    private protected GameObject Explosion;

    [SerializeField]
    private protected GameObject chispas;

    private void OnTriggerEnter(Collider other)
    {
        LogicaObjetivosTemplo.GetInstance().SetNewMission("Investiga la base militar");
    }
    private void OnTriggerStay(Collider other)
    {
        //activamos humo y efectos de particulas
        humos.SetActive(true);
        chispas.SetActive(true);
        LogicaObjetivosTemplo.GetInstance().SetNewMission("Interactua con todos los elementos");
    }

    public void SetExplosion(bool set)
    {
        Explosion.SetActive(set);
    }
}
