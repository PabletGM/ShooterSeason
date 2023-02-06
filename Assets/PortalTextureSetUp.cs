using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    //script que pone las dimensiones del render Texture al de la pantalla actual

    #region references
       public Camera cameraRenderPortalPueblo;
       public Material cameraMaterial;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //si existe la camara
        if(cameraRenderPortalPueblo.targetTexture!=null)
        {
            cameraRenderPortalPueblo.targetTexture.Release();
        }
        //ponemos tamaño de la renderTexture y el depth=24
        cameraRenderPortalPueblo.targetTexture = new RenderTexture(Screen.width, Screen.height, 20);
        cameraMaterial.mainTexture = cameraRenderPortalPueblo.targetTexture;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
