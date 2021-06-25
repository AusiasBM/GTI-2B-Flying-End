using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearBoost : MonoBehaviour
{
    private PoolBoost pool;

    public bool activo = true;

    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<PoolBoost>();
    }

    void activarObjeto()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posición random desde la que saldrá
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreación es el radio de la esfera)
        pos = transform.position + Random.onUnitSphere * 8f;

        GameObject obj = pool.chooseBoost();
        pos = new Vector3(pos.x, transform.position.y, 0);
        obj.transform.position = pos;

        Invoke("activarObjeto", Random.Range(15f, 20f));
    }

    void OnEnable()
    {
        Invoke("activarObjeto", Random.Range(15f, 20f));
    }

}
