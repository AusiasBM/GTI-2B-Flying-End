using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearLluvia : MonoBehaviour
{
    private PoolLluvia pool;

    public bool activo = true;
    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<PoolLluvia>();
        Invoke("activarObjeto", Random.Range(0f, 1f));
    }

    void activarObjeto()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posici�n random desde la que saldr�
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        pos = transform.position + Random.onUnitSphere * 1f;

        GameObject obj = pool.chooseLluvia();
        pos = new Vector3(pos.x, transform.position.y, 0);
        obj.transform.position = pos;

        if (activo) Invoke("activarObjeto", Random.Range(1f, 2f));
    }
}
