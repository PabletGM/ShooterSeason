using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Force applied to enemy when shot impacts
    /// </summary>
    [SerializeField]
    private protected float _impactForce = 100.0f;
   

    [SerializeField]
    private protected float _velocidadDisparo;

    [SerializeField]
    private float _myContadorDisparo = 1.5f;

    [SerializeField]
    private int numBalas=2;
    #endregion
    #region references
    /// <summary>
    /// Reference to self Transform
    /// </summary>
    private Transform _myTransform;

    [SerializeField]
    private Transform ametralladoraPlayer;

    private EnemyLifeComponentDron enemyLifeComponentDron;
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

    //aqui pones el sonido de disparo de la bala dron
    [SerializeField]
    private protected AudioClip disparoBala;
    #endregion
    #region properties

    #endregion
    #region methods
    /// <summary>
    /// Tries to shot a target from origin point. Causes damage and applies force to target if successful.

    /// </summary>
    /// <param name="originPoint">Shoot origin point</param>
    /// <param name="targetPoint">Shoot target point</param>
    //public void ShootEnemy()
    //{

    //    //el Raycast se compone de un origen , una direccion , un hit , una distancia y un layermask
    //    RaycastHit hit;

    //    //si detecta algo
    //    if (Physics.Raycast(_shotOriginTransform.position, _shotOriginTransform.forward, out hit, 100))
    //    {
    //        //de a lo que dé de decimos su nombre
    //        Debug.Log(hit.transform.name);
    //    }

    //    //creamos la bala y la instanciamos en una posicion
    //    Rigidbody balaInstancia = Instantiate(bala, apuntador.position, Quaternion.identity);
    //    //le añadimos una fuerza a la bala instanciada en una direccion
    //    balaInstancia.AddForce(apuntador.forward * _velocidadDisparo, ForceMode.Impulse);

    //}
    #endregion

    void Start()
    {
        enemyLifeComponentDron = this.gameObject.GetComponent<EnemyLifeComponentDron>();
        //decimos cual es el origen del tiro , que será la posicion deL apuntador del enemigo en este caso.
        _shotOriginTransform = _shotOriginObject.transform;
        //el transform del propio GO
        _myTransform = transform;
    }

    
    //si el enemigo ha recibido daño empieza a atacar
    void Update()
     {
        //comprobacion para que exista antes el EnemyLifeComponent
        //mientras no haya pasado el tiempo de espera de disparo
        if (_myContadorDisparo <= 0)
        {

            //comprobamos en cada frame la vida del enemigo si es máxima o no 
            if (enemyLifeComponentDron._currentLife != enemyLifeComponentDron._maxLife)
            {
                //si es menor , significa que le han atacado
                //ShootEnemy();
                Shoot();
            }
            //se reinicia el contador
            _myContadorDisparo = 3;
        }
        _myContadorDisparo -= Time.deltaTime;
    }

    public void Shoot()
    {
        
        //queremos crear mas de una bala, en el momento en que se instancia 1 bala se hace su movimiento automatico
        //se empieza corrutina de disparo
        StartCoroutine("Disparos");
    }
    IEnumerator Disparos()
    {
        int i = 0;
        while (i < numBalas)
        {
            yield return new WaitForSeconds(0.5f);
           
            //el Raycast se compone de un origen , una direccion , un hit , una distancia y un layermask
            RaycastHit hit;

            //si detecta algo
            if (Physics.Raycast(_shotOriginTransform.position, _shotOriginTransform.forward, out hit, 100))
            {
                //de a lo que dé de decimos su nombre
                Debug.Log(hit.transform.name);
            }

            //creamos la bala y la instanciamos en una posicion
            Rigidbody balaInstancia = Instantiate(bala, apuntador.position, Quaternion.identity);
            //le añadimos una fuerza a la bala instanciada en una direccion
            balaInstancia.AddForce(apuntador.forward * _velocidadDisparo, ForceMode.Impulse);
            //hacemos sonido disparo Dron
            this.GetComponent<AudioSource>().clip = disparoBala;
            this.GetComponent<AudioSource>().PlayOneShot(disparoBala, 0.5f);

            //aumento
            i++;
        }

    }
}
