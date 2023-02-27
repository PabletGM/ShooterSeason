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
            //orden de ejecutar dialogos
            Dialogo.GetComponent<DialogueScriptNPC>().StartDialogue();
        }
        //si es NPC pradera
        else if(this.gameObject.name == "dronNPC2")
        {
            GameManager.GetInstance().DialogosNPCPradera(true);
            //orden de ejecutar dialogos
            Dialogo.GetComponent<DialogueScriptNPC>().StartDialogue();
        }
        //si es NPC islaHielo
        else if (this.gameObject.name == "dronNPC3")
        {
            GameManager.GetInstance().DialogosNPCIsla(true);
            //orden de ejecutar dialogos
            Dialogo.GetComponent<DialogueScriptNPC>().StartDialogue();
        }
        //si se interactua con dronMuerto
        else if(this.gameObject.name == "dronMuerto" || this.gameObject.name == "dronMuerto (1)")
        {
            //se suma a contador de interactuados en ZonaBaseMilitar
            GameManager.GetInstance().QuitarObjectInteractive();
        }

        
        //se encargará de empezar los dialogos
        Debug.Log("objeto activado");
    }

    private void Start()
    {
        
    }
}


