using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;


public class CrearRocas : MonoBehaviour
{
    private GameObject roca;

    public GameObject[] rocas;
    public float rangoCreacion = 8f;
    public bool activo = true;

    CrearGameObject crear;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<CrearGameObject>();
        crear = gameObject.GetComponent<CrearGameObject>();
        Destroy(gameObject);

        Invoke("crearRoca", Random.Range(2f, 3f));
    }


    void crearRoca()
    {
        StartCoroutine(crear.crearObjeto(this.transform, rocas, rangoCreacion, false, true));
        if (activo) Invoke("crearRoca", Random.Range(2f, 5f));
    }
}
