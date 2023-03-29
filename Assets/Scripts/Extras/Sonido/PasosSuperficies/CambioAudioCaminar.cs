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
        //que solo suene 1 vez que ya se hace loop
        
            //se asocia el audioclip 1 vez
            player.GetComponent<AudioSource>().clip = AudioClipPasosNieve;
    }

    //si dejamos de tocar los colliders es que estamos tocando baldosas
    private void OnTriggerExit(Collider collision)
    {
       
            //accedemos al audiosource del player , al clip y lo cambiamos a la nieve que es la que tiene colliders
            player.GetComponent<AudioSource>().clip = AudioClipPasosBaldosas;

    }
}
