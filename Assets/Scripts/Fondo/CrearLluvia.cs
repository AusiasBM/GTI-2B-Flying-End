using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearLluvia : MonoBehaviour
{
    private GameObject GeneradorLluvia;

    public GameObject[] lluvias;
    public float rangoCreacion = 10f;
    public bool activo = true;

    CrearGameObject crear;
    // Start is called before the first frame update
    void Start()
    {
        crear = CrearGameObject.Instance;

        Invoke("crearLluvia", Random.Range(0f,1f));
    }


    void crearLluvia()
    {
        StartCoroutine(crear.crearObjeto(this.transform, lluvias, rangoCreacion, false, true));
        if (activo) Invoke("crearLluvia", Random.Range(0f,1f));
    }
}
