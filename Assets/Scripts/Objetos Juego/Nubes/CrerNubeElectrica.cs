using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrerNubeElectrica : MonoBehaviour
{
    private PoolNubesElectricas pool;

    public bool activo = true;
    MaquinaFSM maquina;
    // Start is called before the first frame update
    void Start()
    {
        maquina = MaquinaFSM.Instance;
        pool = GetComponent<PoolNubesElectricas>();
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

    void OnEnable()
    {
        Invoke("activarObjeto", Random.Range(2f, 4f));
    }

    void OnDisable()
    {
        if (maquina.desactivarObjetos)
        {
            pool.desactivarObjetos();
            CancelInvoke();
        }
    }

}

