using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrerNubeElectrica : MonoBehaviour
{
    private GameObject nubeElectrica;

    public GameObject[] nubesElectricas;
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

        Invoke("crearNubeElectrica", Random.Range(2f, 3f));
    }


    void crearNubeElectrica()
    {
        StartCoroutine(crear.crearObjeto(this.transform, nubesElectricas, rangoCreacion, false, true));
        if (activo) Invoke("crearNubeElectrica", Random.Range(2f, 5f));
    }
}
