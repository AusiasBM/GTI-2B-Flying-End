using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomObjects : MonoBehaviour
{
    //Definici� d'un m�tode gen�ric que funcionar� amb tot tipus d'objectes
    //<T> per a utilitzar en tot tipus d'objectes (�s gen�ric)
    //IList servix per a passar tant arrays com llistes (array m�s estricte i optimitzat, Llista m�s lax i f�cil d'adaptar)
    public static T Choose<T>(IList<T> array)
    {
        return array[Random.Range(0, array.Count)];
    }

    //Diccionaris classe de tipus gen�ric, i valor int (valor o pes ponderat)
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
