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

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < listaPajaros.Length; i++)
        {
            pajarosPrioridades.Add(listaPajaros[i], listaPrioridades[i]);
        }

        //Repetir la invocaci�n del m�todo crearPajaro cada cierto tiempo (tiempo inicial de espera de 2s)
        Invoke("crearPajaro", Random.Range(2f, 3.5f));

    }

    // Update is called once per frame
    void Update()
    {

    }

    void crearPajaro()
    {
        pajaro = RandomObjects.ChooseWeigther(pajarosPrioridades);

        Vector3 spawnPos = new Vector3(0, 0, 0);

        // Definimos la posici�n random desde la que saldr� el pajaro 
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        spawnPos = this.transform.position + Random.onUnitSphere * rangoCreacion;

        //Crear la posici�n desde la que saldr� el pajaro que va a crearse. Solo variar� en el eje y, mientras que la del eje X es la del spawner
        spawnPos = new Vector3(this.transform.position.x, spawnPos.y, 0);

        //Crear una instancia del obejeto p�jaro en la posici�n definida
        GameObject pajaros = Instantiate(pajaro, spawnPos, Quaternion.identity);

        Invoke("crearPajaro", Random.Range(2f, 5.0f));

    }

}
