using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeComponentDron : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Life parameter for enemy.
    /// </summary>
    [SerializeField]
    public int _maxLife = 100;
    /// <summary>
    /// Life points lost when character receives damage.
    /// </summary>
    [SerializeField]
    private int _hitDamage = 20;
    /// <summary>
    /// Vertical line for death of enemies.
    /// </summary>
    //[SerializeField]
    //private float _deadLineHeight = -10.0f;
    #endregion
    #region references
    public GameObject healthEnemyDronBar;
    /// <summary>
    /// Reference to local EnemyController.
    /// </summary>
    private EnemyController _myEnemyController;
    private EnemyController2 _myEnemyController2;
    /// <summary>
    /// Reference to local Transform.
    /// </summary>

    private Transform _myTransform;
    /// <summary>
    /// Reference to local Text, where enemy lifepoints will be displayed.
    /// </summary>

    GameManager _myGameManager;

    private UI_Manager _myUIManager;

    [SerializeField]
    private protected Text _myText;


    [SerializeField]
    private protected ParticleSystem strike;

    [SerializeField]
    private protected GameObject vfx;

    #endregion
    #region properties
    /// <summary>
    /// Stores player's current life points.
    /// </summary>
    public int _currentLife;
    #endregion
    #region methods
    /// <summary>
    /// Called when enemy collides with other object.
    /// If collided object is an enemy, local enemy receives damage.
    /// </summary>
    /// <param name="collision"></param>
    public void EfectoDron()
    {
        //se le hace daño
        Damage();
        //efectos de particulas golpe
        strike.Play();
        //si es enemigo nivel 1
        if(this.gameObject.GetComponent<EnemyController>())
        {
            //se le aplica un impulso
            _myEnemyController.Boost(3);
        }

       


    }

    /// <summary>
    /// Called when enemy receives damage.
    /// Updates life points of the enemy and corresponding points display.
    /// Is life points are lower than or equal to zero, enemy dies.
    /// </summary>
    public void Damage()
    {
        //si tiene vida se le quita 1 vida
        //Debug.Log("Has infligido daño al dron");
        //le quitamos 1 vida
        _currentLife -= _hitDamage;
        //actualizamos barra de vida
        ActualizarVidaDronEnemigo(_currentLife);
        //cambiamos su texto de numero de vidas 
        _myText.text = _currentLife.ToString();
        //si no le quedan vidas
        if (_currentLife <= 0)
        {
            //si es de el nivel 1
            if(this.gameObject.GetComponent<EnemyController>())
            {
                //destruimos efectos de particulas
                vfx.SetActive(false);
                Die1();
            }
            

        }
    }
    public void ActualizarVidaDronEnemigo(int health_Enemy)
    {
        healthEnemyDronBar.GetComponent<HealthBarEnemyDron>().SetDronHealth(health_Enemy);
    }
    /// <summary>
    /// Called when enemy dies.
    /// Calls corresponding method on GameManager and destroys object.
    /// </summary>
    public void Die1()
    {
        //se quita al enemigo de la lista
        _myGameManager.OnEnemyDies(_myEnemyController);
        Destroy(this.gameObject);
        //Debug.Log(this.gameObject.name + " ha muerto");
    }

    public void VidaMaximaDronEnemigo(int maxhealth_Enemy)
    {
        healthEnemyDronBar.GetComponent<HealthBarEnemyDron>().SetDronMaxHealth(maxhealth_Enemy);
    }
    #endregion

    /// <summary>
    /// Initialization of properties and references.
    /// </summary>
    void Start()
    {
        _myGameManager = GameManager.GetInstance();
        _myEnemyController = GetComponent<EnemyController>();
        _myEnemyController2 = GetComponent<EnemyController2>();

        //ponemos vida maxima tanto en barra de vida como jugador
        _currentLife = _maxLife;
        VidaMaximaDronEnemigo(_currentLife);

    }
    /// <summary>
    /// Checks vertical position against Dead Line.
    /// </summary>
    void Update()
    {
        //si la posicion y del GO es menor que el deadLine
        //if (transform.position.y < _deadLineHeight)
        //{
        //    Die();
        //}
    }
}

