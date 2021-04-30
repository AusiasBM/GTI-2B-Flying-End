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

    CrearGameObject crear;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<CrearGameObject>();
        crear = gameObject.GetComponent<CrearGameObject>();
        Destroy(gameObject);

        Invoke("crearNube", Random.Range(2f, 3f));
    }


    void crearNube()
    {
        StartCoroutine(crear.crearObjeto(this.transform, nubes, rangoCreacion, false, true));
        Invoke("crearNube", Random.Range(2f, 5f));
    }
}
