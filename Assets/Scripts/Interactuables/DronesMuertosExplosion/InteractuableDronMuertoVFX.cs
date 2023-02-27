using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableDronMuertoVFX : MonoBehaviour
{
    [SerializeField]
    private protected GameObject Explosion;

    //activamos efectos de particulas de la explosion
    [SerializeField]
    private protected ParticleSystem p1;
    [SerializeField]
    private protected ParticleSystem p2;
    [SerializeField]
    private protected ParticleSystem p3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerLifeComponent>())
        {
            Explosion.SetActive(true);
            p1.Play();
            p2.Play();
            p3.Play();
            //desactivamos script
            this.gameObject.SetActive(false);
        }
    }
}
