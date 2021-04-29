using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;


public class CrearNubes : MonoBehaviour
{
    private GameObject nube;

    public GameObject[] nubes;
    public float rangoCreacion = 8f;

    CrearGameObject crear = new CrearGameObject();
    // Start is called before the first frame update
    void Start()
    {
        Invoke("crearNube", Random.Range(2f, 3f));
    }


    void crearNube()
    {
        StartCoroutine(crear.crearObjeto(this.transform, nubes, rangoCreacion, false, 1f));
        Invoke("crearNube", Random.Range(2f, 5f));
    }
}
