using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAPlayerAttack : MonoBehaviour
{
    //seguirá al jugador que es el navMeshAgent.destination con los parametros del navMeshAgent siempre y cuando el jugador esté en la zona marcada
    public NavMeshAgent navMeshAgent;
    private float _myMinimumDistance = 20f;
    private float _distanciaKnockBack = 1f;
    public GameObject goalDestination;
    public GameObject FPSPlayer;
    NavMeshHit hit;
    private Rigidbody _myRigidbody;
    void Start()
    {
        //asociamos al rigidbody
        _myRigidbody = GetComponent<Rigidbody>();
        //por defecto desactivamos la gravedad del rigidbody 
        //comprobacion para ver si el enemigo agent está justo encima del navmesh y ajustarlo sino
        if(NavMesh.SamplePosition(navMeshAgent.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
           
            //navMeshAgent.Warp(hit.position);
            //navMeshAgent.destination = goalDestination.transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NavMesh.SamplePosition(navMeshAgent.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            //para ver si detecta al enemigo
            //si la distancia entre la ametralladora y el enemigo es < x
            if (Vector3.Distance(transform.position, goalDestination.transform.position) < _myMinimumDistance)
            {
                Debug.Log("localizado");
                //se pone el transform del enemigo como posicion del FPSPlayer 
                navMeshAgent.destination = FPSPlayer.transform.position;
            }
        }

        
           

        //añadimos modo estático mientras no ataque al jugador para que solo cuando detecte al jugador por distancia pueda acercarse y no caerse por la cuesta
    }

    //si player choca contra este
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Vector3.Distance(transform.position, goalDestination.transform.position) < _distanciaKnockBack)
            {
                //si el player y el enemigo estan a una distancia muy cercana(suponemos que ya han impactado y echamos al enemigo para atras)
                this.gameObject.GetComponent<EnemyController>().Boost(3);
                //hacemos daño al player
                other.gameObject.GetComponent<PlayerLifeComponent>().Damage();
            }
        }
    }
}
