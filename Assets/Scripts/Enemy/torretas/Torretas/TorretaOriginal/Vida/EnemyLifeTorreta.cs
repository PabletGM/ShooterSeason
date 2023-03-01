using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeTorreta : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Life parameter for enemy.
    /// </summary>
    private int _maxLife = 300;
    /// <summary>
    /// Life points lost when character receives damage.
    /// </summary>
    [SerializeField]
    private int _hitDamage = 25;
    /// <summary>
    /// Vertical line for death of enemies.
    /// </summary>
    [SerializeField]
    private protected float _deadLineHeight = -10.0f;
    #endregion
    #region references
    [SerializeField]
    private protected GameObject healthTorretBar;
    /// <summary>
    /// Reference to local EnemyController.
    /// </summary>
    private EnemyController _myEnemyController;
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


    //los 3 partycle system de la explosion

    [SerializeField]
    private GameObject VFX;
    
    [SerializeField]
    private ParticleSystem  _explosion1;

    [SerializeField]
    private ParticleSystem _explosion2;

    [SerializeField]
    private ParticleSystem _explosion3;
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
    

    public void EfectoTorreta()
    {
        //asi le haces daño
        Damage();
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
        ActualizarVidaTorretEnemigo(_currentLife);
        //cambiamos su texto de numero de vidas 
        _myText.text = _currentLife.ToString();
        //si no le quedan vidas
        if (_currentLife <= 0)
        {
            //particle system explotar
            VFX.SetActive(true);
            _explosion1.Play();
            _explosion2.Play();
            _explosion3.Play();
            Die();
            //VFX.SetActive(false);



        }
    }
    public void ActualizarVidaTorretEnemigo(int health_Turret)
    {
        healthTorretBar.GetComponent<HealthBarTorret>().SetTurretHealth(health_Turret);
    }
    /// <summary>
    /// Called when enemy dies.
    /// Calls corresponding method on GameManager and destroys object.
    /// </summary>
    public void Die()
    {
        //se quita al enemigo de la lista
        _myGameManager.OnEnemyDies(_myEnemyController);
        Destroy(this.gameObject);
        Debug.Log(this.gameObject.name + " ha muerto");
    }
    public void VidaMaximaTorretEnemigo(int maxhealth_Enemy)
    {
        healthTorretBar.GetComponent<HealthBarTorret>().SetTurretMaxHealth(maxhealth_Enemy);
    }


    //metodo que devuelve en todo momento la vida del enemigo actual

    #endregion

    /// <summary>
    /// Initialization of properties and references.
    /// </summary>
    void Start()
    {

        _myGameManager = GameManager.GetInstance();
        _myEnemyController = GetComponent<EnemyController>();


        //ponemos vida maxima tanto en barra de vida como jugador
        _currentLife = _maxLife;
        VidaMaximaTorretEnemigo(_currentLife);
        //
        //this.gameObject.GetComponent<EnemyAttackController>().EnemyAttack(this);

    }
}
