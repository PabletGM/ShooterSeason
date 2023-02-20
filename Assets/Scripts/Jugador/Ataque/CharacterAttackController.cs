using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Force applied to enemy when shot impacts
    /// </summary>
    [SerializeField]
    private protected float _impactForce = 100.0f;
    /// <summary>
    /// efecto de particula de bala al disparar
    /// </summary>
    public ParticleSystem disparo_bala;
    /// <summary>
    /// efecto de particula de bala al disparar flash
    /// </summary>
    public ParticleSystem disparoArmaFlash;
    /// <summary>
    /// velocidad disparo
    /// </summary>
    [SerializeField]
    private protected float _velocidadDisparo;
    #endregion
    #region references
    /// <summary>
    /// Reference to self Transform
    /// </summary>
    private Transform _myTransform;
   
    /// <summary>
    /// Reference to object that will act as source of the shots
    /// </summary>
    [SerializeField]
    private protected GameObject _shotOriginObject;
    /// <summary>
    /// Reference to the transform of the object that will act as source of the shots
    /// </summary>
    private Transform _shotOriginTransform;
    
    [SerializeField]
    private protected Transform apuntador;

    [SerializeField]
    public Rigidbody bala;
    #endregion
    #region properties
    /// <summary>
    /// LayerMask used for enemies detection.
    /// </summary>
    private LayerMask _myLayerMask;
    #endregion
    #region methods
    /// <summary>
    /// Tries to shot a target from origin point. Causes damage and applies force to target if successful.

    /// </summary>
    /// <param name="originPoint">Shoot origin point</param>
    /// <param name="targetPoint">Shoot target point</param>
    public void Shoot(Vector3 targetPoint)
    {
       
        //ejecutamos particulas
        disparoArmaFlash.Play();
        disparo_bala.Play();
        //creamos la bala y la instanciamos en una posicion
        Rigidbody balaInstancia = Instantiate(bala, apuntador.position, Quaternion.identity);
        //le añadimos una fuerza a la bala instanciada en una direccion
        balaInstancia.AddForce(apuntador.forward * _velocidadDisparo, ForceMode.Impulse);

        //el Raycast se compone de un origen , una direccion , un hit , una distancia y un layermask
        RaycastHit hit;
        
        //si detecta algo
        if (Physics.Raycast(_shotOriginTransform.position , _shotOriginTransform.forward , out hit , 1000))
        {
            //de a lo que dé de decimos su nombre
            //Debug.Log(hit.transform.name);
            //produce daño si es un enemigo bola
            if (hit.collider.GetComponent<EnemyLifeComponent>())
            {
                //efectos a enemigos bolas
                hit.collider.GetComponent<EnemyLifeComponent>().EfectoPelota();
                //hit.collider.GetComponent<EnemyLifeComponent>().Damage();
                //hit.collider.GetComponent<EnemyController>().Boost(_impactForce);
            }
            //si es un dron
            if ( hit.collider.GetComponent<EnemyLifeComponentDron>())
            {
                //efectos a drones
                hit.collider.GetComponent<EnemyLifeComponentDron>().EfectoDron();
            }

            //si es una torreta
            if (hit.collider.GetComponent<EnemyLifeTorreta>())
            {
                //efectos a torreta
                hit.collider.GetComponent<EnemyLifeTorreta>().EfectoTorreta();
            }

        }
        
    }
   


    #endregion
    /// <summary>
    /// LayerMask and Camera initialization
    /// </summary>
    void Start()
    {
        
        //decimos cual es el layer que nos interesa que detecte 
        _myLayerMask = LayerMask.GetMask("Enemy");
        //decimos cual es el origen del tiro , que será la posicion de la camara en este caso.
        _shotOriginTransform = _shotOriginObject.transform;
        //el transform del propio GO
        _myTransform = transform;
    }
}


