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

    private int _numberObjectsInteractivesSeen = 0;

    //para que si es GameOver no puedas hacer pause
    [HideInInspector]
     public bool _endgame = false;

    private bool _myplayerAlive;
    //por defecto es falso
    [HideInInspector]
    public bool _pause = false;
    private int maxHealth = 100;
    //para saber si estamos en un nivel cronometrado
    [HideInInspector]
    public bool _nivelCronometrado = false;
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
    //private List<EnemyController2> _listOfEnemies2;
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
        //_listOfEnemies2 = new List<EnemyController2>();

    }

    public void SetTipsButtonGM(bool enabled)
    {
        //invocamos metodo de tips en 1 segundo
        _myUIManager.SetTipsButton(enabled);

    }
    //para pasar de nivel normal a nivel cronometrado
    public void SetNivelCronometrado(bool cronometro)
    {
        _nivelCronometrado = cronometro;
        //activamos GO timero no
        _myUIManager.SetTimer(cronometro);
    }

    //devueve informacion de si es o no nivel cronometrado
    public bool GetNivelCronometrado()
    {
        return _nivelCronometrado;
    }
    //devuelve estado de partida, si =true,sigue habiendo partida
    public bool EstadoPartida()
    {
        return _myplayerAlive;
    }

    //Cambia estado de partida
    public void cambiarEstadoPartida(bool newState)
    {
        _myplayerAlive = newState;
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
    //public void RegisterEnemyLevel1(EnemyController enemyToAdd)
    //{
    //    //añadir un enemigo a la lista
    //    _listOfEnemies.Add(enemyToAdd);
    //}

    //añade 1 enemigo a la lista
    public void AddEnemy(EnemyController enemyToAdd)
    {
        //añadir un enemigo a la lista
        _listOfEnemies.Add(enemyToAdd);
        //Debug.Log(_listOfEnemies.Count);
    }

    //devuelve numero de enemigos por zona
    public int NumeroEnemigosZona()
    {

        return _listOfEnemies.Count;
    }

    //public void RegisterEnemyLevel2(EnemyController2 enemyToAdd2)
    //{
    //    //añadir un enemigo a la lista
    //    _listOfEnemies2.Add(enemyToAdd2);
    //}
    /// <summary>
    /// Public method to manage enemies death level 1.
    /// </summary>
    /// <param name="deadEnemy"></param>
    public void OnEnemyDies(EnemyController deadEnemy)
    {
        //TODO
        //quitar un enemigo a la lista, empieza en 0
        _listOfEnemies.Remove(deadEnemy);
        //actualizas el numero de enemigos restantes
        _myUIManager.UpdateEnemiesLeft(_listOfEnemies.Count);
    }
    /// <summary>
    /// Public method to manage enemies death level 1.
    /// </summary>
    /// <param name="deadEnemy"></param>
    //public void OnEnemyDies2(EnemyController2 deadEnemy2)
    //{
    //    //TODO
    //    //quitar un enemigo a la lista dfel nivel 2
    //    _listOfEnemies2.Remove(deadEnemy2);
    //    //actualizas el numero de enemigos restantes del nivel 2
    //    _myUIManager.UpdateEnemiesLeft(_listOfEnemies2.Count);
    //}
    public void SETPLAYER(GameObject _myplayer)
    {
        _player = _myplayer;
    }
    static public GameManager GetInstance()
    {
        return _instance;
    }
    
    //actualizas numero de enemigos al coger objeto que para el tiempo diciendo los enemios de la ruta libre 
    //public void NumEnemiesLevel2()
    //{
    //    _myUIManager.UpdateEnemiesLeft(_listOfEnemies2.Count);
    //}
   
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

    public void SetMisiones(bool enabled)
    {
        _myUIManager.SetConsejosButton(enabled);
        
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
        //desactivamos misiones de abajo
        _myUIManager.QuitarMisionesTemploLevel1();
        //activamos cursor
        _myCursor = true;
        //EndGame(true);
        //desactivamos todos los enemigos, van de 0 a .count-1
       for(int i= _listOfEnemies.Count-1; i > 0; i--)
       {
            //vamos haciendo remove de cada elemento de la lista i
            OnEnemyDies(_listOfEnemies[i]);
       }
        //paralizamos juego
        Time.timeScale = 0;
        //al perder inicializamos metodo SetGameOver
        _myUIManager.SetEnemiesLeft(false);
        _myUIManager.SetGameOver(true);
        _myUIManager.SetContinueButton(true);
        
    }

    public void ResetEnemies()
    {
        //desactivamos todos los enemigos, van de 0 a .count-1
        for (int i = _listOfEnemies.Count - 1; i > 0; i--)
        {
            //vamos haciendo remove de cada elemento de la lista i
            OnEnemyDies(_listOfEnemies[i]);
        }
    }
    /// <summary>
    /// Initializes match 
    /// Activates player and enemies and performs initialization stuff.
    /// </summary>
    public void StartMatch()
    {
        ////inicializas enemigos level 1
        //for (int i = 0; i < _listOfEnemies.Count; i++)
        //{
        //    //de la lista de enemigos podemos llamar a el metodo de el script EnemyController
        //    _listOfEnemies[i].StartEnemy();
        //}
        
        
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

    //si no quedan enemigos en level 1
    public void NivelTemploContrarrelojAcabado()
    {
        //quitamos EnemiesLeft de arriba por ahora
        _myUIManager.SetEnemiesLeft(false);
        
    }

    public void SetEnemiesLeft(bool enemiesLeftcanvas)
    {
        //activamos en canvas enemiesLeft
        _myUIManager.SetEnemiesLeft(enemiesLeftcanvas);
        //los actualizamos en pantalla
        _myUIManager.UpdateEnemiesLeft(_listOfEnemies.Count);
    }

    public void SetObjetosInteractivosLeft(bool enemiesLeftcanvas)
    {
        //desactivamos enemigos por si acaso 
        _myUIManager.SetEnemiesLeft(false);
        //activamos en canvas interactive objects
        _myUIManager.SetInteractiveObjects(enemiesLeftcanvas);
        //los actualizamos en pantalla
        _myUIManager.UpdateInteractiveObjectsLeft(_numberObjectsInteractivesSeen);
    }

    //añadir 1 objectInteractive
    public void AddObjectInteractive()
    {
        _numberObjectsInteractivesSeen += 1;
        Debug.Log(_numberObjectsInteractivesSeen);
        //_myUIManager.UpdateInteractiveObjectsLeft(_numberObjectsInteractivesSeen);
    }

    public int GetObjectInteractive()
    {
        return _numberObjectsInteractivesSeen;
    }




    //quitar 1 objectInteractive
    public void QuitarObjectInteractive()
    {
        _numberObjectsInteractivesSeen -= 1;
        Debug.Log(_numberObjectsInteractivesSeen);
        _myUIManager.UpdateInteractiveObjectsLeft(_numberObjectsInteractivesSeen);
    }



    //siguiente Nivel
    public void SetNextLevel2()
    {
        //avisamos que te has pasado el nivel
        LogicaObjetivosTemplo.GetInstance().SetStateTemploCompleted(true);
        //quitamos mirilla
        _myUIManager.Mirilla(false);
        //activamos panel de te has pasado el nivel
        _myUIManager.SetNextLevel(true);
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

    public void DialogosNPCFueraTemplo(bool dialogos)
    {
        //quitar elementos sobrantes de la pantalla interfaz jugador,miniMapa,Mirilla
        _myUIManager.Mirilla(false);
        _myUIManager.MiniMapa(false);
        //el Presiona E para interactuar fuera
        _myUIManager.SetPresionaEparaInteractuar(false);
        //activar modoMenus
        _myCursor = true;
        //activarDialogos
        _myUIManager.SetDialogosNPCFueraTemplo(dialogos);
    }

    public void DialogosNPCPradera(bool dialogos)
    {
        //quitar elementos sobrantes de la pantalla interfaz jugador,miniMapa,Mirilla
        _myUIManager.Mirilla(false);
        _myUIManager.MiniMapa(false);
        //el Presiona E para interactuar fuera
        _myUIManager.SetPresionaEparaInteractuar(false);
        //activar modoMenus
        _myCursor = true;
        //activarDialogos
        _myUIManager.SetDialogosNPCPradera(dialogos);
    }

    public void DialogosNPCIsla(bool dialogos)
    {
        //quitar elementos sobrantes de la pantalla interfaz jugador,miniMapa,Mirilla
        _myUIManager.Mirilla(false);
        _myUIManager.MiniMapa(false);
        //el Presiona E para interactuar fuera
        _myUIManager.SetPresionaEparaInteractuar(false);
        //activar modoMenus
        _myCursor = true;
        //activarDialogos
        _myUIManager.SetDialogosNPCIsla(dialogos);
    }

    public void QuitarDialogosNPCFueraTemplo(bool dialogos)
    {
        //poner elementos sobrantes de la pantalla interfaz jugador,miniMapa,Mirilla
        _myUIManager.Mirilla(true);
        _myUIManager.MiniMapa(true);
        //el Presiona E para interactuar dentro
        _myUIManager.SetPresionaEparaInteractuar(true);
        //desactivar modoMenus
        _myCursor = false;
        //activarDialogos
        _myUIManager.SetDialogosNPCFueraTemplo(dialogos);


        //una vez que se ha interactuado con dron ponemos nueva mision
        LogicaObjetivosTemplo.GetInstance().SetNewMission("Continua por el desfiladero");
    }

    public void QuitarDialogosNPCPradera(bool dialogos)
    {
        //poner elementos sobrantes de la pantalla interfaz jugador,miniMapa,Mirilla
        _myUIManager.Mirilla(true);
        _myUIManager.MiniMapa(true);
        //el Presiona E para interactuar dentro
        _myUIManager.SetPresionaEparaInteractuar(true);
        //desactivar modoMenus
        _myCursor = false;
        //activarDialogos
        _myUIManager.SetDialogosNPCPradera(dialogos);


        //una vez que se ha interactuado con dron ponemos nueva mision
        LogicaObjetivosTemplo.GetInstance().SetNewMission("Avanza hasta 'Pueblo Hielo'");
    }

    public void QuitarDialogosNPCIsla(bool dialogos)
    {
        //poner elementos sobrantes de la pantalla interfaz jugador,miniMapa,Mirilla
        _myUIManager.Mirilla(true);
        _myUIManager.MiniMapa(true);
        //el Presiona E para interactuar dentro
        _myUIManager.SetPresionaEparaInteractuar(true);
        //desactivar modoMenus
        _myCursor = false;
        //activarDialogos
        _myUIManager.SetDialogosNPCIsla(dialogos);


        //una vez que se ha interactuado con dron ponemos nueva mision
        //LogicaObjetivosTemplo.GetInstance().SetNewMission("Avanza hasta 'Pueblo Hielo'");
    }


    /// <summary>
    /// Checks victory and defeat conditions, calling required methods.
    /// Updates time on UI Manager.
    /// </summary>
    void Update()
    {
        
       //comprobamos estado de partida,si es false , GameOver
        if(!EstadoPartida()||_timeLeft<=0)
        {
            if(_myplayerAlive)
            {
                OnPlayerDefeat();
                _myplayerAlive = false;
            }
           
        }
        
        
        //si estamos en nivel cronometrado,ponemos timer y lo activamos del canvas
        if(GetNivelCronometrado())
        {
            
            TiempoNiveles();
        }
        //si no estamos en nivel cronometrado,ocultamos tiempo
        else
        {
            //ponemos el tiempo promedio del nivel y será estático
            _timeLeft = 60;
            // //actualizamos el tiempo y lo ponemos en pantalla
            _displayTimeLeft = (int)_timeLeft;
            //ocultamos este para que no se vea
            _myUIManager.OcultarTiempo(false);
            
        }

        

        //activamos cursor si es true, para Menus y poder usar el raton
        if (_myCursor)
        {PonerCursor(); }
        //desactivamos cursor si es false,si se desactiva se pone el juego y la camara
        else
        { QuitarCursor(); }
        




    }
}


