using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPiezas : MonoBehaviour
{
    private GameObject pieza;

    public float rangoCreacion = 8f;

    public GameObject[] piezasAvion;

    // Start is called before the first frame update
    void Start()
    {
        //Repetir la invocaci�n del m�todo crearPajaro cada cierto tiempo (tiempo inicial de espera de 2s)
        Invoke("crearPiezaAvion", Random.Range(5f, 8f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void crearPiezaAvion()
    {
        pieza = RandomObjects.Choose(piezasAvion);

        Vector3 spawnPos = new Vector3(0, 0, 0);

        // Definimos la posici�n random desde la que saldr� el pajaro 
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        spawnPos = this.transform.position + Random.onUnitSphere * rangoCreacion;

        //Crear la posici�n desde la que saldr� el pajaro que va a crearse. Solo variar� en el eje y, mientras que la del eje X es la del spawner
        spawnPos = new Vector3(spawnPos.x, this.transform.position.y, 0);


        int rotacion = Random.Range(-1, 2) * Random.Range(10, 45);

        if (rotacion < 0)
        {
            rotacion = 360 + rotacion;
        }

        //Crear una instancia del obejeto p�jaro en la posici�n definida
        GameObject piezas = Instantiate(pieza, spawnPos, Quaternion.AngleAxis(rotacion, Vector3.up));

        Invoke("crearPiezaAvion", Random.Range(4f, 7f));
    }
}
