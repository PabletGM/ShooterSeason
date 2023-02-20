using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField]
    private protected Animator puerta;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            puerta.Play("Abrir");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puerta.Play("Cerrar");
        }
       
    }
}
