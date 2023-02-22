using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    #region references
    GameManager _myGameManager;
    #endregion 
    #region parameters
    /// <summary>
    /// Vertical line for death of enemies.
    /// </summary>
    //[SerializeField]
    //private float _deadLineHeight = -10.0f;
    /// <summary>
    /// Initial life for the player
    /// </summary>
    [SerializeField]
    private int _maxLife = 100;
    /// <summary>
    /// Life points lost when player receives damage
    /// </summary>
    [SerializeField]
    private int _hitDamage = 10;


   
    #endregion
    #region properties
    /// <summary>
    /// Stores current life points
    /// </summary>
    private int _currentLife;

    
    #endregion
    #region methods
    /// <summary>
    /// Called on collision with other objects.
    /// If collided object is an enemy, the player receives damage.
    /// </summary>
    /// <param name="collision"></param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {  
        //si el objeto con el que choca el jugador es el enemigo bola,dron o torreta que tiene que haber una invencibilidad durnate un tiempo
        if (hit.collider.gameObject.GetComponent<EnemyController>())
        {
            //que el script esté activo
            if(this.gameObject.GetComponent<PlayerLifeComponent>().enabled)
            {
                //al enemigo que se ha chocado lo desplazas
                hit.collider.GetComponent<EnemyController>().Boost(3);
                //le haces el daño correspondiente
                Damage();
                //activamos invulnerabilidad desactivando este script
                this.gameObject.GetComponent<PlayerLifeComponent>().enabled = false;
                //lo volvemos a activar en x tiempo
                Invoke("Invulnerability", 0.5f);
            }
           
        }

        //si es torreta o dron y su disparo  pues daño practicamente inmediato
        //else if(hit.collider.gameObject.GetComponent<DamagingPlayer>())
        //{
        //    //que el script esté activo
        //    if (this.gameObject.GetComponent<PlayerLifeComponent>().enabled)
        //    {
                
        //        //le haces el daño correspondiente
        //        Damage();
        //        //activamos invulnerabilidad desactivando este script
        //        this.gameObject.GetComponent<PlayerLifeComponent>().enabled = false;
        //        //lo volvemos a activar en x tiempo
        //        Invoke("Invulnerability",0.01f);
        //    }

        //}
    }
    private void Invulnerability()
    {
        //desactiva durante 1 segundo este script para así no recibir daño y fingir ser invencible durante x tiempo
        this.gameObject.GetComponent<PlayerLifeComponent>().enabled = true;
    }

    /// <summary>
    /// Method called when player receives damage.
    /// </summary>
    public void Damage()
    {
        //si se le hace daño al jugador
        _currentLife -= _hitDamage;
        if(_currentLife<=0)
        {
            _myGameManager.OnPlayerDefeat();
           //no se destruye el objeto al morir porque está la camara pero si se paraliza
        }
        //comunicas ese daño al jugador al GameManager
        _myGameManager.OnPlayerDamage(_currentLife);
    }
    #endregion
    /// <summary>
    /// Initializes current life of the player
    /// </summary>
    void Start()
    {
        
        _myGameManager = GameManager.GetInstance();
        _myGameManager.SETPLAYER(this.gameObject);
        _currentLife = _maxLife;
        
    }
    void Update()
    {

        ////si la posicion y del GO es menor que el deadLine
        //if (transform.position.y < _deadLineHeight)
        //{
        //    _myGameManager.OnPlayerDefeat();
        //}
    }
}
