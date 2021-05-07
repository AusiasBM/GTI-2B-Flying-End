using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPiezas : MonoBehaviour
{
    private GameObject pieza;

    public float rangoCreacion = 8f;

    public GameObject[] piezasAvion;

    CrearGameObject crear;
    RalentizadorVelocidad ralentizador;

    void Start()
    {
        ralentizador = RalentizadorVelocidad.Instance;
        crear = CrearGameObject.Instance;

        //Repetir la invocación del método 
        Invoke("crearPiezaAvion", Random.Range(5f, 8f));
    }


    void crearPiezaAvion()
    {
        StartCoroutine(crear.crearObjeto(this.transform, piezasAvion, rangoCreacion, true, true));
        
        if (ralentizador.ralentizar)
        {
            Invoke("crearPiezaAvion", Random.Range(7f, 10f));
        }
        else
        {
            Invoke("crearPiezaAvion", Random.Range(4f, 7f));
        }
    }
}
