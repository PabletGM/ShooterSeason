using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    #region references
    /// <summary>
    /// reference to player camera
    /// </summary>
    public Transform playerCamera;
    /// <summary>
    /// reference to portal where the camera is
    /// </summary>
    public Transform portal;
    /// <summary>
    /// reference to otherPortal where you are looking to
    /// </summary>
    public Transform otherPortal;

    #endregion



    // Update is called once per frame
    void Update()
    {
        //distancia del jugador a el portal = posicion de camara - posicion otro portal
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        //posicion de la camara = posicion del portal + offset
        transform.position = portal.position + playerOffsetFromPortal;


        //devuelve angulo de rotacion entre varios portales
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        //devuelve rotacion entre portales
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        //nueva direccion de  camara
        Vector3 newCamaraDirection = portalRotationalDifference * playerCamera.forward;
        //transformamos esta direcion calculada en rotacion
        transform.rotation = Quaternion.LookRotation(newCamaraDirection,Vector3.up);
    }
}
