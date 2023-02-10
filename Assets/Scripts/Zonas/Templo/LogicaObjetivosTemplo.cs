using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaObjetivosTemplo : MonoBehaviour
{
    #region references
    public TextMeshProUGUI textoMision;
    public GameObject botonDeMisionAcabada;

    #endregion

    #region methods
    //aplicamos nueva mision desde fuera del script;
    public void SetNewMission(string newMission)
    {
        textoMision.text = newMission;
    }

    private void BottonQuitMisionesLevel1()
    {
        //activamos raton para Menus y ponemos variable .myCursor= true ya que en Update hace la comprobacion y permitirá clickar en Menus
        GameManager.GetInstance()._myCursor=true;
        //aparece el boton quit
        botonDeMisionAcabada.SetActive(true);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //modificamos el texto de la mision inicial
        textoMision.text = "Entra a la zona del templo";
    }

    // Update is called once per frame
    void Update()
    {
        //comprobamos que queden enemigos en el templo
        if(GameManager.GetInstance().NumeroEnemigosZona()<=0)
        {
            //cambiamos mensaje a 
            textoMision.text = "Coge el contrarreloj para finalizar el nivel 1";

            BottonQuitMisionesLevel1();
        }
    }
}
