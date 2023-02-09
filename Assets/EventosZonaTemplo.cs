using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosZonaTemplo : MonoBehaviour
{
    #region parameters

        

    #endregion

    #region methods

    public void AñadirEnemigo(EnemyController enemyController)
    {
        GameManager.GetInstance().AddEnemy(enemyController);
    }

    #endregion

    #region references

    private EnemyController enemyController;

    #endregion

    void Start()
    {
        //inicializamos EnemyController
        //enemyController = GetComponent<EnemyController>();
        //reinicia lista de enemigos
        GameManager.GetInstance().ResetEnemies();
    }
    //trigger de zona
    private void OnTriggerEnter(Collider collision)
    {
        //por cada enemigo que descubra sumará 1 a la lista
        if (collision.gameObject.GetComponent<EnemyController>() || collision.gameObject.GetComponent<EnemyController2>())
        {
            //llamará al metodo de ese enemigo y de ese script EnemyController
            collision.gameObject.GetComponent<EnemyController>().NewEnemyZonaTemplo();
        }

        //si entra jugador avisa
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            Debug.Log("Entro jugador");
        }
    }
}
