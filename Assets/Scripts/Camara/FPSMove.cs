using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : MonoBehaviour
{
     #region parameters
     public float mouseSensitivity = 200f;
     public Transform playerBody;
     float xRotation= 0f;
    
    #endregion

    #region references
    GameManager _myGameManager;
    private UI_Manager _myUIManager;

    #endregion

   
    // permite que no noa movamos con el raton fuera de la pantalla
    void Start()
    {
        _myGameManager= GameManager.GetInstance();
        _myUIManager = GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {// si el cursor esta desactivado se mueve la camara
        if(!_myGameManager._myCursor)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            //sino ha muerto el jutgador
            if (playerBody != null)
            {
                playerBody.Rotate(Vector3.up * mouseX);
            }
        }
    }
   

}
