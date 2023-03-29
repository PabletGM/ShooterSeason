using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioAudioCaminar : MonoBehaviour
{
    #region properties

    //aqui pones el sonido que quieras segun el material
    [SerializeField]
    private protected AudioClip AudioClipPasosNieve;

    //aqui pones el sonido que quieras segun el material
    [SerializeField]
    private protected AudioClip AudioClipPasosBaldosas;

    //para acceder al player
    [SerializeField]
    private protected GameObject player;

    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //accedemos al audiosource del player , al clip y lo cambiamos a la nieve que es la que tiene colliders
            player.GetComponent<AudioSource>().clip = AudioClipPasosNieve;
        }
    }

    //si dejamos de tocar los colliders es que estamos tocando baldosas
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            //accedemos al audiosource del player , al clip y lo cambiamos a la nieve que es la que tiene colliders
            player.GetComponent<AudioSource>().clip = AudioClipPasosBaldosas;
        }
    }
}
