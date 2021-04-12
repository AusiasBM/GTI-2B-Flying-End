using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaAvion : MonoBehaviour
{
    //Velocidad del pájaro
    public float velocidad = 6f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
        transform.position -= transform.up * velocidad * Time.deltaTime;

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}
