﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTorret : MonoBehaviour
{
    [SerializeField]
    private float _myContadorDisparo;
    
    [SerializeField]
    private float _velocidadDisparo=12f;

    [SerializeField]
    private protected Rigidbody _bullet;

    [SerializeField]
    private protected  Transform apuntadorTorreta;

    private Transform _mytransform;

    private float DistanceMinimum = 10f;

    [SerializeField]
    private protected Transform _myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(_mytransform.position,_myPlayer.position)< DistanceMinimum)
        {
            if(_myContadorDisparo<=0)
            {
                //antes de disparar calculamos el vector para saber la direccion que cogerá la bala
                Shoot();
                _myContadorDisparo = 3f;
            }
            _myContadorDisparo -= Time.deltaTime;
        }
    }
    //esta direccion será la resta de el vector de posicion del jugador - el vector de posicion del apuntador
    

    public void Shoot()
    {
        //creamos la bala y la instanciamos en una posicion
        Rigidbody balaInstancia = Instantiate(_bullet, apuntadorTorreta.position, Quaternion.identity);
        //le añadimos una fuerza a la bala instanciada en una direccion
        //balaInstancia.AddForce(apuntadorTorreta.forward * _velocidadDisparo, ForceMode.Impulse);
        balaInstancia.AddForce(apuntadorTorreta.forward  * _velocidadDisparo, ForceMode.Impulse);
    }
}
