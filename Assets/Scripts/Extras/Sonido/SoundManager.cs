using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    /// Unique GameManager instance (Singleton Pattern).
    /// </summary>
    static private SoundManager _instanceSoundManager;

    //control de audio
    private AudioSource controlAudio;

    //array que contenga todos los audioclips del juego
    [SerializeField] private protected AudioClip[] audios;
   
    void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
       
            //si la instancia no existe se hace este script la instancia
        if (_instanceSoundManager == null)
        {
            _instanceSoundManager = this;
        }
        //si la instancia existe , destruimos la copia
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SeleccionAudio(int indice , float volumen)
    {
        //pone un audioClip con volumen determinado
        controlAudio.PlayOneShot(audios[indice], volumen);

    }
    

}
