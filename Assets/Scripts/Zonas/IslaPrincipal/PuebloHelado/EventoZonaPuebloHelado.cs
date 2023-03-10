using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoZonaPuebloHelado : MonoBehaviour
{
    #region methods
    //devuelve estado booleano
    public bool GetOcultarEnemigos()
    {
        return ocultarEnemigos;
    }

    public void SetOcultarEnemigos(bool ocultar)
    {
        ocultarEnemigos = ocultar;
    }

    public void AñadirEnemigo(EnemyController enemyController)
    {
        GameManager.GetInstance().AddEnemy(enemyController);
    }
    //limites que impiden volver a atrás a activar viejos colliders
    private void AñadirLimitesPuebloHielo()
    {
        Debug.Log("limites añadidos");
        limitesPuebloHielo.SetActive(true);
    }

    #endregion

    #region reference


    [SerializeField]
    private protected GameObject limitesPuebloHielo;

    [SerializeField]
    private protected GameObject triggerCinematicaPortales;

    #endregion

    #region parameters
    private bool ocultarEnemigos = false;
    #endregion

    void Start()
    {
        //reinicia lista de enemigos
        GameManager.GetInstance().ResetEnemies();
        
    }

    //comprueba que quedan enemigos en la zona
    void Update()
    {
        //si el booleano ocultar es true, y no quedan enemigos en la zona =  ocultamos el numero de enemies
        if (GetOcultarEnemigos() && GameManager.GetInstance().NumeroEnemigosZona() <= 0)
        {
            //ocultar panel enemigos
            GameManager.GetInstance().SetEnemiesLeft(false);
            //quitamos limites pueblo helado para poder ir al portal
            limitesPuebloHielo.SetActive(false);
            //activas un collider invisible en la puerta que active un evento que active las partes de los portales que se necesitan
            triggerCinematicaPortales.SetActive(true);
            LogicaObjetivosTemplo.GetInstance().SetNewMission("Vuelve a la puerta del pueblo");

            //desactivamos tips
            EscribirtTips.GetInstance().SetTip(false);
            //ponemos uno nuevo
            EscribirtTips.GetInstance().SetNewTip("");

            //desactivamos este script
            this.enabled = false;
        }
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
                collision.gameObject.GetComponent<EnemyController>().NewEnemyZonaPuebloHelado();
                //cuando ya exista el primer enemigo podemos poner el booleano a true para que se pueda cumplir la condicion del update al acabar con estos
                SetOcultarEnemigos(true);
            }
        }

        //si entra jugador avisa y activa paredes invisibles de la zona 1 , no se podrá salir ya de esta, asi evitamos que algun enemigo salga y vuelva a entrar detectandolo 2 veces el collider y jodiendo el registro de enemigos
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            Debug.Log("Entró jugador");
            //activando nivel Desfiladero
            Invoke("AñadirLimitesPuebloHielo", 1.0f);

            //activamos tips
            EscribirtTips.GetInstance().SetTip(true);
            //ponemos uno nuevo
            EscribirtTips.GetInstance().SetNewTip("Las torretas estan constantemente apuntandote, una buena estrategia es no quedarse quieto...");

            //si detecta a jugador damos nueva señal para cambio de mision
            LogicaObjetivosTemplo.GetInstance().SetNewMission("Acaba con los enemigos del Pueblo Hielo");
            //activa enemigos
            GameManager.GetInstance().SetEnemiesLeft(true);
        }

        //el booleano será true sino quedan enemigos
    }

    private void OnTriggerExit(Collider collision)
    {
       
    }

}
