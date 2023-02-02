using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoController : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to Transform of Main Camera.
    /// </summary>
    [SerializeField]
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
        //hacemos que el transform del enemigo mire a la camara y su posicion mientras esté el jugador vivo porque sino se destruye tambien la camara
        if(_cameraTransform !=null)
        {
            _myTransform.LookAt(_cameraTransform.position);
        }
        
        
    }
}


