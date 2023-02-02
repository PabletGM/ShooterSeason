using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaMirarCamara : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to Transform of Main Camera.
    /// </summary>
    private Transform _cameraTransform;
    /// <summary>
    /// Reference to own Transform.
    /// </summary>
    private Transform _myTransform;
    #endregion
    #region properties
    /// <summary>
    /// Store own initial rotation.
    /// </summary>
    Quaternion _initialRotation;
    #endregion

    /// <summary>
    /// Finds Main Camera and initializes references.
    /// </summary>
    void Start()
    {
        //asociamos la camara y su transform
        _cameraTransform = Camera.main.transform;
        //asociamos el transform del enemigo para poder utilizarlo
        _myTransform = transform;
        
    }
    /// <summary>
    /// Positions life text in front of own object, according to camera.
    /// Uses lookat method to make it look at camera.
    /// </summary>
    void Update()
    {
        //hacemos que el transform del enemigo mire a la camara y su posicion   
        _myTransform.LookAt(_cameraTransform.position);
        //rotamos la monedita 90 grados en x para que se mantenga elevada
        _myTransform.Rotate(90, 0, 0);
    }
}

