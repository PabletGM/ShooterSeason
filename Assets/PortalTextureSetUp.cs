using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    //script que pone las dimensiones del render Texture al de la pantalla actual

    #region references
       public Camera cameraRenderPortalPueblo;
       public Camera cameraRenderPortalInicio;

       public Material cameraMaterialPortalPueblo;
       public Material cameraMaterialPortalInicio;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //si existe la cameraRenderPortalPueblo
        if (cameraRenderPortalPueblo.targetTexture!=null)
        {
            cameraRenderPortalPueblo.targetTexture.Release();
        }
        //ponemos tamaño de la renderTexture y el depth=24
        cameraRenderPortalPueblo.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMaterialPortalPueblo.mainTexture = cameraRenderPortalPueblo.targetTexture;



        //si existe la cameraRenderPortalInicio
        if (cameraRenderPortalInicio.targetTexture != null)
        {
            cameraRenderPortalInicio.targetTexture.Release();
        }
        //ponemos tamaño de la renderTexture y el depth=24
        cameraRenderPortalInicio.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMaterialPortalInicio.mainTexture = cameraRenderPortalInicio.targetTexture;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
