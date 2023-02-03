using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingPlayer : MonoBehaviour
{
    #region references
    private PlayerLifeComponent _myPlayerLifeComponent;
    #endregion

    //por cuestion de prueba y error se hace desde la propia bala llamando al damage del PLayerLifeComponent en vez desde el collider del player
    private void OnCollisionEnter(Collision collision)
    {
        //la bala ha dado al jugador
        if (collision.gameObject.GetComponent<PlayerLifeComponent>())
        {
            //hacemos daño al jugador
            collision.gameObject.GetComponent<PlayerLifeComponent>().Damage();
            
        }
        Destroy();
    }
   

    //destruimos la bala en 3 segundos por si no colisiona con nada 
    void Start()
    {
        _myPlayerLifeComponent = GetComponent<PlayerLifeComponent>();
        Destroy(this.gameObject, 10f);
    }
    public void Destroy()
    {
        Destroy(this.gameObject,0.01f);
    }


}
