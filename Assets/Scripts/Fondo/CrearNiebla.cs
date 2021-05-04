using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearNiebla : MonoBehaviour
{
    private GameObject niebla;

    public GameObject[] nieblas;
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

        Invoke("crearNiebla", Random.Range(2f, 3f));
    }


    void crearNiebla()
    {
        StartCoroutine(crear.crearObjeto(this.transform, nieblas, rangoCreacion, false, true));
        if(activo) Invoke("crearNiebla", Random.Range(2f, 5f));
    }
}
