using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomObjects : MonoBehaviour
{
    //Definició d'un mètode genèric que funcionarà amb tot tipus d'objectes
    //<T> per a utilitzar en tot tipus d'objectes (és genèric)
    //IList servix per a passar tant arrays com llistes (array més estricte i optimitzat, Llista més lax i fàcil d'adaptar)
    public static T Choose<T>(IList<T> array)
    {
        return array[Random.Range(0, array.Count)];
    }

    //Diccionaris classe de tipus genèric, i valor int (valor o pes ponderat)
    public static T ChooseWeigther<T>(Dictionary<T, int> pairs)
    {
        int total = pairs.Sum(v => v.Value);
        int r = Random.Range(0, total);
        int count = 0;

        foreach (KeyValuePair<T, int> item in pairs)
        {
            count += item.Value;
            if (r < count)
            {
                return item.Key;
            }
        }
        //No pot retornar null, retorna el valor per defecte d'un objecte qualsevol (el que siga T)
        return default(T);
    }
}
