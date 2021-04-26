using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroIzda : MonoBehaviour
{
    //Velocidad del p?jaro
    public float velocidad = 6f;
    public float destruir = 14f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // En menos(-=) desplazamiento a la izquierda; en mas (+=) a la derecha
        transform.position += transform.right * velocidad * Time.deltaTime;

        if (transform.position.x > destruir)
        {
            Destroy(gameObject);
        }
    }
}
