using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoTamaño : MonoBehaviour
{
    #region properties
    private Transform _myTransform;
    #endregion

    #region parameters
    [SerializeField]
    private protected float aumentoTamaño;
    #endregion

    private void Start()
    {
        _myTransform = transform;
    }
    public void AumentoSize()
    {
        _myTransform.localScale *= aumentoTamaño;
    }
}
