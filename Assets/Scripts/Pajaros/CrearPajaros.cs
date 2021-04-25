using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPajaros : MonoBehaviour
{

    public GameObject pajaro;
    public GameObject pajaroLento;
    public GameObject pajaroRapido;

    //Radio de la circunferencia
    public float rangoCreacion = 5.25f;


    // Start is called before the first frame update
    void Start()
    {
        //Repetir la invocaci�n del m�todo crearPajaro cada cierto tiempo (tiempo inicial de espera de 2s)
        Invoke("crearPajaro", Random.Range(2f, 3.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void crearPajaro()
    {
        
        Vector3 spawnPos = new Vector3(0, 0, 0);

        // Definimos la posici�n random desde la que saldr� el pajaro 
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        spawnPos = this.transform.position + Random.onUnitSphere * rangoCreacion;

        //Crear la posici�n desde la que saldr� el pajaro que va a crearse. Solo variar� en el eje y, mientras que la del eje X es la del spawner
        spawnPos = new Vector3(this.transform.position.x, spawnPos.y, 0);

        //Crear una instancia del obejeto p�jaro en la posici�n definida
        randomPajaro(spawnPos);

        Invoke("crearPajaro", Random.Range(2f, 5.0f));
        
    }
    GameObject randomPajaro(Vector3 spawnPos)
    {
        
        switch (Random.Range(1, 4))
        {
            case 1: GameObject pajaros = Instantiate(pajaro, spawnPos, Quaternion.identity);
                return pajaros;
            case 2: GameObject pajarosLentos = Instantiate(pajaroLento, spawnPos, Quaternion.identity);
                return pajarosLentos;
            case 3: GameObject pajarosRapidos = Instantiate(pajaroRapido, spawnPos, Quaternion.identity);
                return pajarosRapidos;
            default: return null;
        }
    }

}
