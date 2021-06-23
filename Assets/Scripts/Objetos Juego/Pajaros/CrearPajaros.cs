using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPajaros : MonoBehaviour
{
    private ObjectPool pool;

    public bool activo = true;

    RalentizadorVelocidad ralentizador;
    MaquinaFSM maquina;
    // Start is called before the first frame update
    void Start()
    {
        ralentizador = RalentizadorVelocidad.Instance;
        maquina = MaquinaFSM.Instance;
        pool = GetComponent<ObjectPool>();
    }

    void activarObjeto()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posici�n random desde la que saldr�
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        pos = transform.position + Random.onUnitSphere * 5.25f;

        GameObject obj = pool.chooseWeigther();
        pos = new Vector3(transform.position.x, pos.y, 0);
        obj.transform.position = pos;

        if (activo)
        {
            if (ralentizador.ralentizar)
            {
                Invoke("activarObjeto", Random.Range(8f, 10f));
            }
            else
            {
                Invoke("activarObjeto", Random.Range(2f, 5.0f));
            }
        }
    }

    void OnEnable()
    {
        Invoke("activarObjeto", Random.Range(4f, 5f));
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
