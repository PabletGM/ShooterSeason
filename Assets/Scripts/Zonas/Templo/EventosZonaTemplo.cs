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

    private void AñadirLimitesLevel1()
    {
        Debug.Log("limites añadidos");
        limitesNivel1.SetActive(true);
    }

    #endregion

    #region references

    private EnemyController enemyController;

    private LogicaObjetivosTemplo logicaTemplo;

    [SerializeField]
    private protected GameObject limitesNivel1;

    #endregion

    void Start()
    {
        //inicializamos EnemyController
        //enemyController = GetComponent<EnemyController>();
        //reinicia lista de enemigos
        GameManager.GetInstance().ResetEnemies();
        logicaTemplo = GetComponent<LogicaObjetivosTemplo>();
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

        //si entra jugador avisa y activa paredes invisibles de la zona 1 , no se podrá salir ya de esta, asi evitamos que algun enemigo salga y vuelva a entrar detectandolo 2 veces el collider y jodiendo el registro de enemigos
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            Debug.Log("Entro jugador");
            //activando nivel 1
            Invoke("AñadirLimitesLevel1", 2.0f);
            //si detecta a jugador damos nueva señal para cambio de mision
            logicaTemplo.SetNewMission("Mata a todos los enemigos del Templo");
            

        }
    }
}
