using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CrearGameObject : MonoBehaviour
{
    /*Método para crear objetos sin un factor de prioridad asociado.
      Se pasa por parámetros:
    - Transform del spawner desde donde se creará;
    - La lista (array o List) con los objetos que se crearán
    - El radio (float) desde del spawner desde doonde se creará de forma aleatoria
    - Si el objeto se puede crear con una rotación aleatoria respecto su eje y
    - Si el objeto se desplaza por el eje X (horizontal) o Y(vertical)
    - Tiempo de espera
    */

    public IEnumerator crearObjeto(Transform spawner, IList<GameObject> array, float radio, bool rotarObjeto, bool isVertical, float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);

        GameObject objeto = choose(array);

        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posición random desde la que saldrá
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreación es el radio de la esfera)
        pos = spawner.position + Random.onUnitSphere * radio;

        if (isVertical)
        {
            //Crear la posición desde la que saldrá. Solo variará en el eje x, mientras que la del eje y es la del spawner
            pos = new Vector3(pos.x, spawner.transform.position.y, 0);
        }
        else
        {
            pos = new Vector3(spawner.transform.position.x, pos.y, 0);
        }

        int rotacion = randomRotation(rotarObjeto);

        //Crear una instancia del obejeto en la posición definida
        Instantiate(objeto, pos, Quaternion.AngleAxis(rotacion, Vector3.up));
    }


    /*Método para crear objetos con un factor de prioridad asociado.
      Se pasa por parámetros:
    - Transform del spawner desde donde se creará;
    - El diccionario con los objetos y sus respectivas prioridades
    - El radio (float) desde del spawner desde doonde se creará de forma aleatoria
    - Si el objeto se desplaza por el eje X (horizontal) o Y(vertical)
    - Tiempo de espera
    */
    public IEnumerator crearObjetoPrioridad(Transform spawner, Dictionary<GameObject,int> pairs, float radio, bool isVertical, float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);

        GameObject objeto = chooseWeigther(pairs);

        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posición random desde la que saldrá 
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreación es el radio de la esfera)
        pos = spawner.position + Random.onUnitSphere * radio;

        if (isVertical)
        {
            //Crear la posición desde la que saldrá. Solo variará en el eje x, mientras que la del eje y es la del spawner
            pos = new Vector3(pos.x, spawner.transform.position.y, 0);
        }
        else
        {
            pos = new Vector3(spawner.transform.position.x, pos.y, 0);
        }
        

        //Crear una instancia del obejeto en la posición definida
        Instantiate(objeto, pos, Quaternion.identity);
    }

    private int randomRotation(bool rotate)
    {
        if (rotate)
        {
            int rotacion = Random.Range(-1, 2) * Random.Range(10, 45);

            if (rotacion < 0)
            {
                rotacion = 360 + rotacion;
            }

            return rotacion;
        }

        return 0;

    }

    //Definició d'un mètode genèric que funcionarà amb tot tipus d'objectes
    //<T> per a utilitzar en tot tipus d'objectes (és genèric)
    //IList servix per a passar tant arrays com llistes (array més estricte i optimitzat, Llista més lax i fàcil d'adaptar)
    public GameObject choose(IList<GameObject> array)
    {
        return array[Random.Range(0, array.Count)];
    }

    //Diccionaris classe de tipus genèric, i valor int (valor o pes ponderat)
    public GameObject chooseWeigther(Dictionary<GameObject, int> pairs)
    {
        int total = pairs.Sum(v => v.Value);
        int r = Random.Range(0, total);
        int count = 0;

        foreach (KeyValuePair<GameObject, int> item in pairs)
        {
            count += item.Value;
            if (r < count)
            {
                return item.Key;
            }
        }
        //No pot retornar null, retorna el valor per defecte d'un objecte qualsevol (el que siga T)
        return default(GameObject);
    }
}
