using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionArribaMontaña : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LogicaObjetivosTemplo.GetInstance().SetNewMission("VInvestiga la zona");
        //activamos efecto de particulas de humo

        //desactivamos este gameObject
    }
}
