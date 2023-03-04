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
        //activamos modo Menus
        ModoMenus();
    }

    //hace ruido de click
    public void clickNoise()
    {
        soundManager.SeleccionAudio(1, 1f);
    }

    public void HelicopterNoise()
    {
        soundManager.SeleccionAudio(3, 1f);
    }

    public void ExplosionNoise()
    {
        soundManager.SeleccionAudio(2, 1f);
    }

    public void ModoMenus()
    {
        Cursor.lockState = CursorLockMode.None;
    }





}
