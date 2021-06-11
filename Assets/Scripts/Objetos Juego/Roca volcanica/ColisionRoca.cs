using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionRoca : MonoBehaviour
{
    Jugador jugador;
    ControlSalud control;
   

    public GameObject particulasRoca;


    public float fuerzaImpactoRoca = 2f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
        jugador = Jugador.Instance;
        control = ControlSalud.Instance;
        rb = jugador.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!jugador.isInmune)
        {
            control.quitarVida(1);
        }

        

        jugador.generarParticulas(particulasRoca, this.transform);

        Debug.Log("IMPACTO!!");
        rb.AddForce(transform.up * +fuerzaImpactoRoca, ForceMode.Impulse);
        gameObject.SetActive(false);
    }
}
