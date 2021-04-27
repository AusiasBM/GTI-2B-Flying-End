using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearNubesFondo : MonoBehaviour
{
    private GameObject nube;

    public GameObject[] nubes;
    public float rangoCreacion = 10f;
    public float posicionZ = 2f;


    // Start is called before the first frame update
    void Start()
    {
        //Repetir la invocaci�n del m�todo crearNube cada cierto tiempo 
        Invoke("crearNube", Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void crearNube()
    {
        nube = RandomObjects.Choose(nubes);

        Vector2 spawnPos = new Vector2(0, 0);

        // Definimos la posici�n random desde la que saldr� el pajaro 
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        spawnPos = Random.insideUnitCircle * rangoCreacion;

        //Crear la posici�n desde la que saldr� la nube que va a crearse
        Vector3 spawn = new Vector3(spawnPos.x, this.transform.position.y-20f, posicionZ);

        //Crear una instancia del obejeto en la posici�n definida
        Instantiate(nube, spawn, Quaternion.identity);

        Invoke("crearNube", Random.Range(4f, 6f));

    }
}
