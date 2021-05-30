using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/*Clase para controlar el gradiente del color en cada escenario*/

public class EfectosColorGrading : MonoBehaviour
{

    float saturacion;
    float temperatura;
    float tint;

    private static EfectosColorGrading instance;
    public static EfectosColorGrading Instance { get => instance; }

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
    ColorGrading color;
    // Start is called before the first frame update
    void Start()
    {
        color = ScriptableObject.CreateInstance<ColorGrading>();
        color.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, color);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Cambiar los parametros de saturación, temperatura y de tinte
    public IEnumerator cambiarParametros(float saturacion, float temperatura, float tint)
    {
        float sat = (saturacion - this.saturacion) /100;
        float tem = (temperatura - this.temperatura)/100;
        float ti = (tint - this.tint)/100;

        //Iniciar la transición de cada parametro (transición completada en 2 segundos)
        for(int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.02f);
            color.saturation.Override(color.saturation.value + sat);
            color.temperature.Override(color.temperature.value + tem);
            color.tint.Override(color.tint.value + ti);
            
        }

        this.saturacion = color.saturation.value;
        this.temperatura = color.temperature.value;
        this.tint = color.tint.value;
    }
}
