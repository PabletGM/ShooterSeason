using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionMoneda : MonoBehaviour
{
    //rota la moneda con una velocidad en el eje Y
    #region references
    Transform _mytransform;
    #endregion

    #region parameters
    [SerializeField]
    private protected float _velocidadRotacion;
   

    private Vector3 direccionMoneda;
    #endregion

     void Start()
     {
        _mytransform = transform;
        direccionMoneda = new Vector3(0, 0, 1);
        
     }

    void Update()
    {

        //queremos rotar en el ejeY el vector direccionMoneda para eso rotamos sobre el ejeZ
        _mytransform.Rotate(0,0,direccionMoneda.z*_velocidadRotacion);
    }

}
