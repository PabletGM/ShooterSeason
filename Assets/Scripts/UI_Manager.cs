using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    #region references

    

    public GameObject healthbar;
    
    GameManager _myGameManager;

    private PowerUpManager _mypowerUpManager;

    /// <summary>
    /// Reference to object containing Text Component to display number of live enemies.
    /// </summary>
    [SerializeField]
    private protected GameObject _enemiesLeftObjectNumber;

    [SerializeField]
    private protected GameObject _interactiveObjects;

    [SerializeField]
    private protected GameObject _playerAmetralladora;

    /// <summary>
    /// Text Component to display number of live enemies.
    /// </summary>
    private Text _enemiesLeftText;

    private Text _interactiveObjectsText;
    /// <summary>
    /// Reference to object containing Text Component to display remaining match time.
    /// </summary>
    

    [SerializeField]
    private protected GameObject _mainMenu;

    [SerializeField]
    private protected GameObject _timeDisplayObject;
    /// <summary>
    /// Text Component to display remaining match time.
    /// </summary>
    private Text _timeDisplayText;
    /// <summary>
    /// Reference to object containint Text Component to display player's life points.
    /// </summary>
    [SerializeField]
    private protected GameObject _playerLifeObject;
    /// <summary>
    /// Text Component to display player's life points.
    /// </summary>
    private Text _playerLifeText;
    
    /// <summary>
    /// Reference to object containing Game Over objects
    /// </summary>
    [SerializeField]
    private  protected GameObject _gameOver;

    [SerializeField]
    private protected GameObject _NextLevelObject;

    [SerializeField]
    private protected GameObject _consejosGameObject;

    [SerializeField]
    private protected GameObject _TipsGO;

    [SerializeField]
    private protected GameObject _buttonQuit;

    [SerializeField]
    private protected GameObject _dialogosNPCFueraTemplo;

    [SerializeField]
    private protected GameObject _dialogosNPCPradera;

    [SerializeField]
    private protected GameObject _dialogosNPCIsla;

    [SerializeField]
    private protected GameObject _dialogos;
    /// <summary>
    /// Reference to object containing objects for Player's Victory
    /// </summary>
    [SerializeField]
    private protected GameObject _playerVictory;
    /// <summary>
    /// Reference to object containing Continue Button
    /// </summary>
    [SerializeField]
    private protected GameObject _continueButton;
    [SerializeField]
    public GameObject _pause;
    /// <summary>
    /// barra de vida Interfaz
    /// </summary>
    [SerializeField]
    private protected GameObject _barraVida;
    /// <summary>
    /// mirilla Interfaz
    /// </summary>
    [SerializeField]
    private protected GameObject _mirilla;

    /// <summary>
    /// minimapa
    /// </summary>
    [SerializeField]
    private protected GameObject _minimapa;
    /// <summary>
    /// enemiesLeft gameObject
    /// </summary>
    [SerializeField]
    private protected GameObject _enemiesLeft;

    [SerializeField]
    private protected GameObject _interactiveObjectsLeftNumber;
    /// <summary>
    /// timeLeft
    /// </summary>
    [SerializeField]
    private protected GameObject _timeLeft;

    [SerializeField]
    private protected GameObject _InteractuarConE;
    #endregion



    #region methods
    /// <summary>
    /// Updates number of remaining enemies
    /// </summary>
    /// <param name="newEnemiesLeft"></param>
    public void UpdateEnemiesLeft(int newEnemiesLeft)
    {
        _enemiesLeftText.text = newEnemiesLeft.ToString();
    }

    public void UpdateInteractiveObjectsLeft(int newInteractiveObjectsLeft)
    {
        _interactiveObjectsText.text = newInteractiveObjectsLeft.ToString();
    }
    public void SetPause(bool pause)
    {
        _pause.SetActive(pause);
    }
    public void Mirilla(bool mirilla)
    {
        _mirilla.SetActive(mirilla);
    }

    public void MiniMapa(bool miniMapa)
    {
        _minimapa.SetActive(miniMapa);
    }
    /// <summary>
    /// Updates displayed remaining time.
    /// </summary>
    /// <param name="newTime">Current time to be displayed.</param>
    public void UpdateTime(int newTime)
    {
        _timeDisplayText.text = newTime.ToString();
    }

    //ocultamos todo el GameObject Tiempo  _timeLeft
    public void OcultarTiempo(bool active)
    {
        _timeLeft.SetActive(active);
    }
    /// <summary>
    /// Updates displayer player's life points.
    /// </summary>
    /// <param name="newLife">Current life points to be displayed.</param>
    public void UpdatePlayerLife(int newLife)
    {
        //la variable  GO asociada de tipo texto se asocia a el parametro pasado como variable
        _playerLifeText.text = newLife.ToString();
    }
    
    /// <summary>
    /// Allows to activate and deactivate Game Over menu.
    /// </summary>
    /// <param name="enabled">New active state for Game Over menu.</param>
    public void SetGameOver(bool enabled)
    {
        //activamos panel de GameOver
        _gameOver.SetActive(enabled);
        
    }

    public void SetConsejosButton(bool enabled)
    {
        _consejosGameObject.SetActive(enabled);
    }

    public void SetTipsButton(bool enabled)
    {
        //invocamos metodo de tips en 1 segundo
        _TipsGO.SetActive(enabled);

    }

   
    /// <summary>
    /// Allows to activate and deactivate Player's victory menu.
    /// </summary>
    /// <param name="enabled">New active state for Player's Victory menu.</param>
    public void SetPlayerVictory(bool enabled)
    {
        _playerVictory.SetActive(enabled);
    }
    
    /// <summary>
    /// Allows to activate or deactivate Continue button.
    /// </summary>
    /// <param name="enabled">New active state for Continue button.</param>
    public void SetContinueButton(bool enabled)
    {
        _continueButton.SetActive(enabled);
        //se activa el gamemanager porque se reinicia la partida
        this.enabled = true;
    }
    /// <summary>
    /// Calls Game Manager method to Quit Game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SetMainMenu(bool enabled)
    {
        _mainMenu.SetActive(enabled);
        //debemos hacer que se pueda utilizar el raton para seleccionar una opcion para esto 
    }
    /// <summary>
    /// Calls Game Manager method to Start Match.
    /// </summary>
    public void StartMatch()
    {
        //desactivamos todo menos el MainMenu
        SetMainMenu(true);
        SetContinueButton(false);
        SetGameOver(false);
        SetPlayerVictory(false);
    }

    public void SetEnemiesLeft(bool enabled)
    {
        _enemiesLeft.SetActive(enabled);
    }

    public void SetInteractiveObjects(bool enabled)
    {
        _interactiveObjectsLeftNumber.SetActive(enabled);
        _interactiveObjects.SetActive(enabled);
    }

    public void SetTimer(bool enabled)
    {
        _timeLeft.SetActive(enabled);
    }

    public void SetNextLevel(bool enabled)
    {
        //ponemos cursor
        _myGameManager._myCursor = true;
        //quitamos el panel o lo ponemos 
        _NextLevelObject.SetActive(enabled);
    }
    public void NextLevelContinue()
    {
        //quitamos cursor
        _myGameManager._myCursor = false;
        //ponemos mirilla
        Mirilla(true);
        ////quitamos el panel 
        _NextLevelObject.SetActive(false);

    }
    /// <summary>
    /// Calls Game Manager method to Continue to a new match.
    /// </summary>
    public void Continue()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Game");
        this.enabled = true;
        //ponemos el tiempo a 1
        Time.timeScale = 1;
        
    }

    public void SetPresionaEparaInteractuar(bool interactuar)
    {
        _InteractuarConE.SetActive(interactuar);
    }

    public void SetDialogosNPCFueraTemplo(bool dialogo)
    {
        //activamos dialogos en general
        _dialogos.SetActive(dialogo);
        //activamos dialogo del NPC en especifico
        _dialogosNPCFueraTemplo.SetActive(dialogo);
    }

    public void SetDialogosNPCPradera(bool dialogo)
    {
        //activamos dialogos en general
        _dialogos.SetActive(dialogo);
        //activamos dialogo del NPC en especifico
        _dialogosNPCPradera.SetActive(dialogo);
    }

    public void SetDialogosNPCIsla(bool dialogo)
    {
        //activamos dialogos en general
        _dialogos.SetActive(dialogo);
        //activamos dialogo del NPC en especifico
        _dialogosNPCIsla.SetActive(dialogo);
    }

    //se inicia el play
    public void Play()
    {
        //ACTIVAMOS SCRIPT GM y fpsMove
        _myGameManager.enabled=true;     
    }

    public void ActualizarVidaJugador(int health)
    {
        healthbar.GetComponent<HealthBar>().SetHealth(health);
    }

    public void VidaMaximaJugador(int maxhealth)
    {
        healthbar.GetComponent<HealthBar>().SetMaxHealth(maxhealth);
    }
    //se activa menú StartMatch
    public void MainMenu()
    {
        //comenzamos activando el Main Menu
        StartMatch();
        //ahora segun que boton se pulse se jugará PlayMode o WatchMode para esto activamos el puntero
        _myGameManager.EndGame(true);
    }
    //se elige en MainMenu el PlayMode , desactiva el MainMenu
    public void PlayMode()
    {
        //se desactiva MainMenu a false
        SetMainMenu(false);
        //se activa  interfaz inicio jugador
        InterfazInicioJugador(true);
        //inicio juego
        _myGameManager.EndGame(false);
        //activa Jugador que ya por defecto es true
        ActivarJugador(true);
        //empezamos la partida
        _myGameManager.StartMatch();
    }
    public void InterfazInicioJugador(bool enabled)
    {
        //activar /desactivar barra de vida player
        _barraVida.SetActive(enabled);
        //activamos mirilla
        _mirilla.SetActive(enabled);
        //activamos minimapa
        _minimapa.SetActive(enabled);
        //enemiesLeft
        _enemiesLeft.SetActive(enabled);
        //timeLeft
        //_timeLeft.SetActive(enabled);

        //consejos o misiones
        SetConsejosButton(true);

        //ponemos tips
        SetTipsButton(true);
    }

    //quitamos misiones al pulsar a Quit
    public void QuitarMisionesTemploLevel1()
    {
        //desactivamos misiones
        SetConsejosButton(false);
        //desactivamos boton quit
        SetButtonQuit(false);
        //cambiamos cursor para desactivar modo Menus
        _myGameManager._myCursor = false;
        //queremos tambien habilitar la zona de la escalera para que se pueda pasar al Level 2 y pasarse el timer
        _mypowerUpManager.HabilitarZonaEscaleraLevel1();


    }

    public void SetButtonQuit(bool enabled)
    {
        _buttonQuit.SetActive(enabled);
    }

    public void ActivarJugador(bool enabled)
    {
        _playerAmetralladora.SetActive(enabled);
    }
    /// <summary>
    /// Initializes own references.
    /// </summary>
    private void Awake()
    {
        //asociamos el componente texto creado en el script a el componente del GO _playerLifeObject
        _playerLifeText = _playerLifeObject.GetComponent<Text>();
        _timeDisplayText = _timeDisplayObject.GetComponent<Text>();
        _enemiesLeftText = _enemiesLeftObjectNumber.GetComponent<Text>();
        _interactiveObjectsText = _interactiveObjectsLeftNumber.GetComponent<Text>();

        //TODO
    }
    private void Start()
    {
        
        //asi es como asociamos el GameManager con el UI
        _myGameManager = GameManager.GetInstance();
        //inicializamos script
        _mypowerUpManager = PowerUpManager.GetInstance();
        //asi es como indicamos que el UI es este script
        _myGameManager.SETUIManager(this);
        //PARA QUE NO SE ACTIVE EL game manager hasta que le digas y asi se active en el metodo Play que se ejecuta despues de Start
        _myGameManager.enabled = true;
         //llamas al menu donde se elegirá el tipo de juego
         MainMenu();
        //_myGameManager.StartMatch();

    }
    #endregion

}
