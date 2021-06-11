using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrerNubeElectrica : MonoBehaviour
{
    private PoolNubesElectricas pool;

    public bool activo = true;
    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<PoolNubesElectricas>();
        Invoke("activarObjeto", Random.Range(2f, 3f));
    }

    void activarObjeto()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posición random desde la que saldrá
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreación es el radio de la esfera)
        pos = transform.position + Random.onUnitSphere * 8f;

        GameObject obj = pool.chooseNube();
        pos = new Vector3(pos.x, transform.position.y, 0);
        obj.transform.position = pos;

        if (activo) Invoke("activarObjeto", Random.Range(2f, 5f));
    }
}
