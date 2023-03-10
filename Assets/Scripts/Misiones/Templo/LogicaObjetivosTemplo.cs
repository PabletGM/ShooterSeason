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
    //singleton
    static private LogicaObjetivosTemplo _instance;

    #endregion

    #region parameters
    private bool levelTemploCompleted= false;
    #endregion

    #region methods


    static public LogicaObjetivosTemplo GetInstance()
    {
        return _instance;
    }

    //asi poder saber el estado de si nos hemos pasado el templo
    public bool GetStateTemploCompleted()
    {
        return levelTemploCompleted;
    }

    //para cambiar el estado de si nos hemos pasado el templo
    public void SetStateTemploCompleted(bool enabled)
    {
        levelTemploCompleted = enabled ;
    }

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

    private void Awake()
    {    
        if (_instance == null)
        {
            _instance = this;
        }
        //si la instancia existe , destruimos la copia
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //modificamos el texto de la mision inicial
        textoMision.text = "Entra a la zona del templo";
    }

    // Update is called once per frame
    void Update()
    {
        //2 condiciones: sino quedan enemigos y no nos hemos pasado el templo
        if(GameManager.GetInstance().NumeroEnemigosZona() <= 0 && !GetStateTemploCompleted())
        {
            //cambiamos mensaje a 
            textoMision.text = "Coge el contrarreloj para finalizar el nivel 1";

            BottonQuitMisionesLevel1();
        }
    }
}
