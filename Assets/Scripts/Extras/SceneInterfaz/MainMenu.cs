using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region references
    [SerializeField]
    private protected GameObject ControlsPanel;

    [SerializeField]
    private protected GameObject _BackButton;

    [SerializeField]
    private protected GameObject _MainMenuPanel;

    private  protected SoundManager soundManager;
    #endregion 
    //carga la escena principal
    public void MainMenuPlay()
    {
        //se pasa a la siguiente escena por orden
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadScene("Introduccion");
        //activa sonido
        //soundManager.SeleccionAudio(0, 1f);
    }

    void Awake()
    {
        //sonido, busca objeto de tipo sonido
        //soundManager = FindObjectOfType<SoundManager>();
    }

    //carga los controles
    public void Controls()
    {
        //desactiva menu de inicio
        _MainMenuPanel.SetActive(false);
        //activa menú de controles
        ControlsPanel.SetActive(true);
        //activa sonido
        soundManager.SeleccionAudio(1, 1f);
    }

    //carga el main menú de nuevo
    public void ControlsMainMenuBack()
    {
        //desactiva menú de controles
        ControlsPanel.SetActive(false);
        //activa menu de inicio
        _MainMenuPanel.SetActive(true);
        //activa sonido
        soundManager.SeleccionAudio(1, 1f);
        
    }

    //por defecto activamos panel mainMenu
    private void Start()
    {
        _MainMenuPanel.SetActive(true);
    }



}
