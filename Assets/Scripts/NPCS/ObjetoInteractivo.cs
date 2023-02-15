using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    //objeto que posee el dialogo
    [SerializeField]
    private protected GameObject Dialogo;
    

    public void ActivarObjeto()
    {
        //primero el GameOject Dialogos debe estar activado
        GameManager.GetInstance().DialogosNPCFueraTemplo(true);
        //orden de ejecutar dialogos
        Dialogo.GetComponent<DialogueScriptNPC>().StartDialogue();
        //se encargará de empezar los dialogos
        Debug.Log("objeto activado");
    }

    private void Start()
    {
        
    }
}


