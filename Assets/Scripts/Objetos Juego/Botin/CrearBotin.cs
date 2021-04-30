using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearBotin : MonoBehaviour
{
    //Puede ser moneda o diamante
    private GameObject botin;

    public GameObject[] listaBotin;
    public int[] listaPrioridades;

    private Dictionary<GameObject, int> botinPrioridades = new Dictionary<GameObject, int>();

    public float rangoCreacion = 8f;

    CrearGameObject crear;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<CrearGameObject>();
        crear = gameObject.GetComponent<CrearGameObject>();
        Destroy(gameObject);

        for (int i = 0; i < listaBotin.Length; i++)
        {
            botinPrioridades.Add(listaBotin[i], listaPrioridades[i]);
        }

        //Repetir la invocación del método crearPajaro cada cierto tiempo (tiempo inicial de espera de 2s)
        Invoke("crearBotin", Random.Range(5f, 8f));
    }


    void crearBotin()
    {
        StartCoroutine(crear.crearObjetoPrioridad(this.transform, botinPrioridades, rangoCreacion, true));
        Invoke("crearBotin", Random.Range(1f, 2f));

    }

}
