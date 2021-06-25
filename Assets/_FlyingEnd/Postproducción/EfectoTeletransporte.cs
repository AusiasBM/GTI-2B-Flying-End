using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


/*Clase para crear el efecto de personaje herido al ser golpeado por algun objeto*/

public class EfectoTeletransporte : MonoBehaviour
{
    //Intensidad del "halo" que sale de las esquinas de la pantalla
    float intensidadBloom = 75f;
    float intensidadChrom = 1f;

    public bool teletransportando = false;
    bool efectoSecundario = false;

    float tiempoEfecto = 0f;


    private static EfectoTeletransporte instance;
    public static EfectoTeletransporte Instance { get => instance; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    PostProcessVolume m_Volume;
    PostProcessVolume m_Volume2;
    Bloom bloom;
    ChromaticAberration chromatic;
    // Start is called before the first frame update
    void Start()
    {
        bloom = ScriptableObject.CreateInstance<Bloom>();
        chromatic = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromatic.intensity.Override(intensidadChrom);
        bloom.intensity.Override(intensidadBloom);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, bloom);
        m_Volume2 = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, chromatic);

    }

    // Update is called once per frame
    void Update()
    {
        if (teletransportando)
        {
            bloom.enabled.Override(true);
            chromatic.enabled.Override(true);
            if (tiempoEfecto <= Mathf.PI)
            {
                bloom.intensity.value = (Mathf.Sin(tiempoEfecto) * intensidadBloom);
                tiempoEfecto += 0.035f;
            }
            else
            {
                tiempoEfecto = 0f;
                teletransportando = false;
                efectoSecundario = true;
                bloom.enabled.Override(false);
            }
        }

        if (efectoSecundario)
        {
            chromatic.enabled.Override(true);
            if (tiempoEfecto <= 2)
            {
                chromatic.intensity.value = Mathf.Cos(tiempoEfecto);
                tiempoEfecto += 0.02f;
            }
            else
            {
                tiempoEfecto = 0f;
                efectoSecundario = false;
                chromatic.enabled.Override(false);
            }

        }

    }
}