using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosDesfiladeroDrones : MonoBehaviour
{
    #region methods

    public void AñadirEnemigo(EnemyController enemyController)
    {
        GameManager.GetInstance().AddEnemy(enemyController);
    }
    //limites que impiden volver a atrás a activar viejos colliders
    private void AñadirLimitesAntesDesfiladero()
    {
        Debug.Log("limites añadidos");
        limitesNivelDesfiladero.SetActive(true);
    }

    #endregion

    #region reference


    [SerializeField]
    private protected GameObject limitesNivelDesfiladero;

    #endregion

    void Start()
    {  
        //reinicia lista de enemigos
        GameManager.GetInstance().ResetEnemies();
    }

    //comprueba que quedan enemigos en la zona
    void Update()
    {
        //se pasa de nivel
        //if (GameManager.GetInstance().NumeroEnemigosZona() <= 0)
        //{

        //    //se destruye este script y el gameObject
        //    Destroy(this.gameObject);
        //}
    }
    //trigger de zona
    private void OnTriggerEnter(Collider collision)
    {
        //por cada enemigo que descubra sumará 1 a la lista
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            //llamará al metodo de ese enemigo y de ese script EnemyController si el boxCollider esta activo
            if (this.GetComponent<BoxCollider>().enabled == true)
            {
                collision.gameObject.GetComponent<EnemyController>().NewEnemyZonaDesfiladero();
            }
        }

        //si entra jugador avisa y activa paredes invisibles de la zona 1 , no se podrá salir ya de esta, asi evitamos que algun enemigo salga y vuelva a entrar detectandolo 2 veces el collider y jodiendo el registro de enemigos
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            Debug.Log("Entró jugador");
            //activando nivel Desfiladero
            Invoke("AñadirLimitesAntesDesfiladero", 1.0f);
            //si detecta a jugador damos nueva señal para cambio de mision
            LogicaObjetivosTemplo.GetInstance().SetNewMission("Acaba con los enemigos del Desfiladero");
            //activa enemigos
            GameManager.GetInstance().SetEnemiesLeft(true);
        }
    }
}
