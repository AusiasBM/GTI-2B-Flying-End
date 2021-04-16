using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSalud : MonoBehaviour
{

    public Image barraSalud;

    [Range(0,1)]
    [SerializeField]
    private float salud = 1f;

    public float Salud
    {
        get
        {
            return salud;
        }

        set
        {
            salud = Mathf.Clamp01(value);
            if(salud == 0)
            {
                Destroy(gameObject);
            }
            barraSalud.fillAmount = salud;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PajaroDcha pajaroDcha = gameObject.GetComponent<PajaroDcha>();
        PajaroIzda pajaroIzda = gameObject.GetComponent<PajaroIzda>();
        PiezaAvion pieza = gameObject.GetComponent<PiezaAvion>();
        if (pajaroDcha != null)
        {
            Salud -= 0.25f;
            Debug.Log("Muere!!");
        }

    }
}
