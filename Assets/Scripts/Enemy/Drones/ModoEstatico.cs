using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ModoEstatico : MonoBehaviour
{
    //modo que emplean los drones comunes del mapa para quedarse quietos hasta que se acerca el jugador un mínimo de distancia
    private float _myMinimumDistance = 5f;

    public NavMeshAgent navMeshAgent;
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
            Debug.Log("Hey");
            //se distancia minima la pasa ataca
          navMeshAgent.destination = goalDestination.transform.position;
            //quita bloqueo para que pueda moverse
            _myRigidbody.constraints = RigidbodyConstraints.None;

        }
        else
        {
            //bloquear o freeze positions
            _myRigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}
