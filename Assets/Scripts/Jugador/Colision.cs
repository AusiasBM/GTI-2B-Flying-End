using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Colision : MonoBehaviour
{
    public int puntuacion = 20;

    public Image barraSalud;

    public float fuerzaImpactoPajaro = 3f;
    public float fuerzaImpactoPieza = 2f;

    [Range(0, 1)]
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
            if (salud == 0)
            {
                Destroy(gameObject);
            }
            barraSalud.fillAmount = salud;
        }
    }

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Moneda moneda = collision.gameObject.GetComponent<Moneda>();
        PiezaAvion pieza = collision.gameObject.GetComponent<PiezaAvion>();
        PajaroDcha pD = collision.gameObject.GetComponent<PajaroDcha>();
        PajaroIzda pI = collision.gameObject.GetComponent<PajaroIzda>();

        if (moneda != null)
        {
            GameController.Score += puntuacion;
            Debug.Log("MONEDA!!");
            Destroy(collision.gameObject);
        }

        if (pieza != null)
        {
            Salud -= 0.10f;
            Debug.Log("IMPACTO!!");
            rb.AddForce(transform.up * -fuerzaImpactoPieza, ForceMode.Impulse);
            Destroy(collision.gameObject);
        }

        if (pD != null)
        {
            Salud -= 0.10f;
            Debug.Log("IMPACTO!!");
            rb.AddForce(transform.right * -fuerzaImpactoPajaro, ForceMode.Impulse);
            Destroy(collision.gameObject);
        }

        if (pI != null)
        {
            Salud -= 0.10f;
            Debug.Log("IMPACTO!!");
            rb.AddForce(transform.right* fuerzaImpactoPajaro, ForceMode.Impulse);
            Destroy(collision.gameObject);
        }



    }


    private void OnTriggerEnter(Collider other)
    {
        
    }


}



