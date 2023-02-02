using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Desired duration for match.
    /// </summary>
    [SerializeField]
    private float _matchDuration = 60.0f;
    
    //para que si es GameOver no puedas hacer pause
    [HideInInspector]
     public bool _endgame = false;

    private bool _myplayerAlive;
    //por defecto es falso
    [HideInInspector]
    public bool _pause = false;
    private int maxHealth = 100;
    //para saber si hemos acabado el nivel 1 o no
    [HideInInspector]
    public bool _myNivel1Acabado = false;
    //para saber si estamos en un nivel o de ruta para desconectar el tiempo, si es false , estamos en un nivel hay tiempo
    [HideInInspector]
    public bool _myModoRutaLibre = false;
    //por defecto a true porque en menus  iniciales debe estar puesto
    [HideInInspector]
     public bool _myCursor = true;
    #endregion
    #region references
    /// <summary>
    /// Unique GameManager instance (Singleton Pattern).
    /// </summary>
    static private GameManager _instance;
    /// <summary>
    /// Public accesor for GameManager instance.
    /// </summary>
   
    /// <summary>
    /// Reference to UI Manager.
    /// </summary>
    private UI_Manager _myUIManager;
    private FPSMove _myFPSMove;

    private SoundManager soundManager;


    /// <summary>
    /// Reference to player.
    /// </summary>
    private GameObject _player;
    #endregion
    #region properties
    /// <summary>
    /// List containing all live enemies of first level
    /// </summary>
    private List<EnemyController> _listOfEnemies;
    
    /// <summary>
    /// List containing all live enemies of second level
    /// </summary>
    private List<EnemyController2> _listOfEnemies2;
    /// <summary>
    /// Remaining time to finish match.
    /// </summary>
    private float _timeLeft;
    /// <summary>
    /// Integer version of remaining time to finish match, dispayed on UI.
    /// </summary>
    private int _displayTimeLeft;
    #endregion
    #region methods
    /// <summary>
    /// Initializes GameManager instance and list of enemies.
    /// </summary>
    
    private void Awake()
    {
        //sonido, busca objeto de tipo sonido
        soundManager = FindObjectOfType<SoundManager>();
        //si la instancia no existe se hace este script la instancia
        if (_instance==null)
        {
            _instance = this;
        }
        //si la instancia existe , destruimos la copia
        else
        {
            Destroy(this.gameObject);
        }

        //iniciamos la lista
        _listOfEnemies = new List<EnemyController>();
        _listOfEnemies2 = new List<EnemyController2>();

    }
    public void PonerCursor()
    {
        //asi no aplicamos el bloqueo al cursor
       
        Cursor.lockState = CursorLockMode.None;

    }
    public void QuitarCursor()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
    }
    /// <summary>
    /// Public method for enemies to register on Game Manager.
    /// </summary>
    /// <param name="enemyToAdd"></param>
    public void RegisterEnemyLevel1(EnemyController enemyToAdd)
    {
        //añadir un enemigo a la lista
        _listOfEnemies.Add(enemyToAdd);
    }
    public void RegisterEnemyLevel2(EnemyController2 enemyToAdd2)
    {
        //añadir un enemigo a la lista
        _listOfEnemies2.Add(enemyToAdd2);
    }
    /// <summary>
    /// Public method to manage enemies death level 1.
    /// </summary>
    /// <param name="deadEnemy"></param>
    public void OnEnemyDies(EnemyController deadEnemy)
    {
        //TODO
        //quitar un enemigo a la lista
        _listOfEnemies.Remove(deadEnemy);
        //actualizas el numero de enemigos restantes
        _myUIManager.UpdateEnemiesLeft(_listOfEnemies.Count);
    }
    /// <summary>
    /// Public method to manage enemies death level 1.
    /// </summary>
    /// <param name="deadEnemy"></param>
    public void OnEnemyDies2(EnemyController2 deadEnemy2)
    {
        //TODO
        //quitar un enemigo a la lista dfel nivel 2
        _listOfEnemies2.Remove(deadEnemy2);
        //actualizas el numero de enemigos restantes del nivel 2
        _myUIManager.UpdateEnemiesLeft(_listOfEnemies2.Count);
    }
    public void SETPLAYER(GameObject _myplayer)
    {
        _player = _myplayer;
    }
    static public GameManager GetInstance()
    {
        return _instance;
    }
    
    //actualizas numero de enemigos al coger objeto que para el tiempo diciendo los enemios de la ruta libre 
    public void NumEnemiesLevel2()
    {
        _myUIManager.UpdateEnemiesLeft(_listOfEnemies2.Count);
    }
   
    /// <summary>
    /// Public method to manage player being hurted.
    /// </summary>
    /// <param name="lifePoints"></param>
    public void OnPlayerDamage(int lifePoints)
    {
        //comunicamos vidas del jugador restantes 
        //_myUIManager.UpdatePlayerLife(lifePoints);
        _myUIManager.ActualizarVidaJugador(lifePoints);
    }
    public void SETUIManager(UI_Manager uim)
    {
        _myUIManager = uim;
    }
    public void ChangePauseMode()
    {
        _pause = !_pause;
    }
    
    //desactiva jugador y enemigos y haces pause mientras la partida no haya acabado
    public void Pause()
    {
        //suena sonido de pausa
        soundManager.SeleccionAudio(3, 1f);
        if(!_endgame)
        {
            //ahora queda activar el propio menú
            _myUIManager.SetPause(_pause);
            //si se activa el modo pausa se quita la mirilla
            _myUIManager.Mirilla(!_pause);

            //si está modo pausa activado paralizamos juego
            if (_pause) { Time.timeScale = 0; }
            else { Time.timeScale = 1; }

            //cambiamos el booleano _pause a el valor contrario , si se activa Pausa , se desactivan enemigos
            ChangePauseMode();

            //desactivamos o activamos enemigos
            for (int i = 0; i < _listOfEnemies.Count; i++)
            {
                //aplicamos el desactivar al enemigo para ver si su script EnemyController y su GO existe
                if (_listOfEnemies[i] != null && _listOfEnemies[i].gameObject != null)
                {
                    _listOfEnemies[i].gameObject.SetActive(_pause);
                }

            }

            //si está modo pausa esto se deactiva el script , si no está pues viceversa
            if (!_pause)
            {
                this.enabled = _pause;
            }
            else
            {
                this.enabled = _pause;
            }

            
        }
       

    }
    /// <summary>
    /// Called on player's victory.
    /// Sets UI Manager accordingly and deactivates player.
    /// </summary>
    private void OnPlayerVictory()
    {
        //activamos cursor
       _myCursor=true;
        EndGame(true);
        //paralizamos juego
        Time.timeScale = 0;
        //pone panel de victoria activado
        _myUIManager.SetPlayerVictory(true);
        _myUIManager.SetContinueButton(true);
        //desactivas el GameManager
        this.enabled = false;
    }

    
    public void AumentoTiempo(float extraTime)
    {
        //le sumamos la cantidad de tiempo a la variable de tiempo
        _timeLeft += extraTime;
        //le actualizamos el tiempo en el UIManager
        _myUIManager.UpdateTime((int)_timeLeft);
    }
    /// <summary>
    /// Called on player's defeat.
    /// Set UI Manager accordingly, deactivates enemies and player.
    /// </summary>
    public void EndGame(bool enabled)
    {
        _endgame = enabled;
 
    }

    public void OnPlayerDefeat()
    {
        //activamos cursor
        _myCursor = true;
        //EndGame(true);
        //desactivamos todos los enemigos
       for(int i=0; i <_listOfEnemies.Count; i++)
       {
            //vamos haciendo remove de cada elemento de la lista i
            OnEnemyDies(_listOfEnemies[i]);
       }
        //paralizamos juego
        Time.timeScale = 0;
        //al perder inicializamos metodo SetGameOver
        _myUIManager.SetGameOver(true);
        _myUIManager.SetContinueButton(true);
        
    }
    /// <summary>
    /// Initializes match 
    /// Activates player and enemies and performs initialization stuff.
    /// </summary>
    public void StartMatch()
    {
        //inicializas enemigos level 1
        for (int i = 0; i < _listOfEnemies.Count; i++)
        {
            //de la lista de enemigos podemos llamar a el metodo de el script EnemyController
            _listOfEnemies[i].StartEnemy();
        }
        //inicializas enemigos level2
        for (int i = 0; i < _listOfEnemies2.Count; i++)
        {
            //de la lista de enemigos podemos llamar a el metodo de el script EnemyController
            _listOfEnemies2[i].StartEnemy();
        }
        
        //inicializas las variables tiempo de partida , vidas de jugador y enemigos restantes
        _myUIManager.VidaMaximaJugador(maxHealth);
        _myUIManager.UpdateEnemiesLeft(_listOfEnemies.Count);

        //quitamos cursor
        _myCursor = false;

    }
   
   
    //llamamos al tiempo niveles cuando estamos en un nivel
    public void TiempoNiveles()
    {
        //en cada frame se le resta 1 a el tiempo
        _timeLeft -= Time.deltaTime;
        _displayTimeLeft = (int)_timeLeft;
        _myUIManager.UpdateTime(_displayTimeLeft);
    }
    
    #endregion
    /// <summary>
    /// Finds UI Manager and Player.
    /// Deactivates player and GameManager.
    /// </summary>
    void Start()
    {
         _timeLeft = _matchDuration;
        _myplayerAlive = true;
        _myFPSMove = GetComponent<FPSMove>();

    }
    /// <summary>
    /// Checks victory and defeat conditions, calling required methods.
    /// Updates time on UI Manager.
    /// </summary>
    void Update()
    {
        
        //si no quedan enemigos  y _myNivel1Acabado==false(por defecto) en el primer nivel te lo has pasado 
       if(_listOfEnemies.Count<=0 )
       {
            
            //OnPlayerVictory();


            //activamos panel paso de nivel si hemos acabado el nivel
            if (_myNivel1Acabado) { _myUIManager.SetNextLevel(true); }
            
            
       }
       //sino queda tiempo o jugador muerto has perdido
        if(_timeLeft<=0 ||!_myplayerAlive )
        {
            OnPlayerDefeat();
        }
        
        
        //llamamos a este si estamos en un nivel
        if(!_myModoRutaLibre)
        {
            TiempoNiveles();
        }
        //si _myModoRutaLibre = true el tiempo es infinito
        else
        {
            //ponemos el tiempo promedio del nivel y será estático
            _timeLeft = 60;
            // //actualizamos el tiempo y lo ponemos en pantalla
            _displayTimeLeft = (int)_timeLeft;
            //ocultamo este para que no se vea
            _myUIManager.OcultarTiempo(false);
            
        }

        

        //activamos cursor si es true
        if (_myCursor)
        {PonerCursor(); }
        //desactivamos cursor si es false
        else
        { QuitarCursor(); }
        




    }
}


