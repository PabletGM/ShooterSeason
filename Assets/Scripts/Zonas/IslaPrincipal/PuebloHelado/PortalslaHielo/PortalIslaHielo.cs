using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalIslaHielo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LogicaObjetivosTemplo.GetInstance().SetNewMission("Averigua que esconde el segundo portal...");
    }
}
