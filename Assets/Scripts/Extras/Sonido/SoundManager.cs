using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //control de audio
    private AudioSource pasosNieve;
    private AudioSource pasosBaldosa;
    private AudioSource controlAudio;

    //array que contenga todos los audioclips del juego
    [SerializeField] private protected AudioClip[] audios;
   
    void Start()
    {
        controlAudio = GetComponent<AudioSource>();
        pasosBaldosa = GetComponent<AudioSource>();
        pasosNieve = GetComponent<AudioSource>();
    }

    public void SeleccionAudio(int indice , float volumen)
    {
        //pone un audioClip con volumen determinado
        controlAudio.PlayOneShot(audios[indice], volumen);

    }
    

}
