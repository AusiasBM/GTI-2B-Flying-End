using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearBoost : MonoBehaviour
{
    public GameObject[] listaBoost;
    public int[] listaPrioridades;

    private Dictionary<GameObject, int> boostPrioridades = new Dictionary<GameObject, int>();

    public float rangoCreacion = 8f;

    CrearGameObject crear = new CrearGameObject();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < listaBoost.Length; i++)
        {
            boostPrioridades.Add(listaBoost[i], listaPrioridades[i]);
        }

        //Repetir la invocaci?n del m?todo 
        Invoke("crearBoost", Random.Range(15f, 20f));
    }


    void crearBoost()
    {
        StartCoroutine(crear.crearObjetoPrioridad(this.transform, boostPrioridades, rangoCreacion, 1));
        Invoke("crearBoost", Random.Range(15f, 20f));
    }
}
