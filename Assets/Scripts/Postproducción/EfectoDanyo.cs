using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


/*Clase para crear el efecto de personaje herido al ser golpeado por algun objeto*/

public class EfectoDanyo : MonoBehaviour
{
    //Intensidad del "halo" que sale de las esquinas de la pantalla
    float intensidad = 0.5f;

    public bool golpe = false;
    float tiempoEfecto = 0f;


    private static EfectoDanyo instance;
    public static EfectoDanyo Instance { get => instance; }

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
    Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.intensity.Override(intensidad);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);

    }

    // Update is called once per frame
    void Update()
    {
        if (golpe)
        {
            vignette.enabled.Override(true);
            if (tiempoEfecto <= 1f)
            {
                //Con el coseno se crea un efecto de retorceso de la intensidad del "halo" 
                vignette.intensity.value = (Mathf.Cos(tiempoEfecto) * intensidad);
                tiempoEfecto += 0.01f;
            }
            else
            {
                tiempoEfecto = 0f;
                golpe = false;
                vignette.enabled.Override(false);
            }
        }
       
    }
}
