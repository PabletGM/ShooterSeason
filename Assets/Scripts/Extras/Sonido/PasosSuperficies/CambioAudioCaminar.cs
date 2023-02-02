using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioAudioCaminar : MonoBehaviour
{
    #region properties

    //aqui pones el sonido que quieras segun el material
    [SerializeField]
    private protected AudioClip AudioClipPasos;


    //para acceder al player
    [SerializeField]
    private protected GameObject player;

    #endregion
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //accedemos al audiosource del player , al clip y lo cambiamos
            player.GetComponent<AudioSource>().clip = AudioClipPasos;
        }
    }
}
