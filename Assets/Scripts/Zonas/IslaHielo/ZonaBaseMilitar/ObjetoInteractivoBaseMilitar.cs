using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivoBaseMilitar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GetInstance().AddObjectInteractive();
    }

    
}
