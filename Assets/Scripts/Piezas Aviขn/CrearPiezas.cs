using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPiezas : MonoBehaviour
{
    private GameObject pieza;

    public float rangoCreacion = 8f;

    public GameObject[] piezasAvion;

    CrearGameObject crear = new CrearGameObject();
    // Start is called before the first frame update
    void Start()
    {
        //Repetir la invocación del método 
        Invoke("crearPiezaAvion", Random.Range(5f, 8f));
    }


    void crearPiezaAvion()
    {
        StartCoroutine(crear.crearObjeto(this.transform, piezasAvion, rangoCreacion, true, 1f));
        Invoke("crearPiezaAvion", Random.Range(4f, 7f));
    }
}
