using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPajaros : MonoBehaviour
{
    private GameObject pajaro;

    public GameObject[] listaPajaros;
    public int[] listaPrioridades;

    //Radio de la circunferencia
    public float rangoCreacion = 5.25f;
    public bool ralentizar = false;

    private Dictionary<GameObject, int> pajarosPrioridades = new Dictionary<GameObject, int>();

    CrearGameObject crear;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<CrearGameObject>();
        crear = gameObject.GetComponent<CrearGameObject>();
        Destroy(gameObject);

        for (int i = 0; i < listaPajaros.Length; i++)
        {
            pajarosPrioridades.Add(listaPajaros[i], listaPrioridades[i]);
        }

        //Repetir la invocaci�n del m�todo 
        Invoke("crearPajaro", Random.Range(2f, 3.5f));
    }


    void crearPajaro()
    {
        StartCoroutine(crear.crearObjetoPrioridad(this.transform, pajarosPrioridades, rangoCreacion, false));
        if (ralentizar)
        {
            Invoke("crearPajaro", Random.Range(8f, 10f));
        }
        else
        {
            Invoke("crearPajaro", Random.Range(2f, 5.0f));
        }

    }

}