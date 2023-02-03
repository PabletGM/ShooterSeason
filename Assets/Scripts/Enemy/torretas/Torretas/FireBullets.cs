using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField]
    private float _myContadorDisparo;

    [SerializeField]
    private protected GameObject  _bullet;

    [SerializeField]
    private protected Transform apuntadorTorreta;

    private Transform _mytransform;

    private float DistanceMinimum = 30f;

    private float numBalas = 3f;

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
        //si está en la distancia minima
        if (Vector3.Distance(_mytransform.position, _myPlayer.position) < DistanceMinimum)
        {
            //y el contador de disparo es 0
            if (_myContadorDisparo <= 0)
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
        //queremos crear mas de una bala, en el momento en que se instancia 1 bala se hace su movimiento automatico
        
            //se empieza corrutina de disparo
            StartCoroutine("Disparo"); 
        
        //le añadimos una fuerza a la bala instanciada en una direccion
        //balaInstancia.AddForce(apuntadorTorreta.forward * _velocidadDisparo, ForceMode.Impulse);

    }
    IEnumerator  Disparo()
    {
        int i = 0;
        while(i<numBalas)
        {
            yield return new WaitForSeconds(0.5f);
            //creamos la bala y la instanciamos en una posicion
            Instantiate(_bullet, apuntadorTorreta.position, apuntadorTorreta.rotation);
            //aumento
            i++;
        }
        
    }
}
