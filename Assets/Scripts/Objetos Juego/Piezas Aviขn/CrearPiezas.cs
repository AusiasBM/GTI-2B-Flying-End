using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPiezas : MonoBehaviour
{
    private GameObject pieza;

    public float rangoCreacion = 8f;
    public bool ralentizar = false;

    public GameObject[] piezasAvion;

    CrearGameObject crear;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<CrearGameObject>();
        crear = gameObject.GetComponent<CrearGameObject>();
        Destroy(gameObject);

        //Repetir la invocación del método 
        Invoke("crearPiezaAvion", Random.Range(5f, 8f));
    }


    void crearPiezaAvion()
    {
        StartCoroutine(crear.crearObjeto(this.transform, piezasAvion, rangoCreacion, true, true));
        
        if (ralentizar)
        {
            Invoke("crearPiezaAvion", Random.Range(7f, 10f));
        }
        else
        {
            Invoke("crearPiezaAvion", Random.Range(4f, 7f));
        }
    }
}
