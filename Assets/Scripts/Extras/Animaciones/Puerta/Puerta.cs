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
            //reproduces el sonido de su audioSource
            this.GetComponent<AudioSource>().Play(0);
            puerta.Play("Abrir");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //reproduces el sonido de su audioSource
            this.GetComponent<AudioSource>().Play(0);
            puerta.Play("Cerrar");
        }
       
    }
}
