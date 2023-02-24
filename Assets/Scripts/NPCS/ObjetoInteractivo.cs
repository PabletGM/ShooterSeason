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
        //distincion entre NPCS para llamar a un metodo o otro

        //si es NPC al lado del templo
        if(this.gameObject.name == "dronNPC")
        {
            GameManager.GetInstance().DialogosNPCFueraTemplo(true);
        }
        //si es NPC pradera
        else if(this.gameObject.name == "dronNPC2")
        {
            GameManager.GetInstance().DialogosNPCPradera(true);
        }
        //si es NPC islaHielo
        else if (this.gameObject.name == "dronNPC3")
        {
            GameManager.GetInstance().DialogosNPCIsla(true);
        }

        //orden de ejecutar dialogos
        Dialogo.GetComponent<DialogueScriptNPC>().StartDialogue();
        //se encargará de empezar los dialogos
        Debug.Log("objeto activado");
    }

    private void Start()
    {
        
    }
}


