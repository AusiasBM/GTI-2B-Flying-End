using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPiezas : MonoBehaviour
{
    private PoolPiezas pool;

    public bool activo = true;

    RalentizadorVelocidad ralentizador;
    MaquinaFSM maquina;
    // Start is called before the first frame update
    void Start()
    {
        ralentizador = RalentizadorVelocidad.Instance;
        maquina = MaquinaFSM.Instance;
        pool = GetComponent<PoolPiezas>();
    }

    void activarObjeto()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posición random desde la que saldrá
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreación es el radio de la esfera)
        pos = transform.position + Random.onUnitSphere * 8f;

        GameObject obj = pool.choosePieza();
        pos = new Vector3(pos.x, transform.position.y, 0);
        obj.transform.position = pos;

        if (activo)
        {
            if (ralentizador.ralentizar)
            {
                Invoke("activarObjeto", Random.Range(7f, 10f));
            }
            else
            {
                Invoke("activarObjeto", Random.Range(4f, 7f));
            }
        }

    }

    void OnEnable()
    {
        Invoke("activarObjeto", Random.Range(5f, 8f));
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
