using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    #region Parameters
    


    #endregion
    #region references
    /// <summary>
    /// Reference to local RigidBody.
    /// </summary>
    

    [SerializeField]
    private protected Transform _myApuntador;

    GameManager _myGameManager;

    #endregion
    #region methods
    /// <summary>
    /// Deactivate gravity on enemies.
    /// </summary>
    public void StopEnemy()
    {
        //TODO
    }
    /// <summary>
    /// Activates enemy and sets random initial velocity for RigidBody.
    /// </summary>
    public void StartEnemy()
    {
        //activa el enemigo.
        this.gameObject.SetActive(true);
        //pone un impulso aleatorio y lo guarda en la variable impulse.
        //float impulse = Random.Range(_randomImpulse, -_randomImpulse);
        //ponemos el componente usegravity del rigidbody a true por si acaso
        //_myRigidBody.useGravity = true;
        //Boost(impulse * 3);
    }
    /// <summary>
    ///Gives a boost to the gameobject when it collides 
    /// </summary>
    /// <param name="impulse">The impulse that will apply to enemy</param>
    public void Boost(float impulse)
    {
        //la direccion del knockback será la posicion de la pistola del jugador - posicion del enemigo
        Vector3 direccionKnockback = transform.position - _myApuntador.transform.position;
        //el empuje va en direccion z del apuntador es decir para atras
        //_myRigidBody.AddForce(direccionKnockback.normalized * fuerzaEmpuje, ForceMode.Impulse);
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

        //_myRigidBody = GetComponent<Rigidbody>();
        _myGameManager = GameManager.GetInstance();
        //_myGameManager.RegisterEnemyLevel2(this);
        this.gameObject.SetActive(false);


    }

    //el elemento drag del rigidbody es la resistencia al aire

}

