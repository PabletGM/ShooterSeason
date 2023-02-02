using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeComponent : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Life parameter for enemy.
    /// </summary>
    private int _maxLife = 100;
    /// <summary>
    /// Life points lost when character receives damage.
    /// </summary>
    [SerializeField]
    private int _hitDamage = 25;
    /// <summary>
    /// Vertical line for death of enemies.
    /// </summary>
    //[SerializeField]
    //private float _deadLineHeight = -10.0f;
    #endregion

    #region references
    public GameObject healthEnemyBar;
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

    private AumentoTamaño _myAumentotamaño;
    #endregion

    #region properties
    /// <summary>
    /// Stores player's current life points.
    /// </summary>
    private int _currentLife;
    #endregion
    #region methods
    /// <summary>
    /// Called when enemy collides with other object.
    /// If collided object is an enemy, local enemy receives damage.
    /// </summary>
    /// <param name="collision"></param>
    

    public void EfectoPelota()
    {
        //se le hace daño
        Damage();
        //se le aplica un impulso
        _myEnemyController.Boost(3);
        //se le cambia la escala
        _myAumentotamaño.AumentoSize();
    }
    
    /// <summary>
    /// Called when enemy receives damage.
    /// Updates life points of the enemy and corresponding points display.
    /// Is life points are lower than or equal to zero, enemy dies.
    /// </summary>
    
    public void Damage()
    {
        
        //si tiene vida se le quita 1 vida
        Debug.Log("Has infligido daño al enemigo");
        //le quitamos 1 vida
        _currentLife -= _hitDamage;
        //actualizamos barra de vida
        ActualizarVidaEnemigo(_currentLife);
        //cambiamos su texto de numero de vidas 
        _myText.text = _currentLife.ToString();
        //si no le quedan vidas
        if(_currentLife<=0)
        {
            //si es de el nivel 1
            if (this.gameObject.GetComponent<EnemyController>())
            {
                Die1();
            }
            //si es del nivel 2
            if (this.gameObject.GetComponent<EnemyController2>())
            {
                Die2();

            }
        }
    }
    public void ActualizarVidaEnemigo(int health_Enemy)
    {
        healthEnemyBar.GetComponent<HealthBarEnemy>().SetEnemyHealth(health_Enemy);
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
        Debug.Log(this.gameObject.name + " ha muerto");
    }
    public void Die2()
    {
        //se quita al enemigo de la lista 2
        _myGameManager.OnEnemyDies2(_myEnemyController2);
        Destroy(this.gameObject);
        Debug.Log(this.gameObject.name + " ha muerto");
    }
    public void VidaMaximaEnemigo(int maxhealth_Enemy)
    {
        healthEnemyBar.GetComponent<HealthBarEnemy>().SetEnemyMaxHealth(maxhealth_Enemy);
    }

    
    //metodo que devuelve en todo momento la vida del enemigo actual
    
    #endregion

    /// <summary>
    /// Initialization of properties and references.
    /// </summary>
    void Start()
    {
        _myAumentotamaño = GetComponent<AumentoTamaño>();
        _myGameManager = GameManager.GetInstance();
        _myEnemyController = GetComponent<EnemyController>();
        _myEnemyController2 = GetComponent<EnemyController2>();

        //ponemos vida maxima tanto en barra de vida como jugador
        _currentLife = _maxLife;
        VidaMaximaEnemigo(_currentLife);
        //
        //this.gameObject.GetComponent<EnemyAttackController>().EnemyAttack(this);
        
    }
    /// <summary>
    /// Checks vertical position against Dead Line.
    /// </summary>
    void Update()
    {
        //si la posicion y del GO es menor que el deadLine
        //if(transform.position.y<_deadLineHeight)
        //{
        //    Die();
        //}
    }
}


