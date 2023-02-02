using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoEstatico : MonoBehaviour
{
    //modo que emplean los drones comunes del mapa para quedarse quietos hasta que se acerca el jugador un mínimo de distancia
    private float _myMinimumDistance = 50f;

    public GameObject goalDestination;

    private Rigidbody _myRigidbody;

    void Start()
    {
        //asociamos  rigidbody
        _myRigidbody = GetComponent<Rigidbody>();
        //ponemos por defecto el dron rigidbody usegravity a false
        _myRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        //comprueba si está en el area indicada el jugador
        if (Vector3.Distance(transform.position, goalDestination.transform.position) < _myMinimumDistance)
        {
            //si lo está ponemos la gravedad enemiga para que pueda atacar
            _myRigidbody.useGravity = true;
        }
        else
        {
            _myRigidbody.useGravity = false;
        }
    }
}
