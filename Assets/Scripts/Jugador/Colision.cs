using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Colision : MonoBehaviour
{
    public int puntuacion = 20;

    public Image barraSalud;

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

    private void OnCollisionEnter(Collision collision)
    {
        Moneda moneda = collision.gameObject.GetComponent<Moneda>();
        if (moneda != null)
        {
            GameController.Score += puntuacion;
            Debug.Log("MONEDA!!");
            Destroy(collision.gameObject);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Salud -= 0.10f;
        Debug.Log("IMPACTO!!");
    }


}



