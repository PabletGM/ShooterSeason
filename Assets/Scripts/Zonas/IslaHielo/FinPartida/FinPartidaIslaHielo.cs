using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinPartidaIslaHielo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            //cambiamos de escena
        }
    }
}
