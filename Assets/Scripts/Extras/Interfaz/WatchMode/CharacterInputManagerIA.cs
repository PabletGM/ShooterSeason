using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputManagerIA : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Maximum distance for shots to reach target
    /// </summary>
    [SerializeField]
    private float _shotDistance;

    [SerializeField]
    private float _tiempoParametrizado = 3f;
    #endregion
    #region references
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
    private float _mouseInput;
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
        _myApuntar = gameObject.GetComponentInChildren<Apuntar>();
        _myCharacterMovementManager = GetComponent<CharacterMovementManager>();
        _myCharacterAttackController = GetComponent<CharacterAttackController>();
        _myGameManager = GameManager.GetInstance();
        _myCamera = GetComponent<Camera>();
    }
    /// <summary>
    /// Get input and calls required methods
    /// from components CharacterMovementManager and CharacterAttackController
    /// </summary>
    void Update()
    {
        //apuntado de IA debe ser aleatorio y espacio tambien
       

       
        //disparo del personaje ahora es si se detecta un enemigo en la zona
        
        //menu de Pausa
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
        if (_verticalInput > 0 && Input.GetKey(KeyCode.E) || _horizontalInput > 0 && Input.GetKey(KeyCode.E))
        {
            //llamamos a metodo pasando bool sprint
            _myCharacterMovementManager.SetSprintVelocity();
        }
        else
        {
            _myCharacterMovementManager.SetWalkVelocity();
        }


        if (_tiempoParametrizado<=0)
        {
            //elegimos inputs aleatorios 
            _horizontalInput = Random.Range(-1, 2);
            _verticalInput = Random.Range(-1, 2);
            _mouseInput = Random.Range(-1, 2);
            //ponemos direccion y rotacion aleatorias
            _myCharacterMovementManager.SetMovementDirection(_horizontalInput, _verticalInput);
            _myCharacterMovementManager.SetMovementRotation(_mouseInput);
            //reiniciamos contador 
            _tiempoParametrizado = 3f;
            //ponemos valor de horizontal , vertical y mouse
            Debug.Log("Horizontal: " + _horizontalInput + "   Vertical: " + _verticalInput + "   Rotacion: " + _mouseInput);
        }
        _tiempoParametrizado -= Time.deltaTime;

    }
}