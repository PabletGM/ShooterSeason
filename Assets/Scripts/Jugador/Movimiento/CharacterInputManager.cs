using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputManager : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Maximum distance for shots to reach target
    /// </summary>
    [SerializeField]
    private float _shotDistance;

    #endregion
    #region references
    private CharacterController _myCharacterController;
    private CameraBobbing _myCameraBobbing;

    private Apuntar _myApuntar;
    /// <summary>
    /// Reference to local component CharacterMovementManager
    /// </summary>
    private CharacterMovementManager _myCharacterMovementManager;
    /// <summary>
    /// Reference to local component CharacterAttackController
    /// </summary>
    private CharacterAttackController _myCharacterAttackController;
    /// <summary>
    /// Reference to Game Camera
    /// </summary>
    private Camera _myCamera;
    //GameManager
    GameManager _myGameManager;
    
    #endregion
    #region properties
    /// <summary>
    /// Stores horizontal input
    /// </summary>
    private float _horizontalInput;
    /// <summary>
    /// Stores vertical input
    /// </summary>
    private float _verticalInput;
    /// <summary>
    /// Stores mouse input
    /// </summary>
    private protected float _mouseInput;

    private SoundManager soundManager;

    //pasos jugador
    [SerializeField]
    private protected AudioSource pasos;
    
    private bool pasosHorizontalActivo;

    private bool pasosVerticalActivo;
    #endregion
    #region methods
    /// <summary>
    /// Returns the world point corresponding to desired screen point at
    /// </summary>
    /// <param name="screenPoint"></param>
    /// <returns></returns>
    private Vector3 GetWorldPoint(Vector2 screenPoint, float distanceFromCamera)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, distanceFromCamera));
    }
    #endregion
    /// <summary>
    /// Initializes references
    /// </summary>
    void Start()
    {
        _myCharacterController = GetComponentInParent<CharacterController>();
        _myCameraBobbing = gameObject.GetComponentInChildren<CameraBobbing>();
        _myApuntar = gameObject.GetComponentInChildren<Apuntar>();
        _myCharacterMovementManager = GetComponent<CharacterMovementManager>();
        _myCharacterAttackController = GetComponent<CharacterAttackController>();
        _myGameManager = GameManager.GetInstance();
        _myCamera = GetComponent<Camera>();

        
    }

    void Awake()
    {
        //sonido, busca objeto de tipo sonido
        soundManager = FindObjectOfType<SoundManager>();
        
    }

    
    

    
    /// <summary>
    /// Get input and calls required methods
    /// from components CharacterMovementManager and CharacterAttackController
    /// </summary>
    void Update()
    {
        //asociamos inputs por defecto
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");


        //apuntar al pulsar click derecho
        if(Input.GetMouseButton(1))
        {
            _myApuntar.Apuntado();
        }
        //sino se pulsa no se hace mira
        else
        {
            _myApuntar.DesApuntado();
        }

       
        //disparo del personaje
        if (Input.GetMouseButtonDown(0))
        {
            _myCharacterAttackController.Shoot(GetWorldPoint(Input.mousePosition, 100f));
            soundManager.SeleccionAudio(1, 1f);
        }


        //menu de Pausa activado
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _myGameManager.Pause();
        }
       


        //pulsar el espacio
        if (Input.GetButtonDown("Jump"))
        {
             _myCharacterMovementManager.JumpRequest();
        }
        //sino se salta se palica gravedad
        else
        {
            _myCharacterMovementManager.SetGravity();
        }


        //vemos si está pulsado vertical  o horizontal>0 esto es pulsar w y  e para esprintar y llamar a metodo que cambie velocidad en CharacterMovementManager, para dejar la tecl pulsada es input.GetKey
        if (_verticalInput>0 && Input.GetKey(KeyCode.LeftShift) || _horizontalInput> 0 && Input.GetKey(KeyCode.LeftShift))
        {
            //ponemos el cameraBobbing de correr
            _myCameraBobbing.SetAmplitude(0.3);
            //llamamos a metodo pasando bool sprint
            _myCharacterMovementManager.SetSprintVelocity();
            //vemos en que material está
        }
        else
        {
            //ponemos el cameraBobbing de andar
            _myCameraBobbing.SetAmplitude(0.1);
            //andamos
            _myCharacterMovementManager.SetWalkVelocity();
        }

        //direccion y rotacion si hay movimiento
        if(_horizontalInput!=0 || _verticalInput!=0)
        {
            
            //movimiento y rotacion
            _myCharacterMovementManager.SetMovementDirection(_horizontalInput, _verticalInput);
            _myCharacterMovementManager.SetMovementRotation(_mouseInput);
        }


        //sonidos pasos

        //si jugador pulsa A, D
        if(Input.GetButtonDown("Horizontal"))
        {
            if (!pasosVerticalActivo)
            {
                pasosHorizontalActivo = true;
                pasos.Play();

                //activamos movimiento camara y estamos andando si estamos en el suelo y nos movemos
                if (_myCharacterController.isGrounded && _myCharacterMovementManager.PosibleMovimientoJugador())
                {
                    _myCameraBobbing.isWalking = true;
                }
                else
                { _myCameraBobbing.isWalking = false; }
            }
            
        }
        //si jugador pulsa W,S
        if (Input.GetButtonDown("Vertical"))
        {
            if(!pasosHorizontalActivo)
            {
                pasosVerticalActivo = true;
                pasos.Play();

                //activamos movimiento camara y estamos andando si estamos en el suelo y nos movemos
                if (_myCharacterController.isGrounded && _myCharacterMovementManager.PosibleMovimientoJugador())
                {
                    _myCameraBobbing.isWalking = true;
                }
                else
                { _myCameraBobbing.isWalking = false; }
            }
            
        }


        //si jugador suelta A, D
        if (Input.GetButtonUp("Horizontal"))
        {
            pasosHorizontalActivo = false;

            if(!pasosVerticalActivo)
            {
                pasos.Pause();
                //no nos movemos
                 _myCameraBobbing.isWalking = false; 
            }
           
        }
        //si jugador suelta W,S
        if (Input.GetButtonUp("Vertical"))
        {
            pasosVerticalActivo = false;

            if (!pasosHorizontalActivo)
            {
                pasos.Pause();
                //no nos movemos
                _myCameraBobbing.isWalking = false; 
            }

            
        }

       



        //if (_myCharacterController.isGrounded && Input.GetButtonDown("Vertical") || _myCharacterController.isGrounded && Input.GetButtonDown("Horizontal"))
        //{ 

        //}
        //else
        //{
        //    _myCameraBobbing.isWalking = false;
        //}


    }
    
}

