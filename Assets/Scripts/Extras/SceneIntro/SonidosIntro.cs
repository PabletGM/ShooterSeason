using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosIntro : MonoBehaviour
{
    #region references
    private protected SoundManager soundManager;
    #endregion
    
    //asocia soundManager
    void Awake()
    {
        //sonido, busca objeto de tipo sonido
        soundManager = FindObjectOfType<SoundManager>();
    }

    //hace ruido de click
    public void clickNoise()
    {
        soundManager.SeleccionAudio(1, 1f);
    }

   

  

}
