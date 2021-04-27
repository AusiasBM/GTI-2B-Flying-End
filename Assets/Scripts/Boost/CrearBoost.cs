using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearBoost : MonoBehaviour
{
    //Puede ser moneda o diamante
    private GameObject boost;

    public GameObject[] listaBoost;
    public int[] listaPrioridades;

    private Dictionary<GameObject, int> boostPrioridades = new Dictionary<GameObject, int>();

    public float rangoCreacion = 8f;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < listaBoost.Length; i++)
        {
            boostPrioridades.Add(listaBoost[i], listaPrioridades[i]);
        }

        //Repetir la invocaci?n del m?todo crearPajaro cada cierto tiempo (tiempo inicial de espera de 2s)
        Invoke("crearBoost", Random.Range(5f, 7f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void crearBoost()
    {
        boost = RandomObjects.ChooseWeigther(boostPrioridades);

        Vector3 spawnPos = new Vector3(0, 0, 0);

        // Definimos la posici?n random desde la que saldr? el pajaro 
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci?n es el radio de la esfera)
        spawnPos = this.transform.position + Random.onUnitSphere * rangoCreacion;

        //Crear la posici?n desde la que saldr? el pajaro que va a crearse. Solo variar? en el eje y, mientras que la del eje X es la del spawner
        spawnPos = new Vector3(spawnPos.x, this.transform.position.y, 0);

        //Crear una instancia del obejeto p?jaro en la posici?n definida
        GameObject boosts = Instantiate(boost, spawnPos, Quaternion.identity);

        Invoke("crearBoost", Random.Range(5f, 7f));

    }
}
