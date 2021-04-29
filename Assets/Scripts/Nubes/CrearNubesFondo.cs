using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearNubesFondo : MonoBehaviour
{
    private GameObject nube;

    public GameObject[] nubes;
    public float rangoCreacion = 10f;
    public float posicionZ = 2f;

    CrearGameObject crear = new CrearGameObject();
    // Start is called before the first frame update
    void Start()
    {
        //Repetir la invocación del método crearNube cada cierto tiempo 
        Invoke("crearNube", Random.Range(0f, 1f));
    }

    void crearNube()
    {
        StartCoroutine(crear.crearObjeto(this.transform, nubes, rangoCreacion, false, true, 1f));
        Invoke("crearNube", Random.Range(4f, 6f));
    }
}
