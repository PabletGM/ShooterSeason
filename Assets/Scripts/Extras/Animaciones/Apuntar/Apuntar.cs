using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntar : MonoBehaviour
{

    public Animator animatorApuntar;
 
    //private bool apuntar = true;
    // Start is called before the first frame update
    public void Apuntado()
    {
        //apuntar = !apuntar;
        //cambiamos bool de animator Apuntando de valor
        animatorApuntar.SetBool("IsApuntando",true);
       
    }
    public void DesApuntado()
    {
        //apuntar = !apuntar;
        //cambiamos bool de animator Apuntando de valor
        animatorApuntar.SetBool("IsApuntando", false);

    }
   
}
