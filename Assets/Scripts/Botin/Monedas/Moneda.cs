using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    //Velocidad del moneda
    public float velocidad = 3f;
    public float destruir = 9f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
        transform.position += transform.up * velocidad * Time.deltaTime;

        if (transform.position.y > destruir)
        {
            Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }*/
}
