using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSelected : MonoBehaviour
{
    //para comprobar si nuestro raycast interactua con objetos que posean este layer
    LayerMask mask;
    //distancia  a la que detectará el objeto
    public float distancia;

    public GameObject InteractiveText;

    private bool ImpedimentoInteractuar = false;

    void Start()
    {
        //damos valor inicial al layer
        mask = LayerMask.GetMask("interactive");
        //por defecto desactivamos este
        InteractiveText.SetActive(false);
    }

    void Update()
    {
        //Raycast(origen, direccion, out hit,distancia, mascara)

        RaycastHit hit;

        //comprobamos que raycast choca con objeto con layer Interactive
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            //se pued einteractuar con el
            InteractiveText.SetActive(true);
            //segunda comprobacion, segun el tag
            if (hit.collider.tag == "Objeto Interactivo")
            {
                //comprobamos si se ha pulsado E para interactuar y si no hay impedimento
                if (Input.GetKeyDown(KeyCode.E) && !GetImpedimentoInteractuar())
                {
                    hit.collider.transform.GetComponent<ObjetoInteractivo>().ActivarObjeto();
                    //impedimos interactuar más
                    SetImpedimentoInteractuar(true);
                }
            }
            //dibujar el rayo
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            //no se puede interactuar con el
            InteractiveText.SetActive(false);
            //quitamos el impedimento para poder interactuar mas
            SetImpedimentoInteractuar(false);
        }
    }

    //metodo que impide que se pueda interactuar mas de 1 vez seguida
    public void SetImpedimentoInteractuar(bool set)
    {
        ImpedimentoInteractuar = set;
    }
    public bool GetImpedimentoInteractuar()
    {
        return ImpedimentoInteractuar;
    }
}



