using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearMonedas : MonoBehaviour
{
    public GameObject moneda;

    public float rangoCreacion = 8f;


    // Start is called before the first frame update
    void Start()
    {
        //Repetir la invocaci�n del m�todo crearPajaro cada cierto tiempo (tiempo inicial de espera de 2s)
        Invoke("crearMoneda", Random.Range(5f, 8f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void crearMoneda()
    {

        Vector3 spawnPos = new Vector3(0, 0, 0);

        // Definimos la posici�n random desde la que saldr� el pajaro 
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        spawnPos = this.transform.position + Random.onUnitSphere * rangoCreacion;

        //Crear la posici�n desde la que saldr� el pajaro que va a crearse. Solo variar� en el eje y, mientras que la del eje X es la del spawner
        spawnPos = new Vector3(spawnPos.x, this.transform.position.y, 0);

        //Crear una instancia del obejeto p�jaro en la posici�n definida
        GameObject monedas = Instantiate(moneda, spawnPos, Quaternion.identity);

        Invoke("crearMoneda", Random.Range(4f, 7f));

    }
}
