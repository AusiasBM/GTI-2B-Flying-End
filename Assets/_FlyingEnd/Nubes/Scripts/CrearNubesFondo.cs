using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearNubesFondo : MonoBehaviour
{
    private PoolNubesFondo pool;

    public bool activo = true;
    MaquinaFSM maquina;
    // Start is called before the first frame update
    void Start()
    {
        maquina = MaquinaFSM.Instance;
        pool = GetComponent<PoolNubesFondo>();
    }

    void activarObjeto()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posición random desde la que saldrá
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreación es el radio de la esfera)
        pos = transform.position + Random.onUnitSphere * 10f;

        GameObject obj = pool.chooseNube();
        pos = new Vector3(pos.x, transform.position.y, 2);
        obj.transform.position = pos;

        if (activo) Invoke("activarObjeto", Random.Range(4f, 6f));
    }

    void OnEnable()
    {
        Invoke("activarObjeto", 0);
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
