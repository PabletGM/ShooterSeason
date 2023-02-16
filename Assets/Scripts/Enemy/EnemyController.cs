using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Parameters
    /// <summary>
    /// Random Parameter to set the random initial impulse
    /// </summary>
    [SerializeField]
    private float _randomImpulse = 1;
    /// <summary>
    ///  Parameter to set the impulseUp
    /// </summary>
    //[SerializeField]
    //private float _randomImpulseUp = 2;

    [SerializeField]
    private protected float fuerzaEmpuje;

   
    #endregion
    #region references
    /// <summary>
    /// Reference to local RigidBody.
    /// </summary>
    private Rigidbody _myRigidBody;

    [SerializeField]
    private protected Transform _myApuntador;

    GameManager _myGameManager;

    private EventosDesfiladeroDrones eventosDesfiladero;
    private EventosZonaTemplo eventosZoneTemplo;

    #endregion
    #region methods

    /// <summary>
    /// Activates enemy and sets random initial velocity for RigidBody.
    /// </summary>
    public void StartEnemy()
    {
        //activa el enemigo.
        //this.gameObject.SetActive(true);
        //pone un impulso aleatorio y lo guarda en la variable impulse.
        float impulse = Random.Range(_randomImpulse, -_randomImpulse);
        //ponemos el componente usegravity del rigidbody a true por si acaso
        _myRigidBody.useGravity = true;
        Boost(impulse * 3);
    }
    /// <summary>
    ///Gives a boost to the gameobject when it collides 
    /// </summary>
    /// <param name="impulse">The impulse that will apply to enemy</param>
    public void Boost(float impulse)
    {
        //la direccion del knockback será la posicion de la pistola del jugador - posicion del enemigo
        Vector3 direccionKnockback = transform.position-_myApuntador.transform.position ;
        //el empuje va en direccion z del apuntador es decir para atras
        _myRigidBody.AddForce(direccionKnockback.normalized*fuerzaEmpuje, ForceMode.Impulse);
    }

    //pasa la instancia de EnemyController a EnemyZonaTemplo
    public void NewEnemyZonaTemplo()
    {
        eventosZoneTemplo.AñadirEnemigo(this);
    }

    //pasa la instancia de EnemyController a EventosDesfiladeroDrones
    public void NewEnemyZonaDesfiladero()
    {
        eventosDesfiladero.AñadirEnemigo(this);
    }
    #endregion


    /// <summary>
    /// Initialization includes:
    /// - Registration of Enemy on GameManager.
    /// - Random initial translation.
    /// - References initialization.
    /// - Stopping enemy.
    /// </summary>
    void Start()
    {
        _myGameManager = GameManager.GetInstance();
        //se busca GameObject con componente y se asocia
        eventosZoneTemplo = GameObject.Find("TemploTimer").GetComponent<EventosZonaTemplo>();
        //se busca GameObject con componente y se asocia
        eventosDesfiladero = GameObject.Find("DesfiladeroDrones").GetComponent<EventosDesfiladeroDrones>();
        //_myGameManager.RegisterEnemyLevel1(this);
        _myRigidBody = GetComponent<Rigidbody>();
    }

    //el elemento drag del rigidbody es la resistencia al aire

}
