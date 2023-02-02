using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    #region references

    [SerializeField]
    private protected Transform _myTarget;

    [SerializeField]
    private protected Transform _myApuntador;

    #endregion 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //sacamos la direccion a la que nuestra torreta debe apuntar ( la posicion del objetivo - nuestro apuntador)
        Vector3 targetOrientation = _myTarget.position - _myApuntador.position;
        //dibujamos un rayo para poder ver en vista escena la direccion de la bala
        Debug.DrawRay(_myApuntador.position, targetOrientation, Color.green);

        //2 tipos de orientaciones de la ametralladora al target , instantanea o con retroceso

        //instantanea
        //transform.rotation = Quaternion.LookRotation(targetOrientation);

        //con retroceso
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);
    }
}

