using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_AttackController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Force applied to enemy when shot impacts
    /// </summary>
    [SerializeField]
    private float _impactForce = 100.0f;
    public ParticleSystem disparo_bala;
    public ParticleSystem disparoArmaFlash;

    [SerializeField]
    private float _velocidadDisparo;
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
    private protected  GameObject _shotOriginObject;
    /// <summary>
    /// Reference to the transform of the object that will act as source of the shots
    /// </summary>
    private Transform _shotOriginTransform;

    [SerializeField]
    private Transform apuntador;

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

        RaycastHit hit;

        if (Physics.Raycast(_shotOriginTransform.position, (targetPoint - _shotOriginTransform.position).normalized, out hit, 300))
        {
            //de a lo que dé de decimos su nombre
            Debug.Log(hit.transform.name);
            //produce daño si es un enemigo bola
            if (hit.collider.GetComponent<EnemyLifeComponent>())
            {
                //efectos a enemigos bolas
                hit.collider.GetComponent<EnemyLifeComponent>().Damage();
                hit.collider.GetComponent<EnemyController>().Boost(_impactForce);
            }
            //si es un dron
            if (hit.collider.GetComponent<EnemyLifeComponentDron>())
            {
                //efectos a drones
                hit.collider.GetComponent<EnemyLifeComponentDron>().Damage();
                hit.collider.GetComponent<EnemyController>().Boost(_impactForce);
            }
        }
        else Debug.Log("FALLO: NO IMPACTO");
        

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
