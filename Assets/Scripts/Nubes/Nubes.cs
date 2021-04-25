using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nubes : MonoBehaviour
{
    //Velocidad de la nube
    public float velocidad = 2f;

    //Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
        transform.position += transform.up * velocidad * Time.deltaTime;

        if (transform.position.y > 7f)
        {
            Destroy(gameObject);
        }
    }
}
