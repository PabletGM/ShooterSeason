using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionArribaMontaña : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LogicaObjetivosTemplo.GetInstance().SetNewMission("Investiga la zona");
        //desactivamos este gameObject
        this.gameObject.SetActive(false);
    }
}
