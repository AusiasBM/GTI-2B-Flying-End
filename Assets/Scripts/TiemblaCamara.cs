using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiemblaCamara : MonoBehaviour
{
    public Animator AnimacionCamara;
    // Start is called before the first frame update
    private static TiemblaCamara instance;

    public static TiemblaCamara Instance { get => instance; }

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

    public void CamTiembla()
    {
        //Adquiere tiembla
        AnimacionCamara.SetTrigger("CamaraTiembla");
    }
}
