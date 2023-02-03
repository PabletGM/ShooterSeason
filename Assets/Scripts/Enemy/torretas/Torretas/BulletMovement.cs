using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private protected float _speed = 2f;

    [SerializeField]
    private protected Rigidbody bala;


    void Start()
    {
        bala = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        bala.AddForce(transform.forward * Time.deltaTime * _speed);
    }
}
