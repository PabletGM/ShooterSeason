using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBobbing : MonoBehaviour
{
    #region  transform references

        [SerializeField]
        private protected Transform HeadTransform;

        [SerializeField]
        private protected Transform CameraTransform;

    #endregion

    #region  head bobbing parameters
        //velocidad del efecto
        public float bobbingFrequency = 5f;
        //amplitud horizontal y vertical
        public float bobbingHorizontalAmplitude = 0.1f;
        //suavidad del movimiento
        public float bobbingVerticalAmplitude = 0.1f;

        [Range(0, 1)] public float headbobbingSmooth = 0.1f;

    #endregion

    #region estado
        //para ver si se aplica el efecto ya que es solo al andar
        public bool isWalking;
        //contador para ver cuanto tiempo ha andado el jugador
        private float walkingTime;
        //posicion en la que queremos que esté la camara
        private Vector3 targetCamaraPosition;
    #endregion

   

    // Update is called once per frame
    void Update()
    {
        //set time and offset to 0
        if (!isWalking) { walkingTime = 0; }
        else { walkingTime += Time.deltaTime; }

        //calculamos la posicion de la camara
        targetCamaraPosition = HeadTransform.position + CalculateHeadBobOffset(walkingTime);

        //interpolacion de la posicion para que la camara tenga un retardo en aplicar el move entre posicion de la camara y el destino
        CameraTransform.position = Vector3.Lerp(CameraTransform.position, targetCamaraPosition, headbobbingSmooth);

        //si la distancia entre objetivo de posicion y camara posicion es muy cercano que sea igual
        if((CameraTransform.position - targetCamaraPosition).magnitude<= 0.001)
        {
            CameraTransform.position = targetCamaraPosition;
        }
    }

    private Vector3 CalculateHeadBobOffset(float t)
    {
        float horizontalOffset = 0;
        float verticalOffset = 0;
        Vector3 offset = Vector3.zero;

        if(t>0)
        {
            //calculate offsets
            horizontalOffset = Mathf.Cos(t * bobbingFrequency) * bobbingHorizontalAmplitude;
            verticalOffset = Mathf.Sin(t * bobbingFrequency*2) * bobbingVerticalAmplitude;

            //con los offsets o distancias en cuanto a la posicion de la cabeza ahora calculamos donde irá en este segundo t la camara
            offset = HeadTransform.right * horizontalOffset + HeadTransform.up * verticalOffset;
        }
        //devolvemos ese vector 3;
        return offset;
    }
}
