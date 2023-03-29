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

    private bool permisoCaminarNieve = true;
    private bool permisoCaminarBaldosas = true;

    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        //que solo suene 1 vez que ya se hace loop
        if (permisoCaminarNieve)
        {
            //se asocia el audioclip 1 vez
            player.GetComponent<AudioSource>().clip = AudioClipPasosNieve;
            permisoCaminarNieve = false;
            permisoCaminarBaldosas = true;
        }
    }

    //si dejamos de tocar los colliders es que estamos tocando baldosas
    private void OnTriggerExit(Collider collision)
    {
       //que solo suene 1 vez que ya se hace loop
        if (permisoCaminarBaldosas)
        {
            //accedemos al audiosource del player , al clip y lo cambiamos a la nieve que es la que tiene colliders
            player.GetComponent<AudioSource>().clip = AudioClipPasosBaldosas;
            permisoCaminarNieve = true;
            permisoCaminarBaldosas = false;
        }
    }
}
