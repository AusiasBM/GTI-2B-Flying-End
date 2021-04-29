using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CrearGameObject : MonoBehaviour
{
    /*M�todo para crear objetos sin un factor de prioridad asociado.
      Se pasa por par�metros:
    - Transform del spawner desde donde se crear�;
    - La lista (array o List) con los objetos que se crear�n
    - El radio (float) desde del spawner desde doonde se crear� de forma aleatoria
    - Si el objeto se puede crear con una rotaci�n aleatoria respecto su eje y
    - Si el objeto se desplaza por el eje X (horizontal) o Y(vertical)
    - Tiempo de espera
    */

    public IEnumerator crearObjeto(Transform spawner, IList<GameObject> array, float radio, bool rotarObjeto, bool isVertical, float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);

        GameObject objeto = choose(array);

        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posici�n random desde la que saldr�
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        pos = spawner.position + Random.onUnitSphere * radio;

        if (isVertical)
        {
            //Crear la posici�n desde la que saldr�. Solo variar� en el eje x, mientras que la del eje y es la del spawner
            pos = new Vector3(pos.x, spawner.transform.position.y, 0);
        }
        else
        {
            pos = new Vector3(spawner.transform.position.x, pos.y, 0);
        }

        int rotacion = randomRotation(rotarObjeto);

        //Crear una instancia del obejeto en la posici�n definida
        Instantiate(objeto, pos, Quaternion.AngleAxis(rotacion, Vector3.up));
    }


    /*M�todo para crear objetos con un factor de prioridad asociado.
      Se pasa por par�metros:
    - Transform del spawner desde donde se crear�;
    - El diccionario con los objetos y sus respectivas prioridades
    - El radio (float) desde del spawner desde doonde se crear� de forma aleatoria
    - Si el objeto se desplaza por el eje X (horizontal) o Y(vertical)
    - Tiempo de espera
    */
    public IEnumerator crearObjetoPrioridad(Transform spawner, Dictionary<GameObject,int> pairs, float radio, bool isVertical, float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);

        GameObject objeto = chooseWeigther(pairs);

        Vector3 pos = new Vector3(0, 0, 0);

        // Definimos la posici�n random desde la que saldr� 
        // Random.onUnitSphere * rangoCreacion elige un punto dentro de una esfera (rangoCreaci�n es el radio de la esfera)
        pos = spawner.position + Random.onUnitSphere * radio;

        if (isVertical)
        {
            //Crear la posici�n desde la que saldr�. Solo variar� en el eje x, mientras que la del eje y es la del spawner
            pos = new Vector3(pos.x, spawner.transform.position.y, 0);
        }
        else
        {
            pos = new Vector3(spawner.transform.position.x, pos.y, 0);
        }
        

        //Crear una instancia del obejeto en la posici�n definida
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

    //Definici� d'un m�tode gen�ric que funcionar� amb tot tipus d'objectes
    //<T> per a utilitzar en tot tipus d'objectes (�s gen�ric)
    //IList servix per a passar tant arrays com llistes (array m�s estricte i optimitzat, Llista m�s lax i f�cil d'adaptar)
    public GameObject choose(IList<GameObject> array)
    {
        return array[Random.Range(0, array.Count)];
    }

    //Diccionaris classe de tipus gen�ric, i valor int (valor o pes ponderat)
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
