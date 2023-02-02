using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Perception : MonoBehaviour
{
    #region references
    private IA_AttackController _myIA_AttackController;

    void Start()
    {
        _myIA_AttackController = GetComponent<IA_AttackController>();
    }
    #endregion 
    //si se chocan con el AreaDisparo pues el jugador toma la posicion del enemigo y les dispara
    private void OnCollisionEnter(Collision collision)
    {
        //si choca con el boxcollider un enemigo bola o dron
        if(collision.gameObject.GetComponent<EnemyLifeComponent>() || collision.gameObject.GetComponent<EnemyLifeComponentDron>())
        {
            //almacenas su posicion la del enemy o objeto estrellado contra boxcollider
            Vector3 posicionEnemy = collision.transform.position;
            //pasas esa posicion como parametro en Shoot para que disparen ahí
            _myIA_AttackController.Shoot(posicionEnemy);
        }
    }
}
