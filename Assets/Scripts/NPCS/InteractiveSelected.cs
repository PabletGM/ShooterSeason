using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSelected : MonoBehaviour
{
    //para comprobar si nuestro raycast interactua con objetos que posean este layer
    LayerMask mask;
    //distancia  a la que detectará el objeto
    public float distancia = 1.5f;

    public GameObject InteractiveText;

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
                //comprobamos si se ha pulsado E para interactuar
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<ObjetoInteractivo>().ActivarObjeto();
                }
            }
            //dibujar el rayo
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            //no se puede interactuar con el
            InteractiveText.SetActive(false);
        }
    }
}


