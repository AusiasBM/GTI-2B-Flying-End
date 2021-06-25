using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[DefaultExecutionOrder(-500)]
public class ObjectPool : MonoBehaviour
{
    public GameObject[] prefab;
    public int[] listaPrioridades;

    public int amount = 5;

    protected Dictionary<GameObject, int> objetosPrioridades = new Dictionary<GameObject, int>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < prefab.Length; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                GameObject obj = Instantiate(prefab[i]);
                obj.SetActive(false);
                objetosPrioridades.Add(obj, listaPrioridades[i]);
            }
        }
            
    }

    public GameObject chooseWeigther()
    { 
        int count = 0;
        Dictionary<GameObject, int> objetosNoActivos = new Dictionary<GameObject, int>();

        foreach (KeyValuePair<GameObject, int> item in objetosPrioridades)
        {
            if (!item.Key.activeInHierarchy)
            {
                objetosNoActivos.Add(item.Key, item.Value); 
               
            }
                    
        }

        int total = objetosNoActivos.Sum(v => v.Value);
        int r = Random.Range(0, total);

        foreach (KeyValuePair<GameObject, int> item in objetosNoActivos)
        {
            count += item.Value;
            if (r < count)
            {
                item.Key.SetActive(true);
                return item.Key;
            }
        }

        return default(GameObject);
    }

    public void desactivarObjetos()
    {
        foreach (KeyValuePair<GameObject, int> item in objetosPrioridades)
        {
            if (item.Key.activeInHierarchy)
            {
                item.Key.SetActive(false);
            }
        }
    }


}

