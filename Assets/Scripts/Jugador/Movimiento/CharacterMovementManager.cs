using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementManager : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Character movement speed
    /// </summary>
    
   
    private float _speed;

    [SerializeField]
    private  protected float _myWalkSpeed;

    [SerializeField]
    private protected  float _mySprintSpeed;
    /// <summary>
    /// Character vertical jump speed
    /// </summary>
    [SerializeField]
    private float _jumpSpeed = 1.0f;
    /// <summary>
    /// Gravity value applied to player
    /// </summary>
    [SerializeField]
    private float _gravity = 1.0f;
    /// <summary>
    /// Maximum falling speed
    /// </summary>
    [SerializeField]
    private float _fallSpeed = 1.0f;
    /// <summary>
    /// Speed for rotation
    /// </summary>
    [SerializeField]
    private float _rotationSpeed = 1.0f;

   
    #endregion
    #region references
    /// <summary>
    /// Reference to local transform component
    /// </summary>
    private Transform _myTransform;
    /// <summary>
    /// Reference to local CharacterController component
    /// </summary>
    private CharacterController _myCharacterController;
    #endregion
    #region properties
    /// <summary>
    /// Stores desired movement direction
    /// </summary>
    private Vector3 _movementDirection;
    /// <summary>
    /// Stores desired rotation factor, determined by CharacterInputManager
    /// </summary>
    private float _rotationFactor;
    /// <summary>
    /// Stores current vertical speed value
    /// </summary>
    private float _verticalSpeed;
    #endregion
    #region methodws
    /// <summary>
    /// Sets desired direction for player.
    /// </summary>
    /// <param name="horizontal">Right component for desired direction</param>
    /// <param name="vertical">Forward component for desired direction</param>
    public void SetMovementDirection(float horizontal, float vertical)
    {
         _movementDirection = (horizontal * _myTransform.right ) + (vertical * _myTransform.forward );
        _movementDirection.y = _verticalSpeed;
    }
    /// <summary>
    /// Sets desired rotation for the player
    /// </summary>
    /// <param name="rotation">Desired rotation</param>
    public void SetMovementRotation(float rotation)
    {
        _rotationFactor = rotation*_rotationSpeed;
    }
    public bool PosibleMovimientoJugador()
    {
        //si hay movimiento
        if(_movementDirection * _speed * Time.deltaTime!=Vector3.zero)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Sets _verticalSpeed to _jumpSpeed,
    /// only if Character is grounded.
    /// </summary>
    public void JumpRequest()
    {
        //si esta en el suelo pues cambiamos su verticalSpeed por JumpSpeed
       if(_myCharacterController.isGrounded)
       {
            _verticalSpeed= _jumpSpeed;

       }
       //sino esta en el suelo le ponemos la velocidad de caida
       else
       {
           _verticalSpeed  -= _fallSpeed;
            
       }
       
    }
    public void SetGravity()
    {
        _verticalSpeed -= _gravity * Time.deltaTime;
    }
    //cambia la velocidad a sprint
    public void SetSprintVelocity()
    {
        _speed = _mySprintSpeed;
    }
    //cambia la velocidad a walk
    public void SetWalkVelocity()
    {
        _speed = _myWalkSpeed;
    }
    #endregion
    /// <summary>
    /// Initializes references to local components
    /// </summary>
    void Start()
    {
        _myTransform = transform;
        _myCharacterController = GetComponent<CharacterController>();
       
    }
    /// <summary>
    /// Manages player movement, including translation and gravity
    /// </summary>
    void Update()
    {
        //direccion *velocidad(segun si es sprint o no) 
        _myCharacterController.Move(_movementDirection*_speed*Time.deltaTime);
        //solo rotas en la Y , ahi se guarda la direccion y velocidad de rotacion en el eje Y
        _myTransform.Rotate(0,_rotationFactor,0);
    }

}
