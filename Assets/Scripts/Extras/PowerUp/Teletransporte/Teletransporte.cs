using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teletransporte : MonoBehaviour
{

    [SerializeField]
    private protected Transform Target;

    [SerializeField]
    private protected GameObject ThePlayer;

    [SerializeField]
    private protected UnityEvent eventoCambioIsla;

    private bool permitirCinematica = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cogido");
        //comprobamos si es el portal a la islaHielo para poner cinematica
        if(permitirCinematica && this.gameObject.transform.parent.name == "puertaTeleportCinematica")
        {
            //solo se hace 1 vez
            eventoCambioIsla.Invoke();
            permitirCinematica = false;
        }
        
        //la  posicion del jugador pasa a ser la del target
        ThePlayer.transform.position = Target.transform.position;
        //si estamos en la puerta del inicio y vamos a la del pueblo 2 desconectamos temporalmente el trigger de la otra para poder teletransportarnos
        
    }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
