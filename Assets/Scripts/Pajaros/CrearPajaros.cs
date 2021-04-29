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

    private Dictionary<GameObject, int> pajarosPrioridades = new Dictionary<GameObject, int>();

    CrearGameObject crear = new CrearGameObject();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < listaPajaros.Length; i++)
        {
            pajarosPrioridades.Add(listaPajaros[i], listaPrioridades[i]);
        }

        //Repetir la invocación del método 
        Invoke("crearPajaro", Random.Range(2f, 3.5f));
    }


    void crearPajaro()
    {
        StartCoroutine(crear.crearObjetoPrioridad(this.transform, pajarosPrioridades, rangoCreacion, 1));
        Invoke("crearPajaro", Random.Range(2f, 5.0f));

    }

}
