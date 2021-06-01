using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Magnetic : MonoBehaviour
{
    public float magnetForce = 5;

    GameObject p;
    Jugador jugador;

    // List<GameObject> gameObjects = new List<GameObject>();
    void Start()
    {
        jugador = Jugador.Instance;
        //rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (p != null && jugador.isMagnetic)
        {

            transform.position -= magnetForce * Time.deltaTime * (transform.position - p.transform.position);           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            p = other.gameObject;
        }
    }
}