using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalentizadorVelocidad : MonoBehaviour
{
    public bool ralentizar = false;
    public float velocidadRalentizada = 1f;

    private static RalentizadorVelocidad instance;

    public static RalentizadorVelocidad Instance { get => instance; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ralentizarObjetos(bool isRalentizado)
    {
        ralentizar = isRalentizado;
        StartCoroutine(delayTiempo(10));
    }

    IEnumerator delayTiempo(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        ralentizar = false;
    }
}
