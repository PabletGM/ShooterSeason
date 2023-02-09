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

    //comprueba que quedan enemigos en la zona
    void Update()
    {
        //se pasa de nivel
        if(GameManager.GetInstance().NumeroEnemigosZona()<=0)
        {
            GameManager.GetInstance().NivelTemploContrarrelojAcabado();
            //se destruye este script y el gameObject
            Destroy(this.gameObject);
        }
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

        //si entra jugador avisa y activa paredes invisibles de la zona 1 , no se podrá salir ya de esta.
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            Debug.Log("Entro jugador");
        }
    }
}
