using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscribirtTips : MonoBehaviour
{
    #region references
    public TextMeshProUGUI textoTips;
    //singleton
    static private EscribirtTips _instance;

    #endregion

    #region methods


    static public EscribirtTips GetInstance()
    {
        return _instance;
    }

    //aplicamos nueva mision desde fuera del script;
    public void SetNewTip(string newTip)
    {
        textoTips.text = newTip;
    }

    public void SetTip(bool set)
    {
        GameManager.GetInstance().SetTipsButtonGM(set);
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
        textoTips.text = "Si la camara no se mueve correctamente, pulsa esc 2 veces";

    }

}
