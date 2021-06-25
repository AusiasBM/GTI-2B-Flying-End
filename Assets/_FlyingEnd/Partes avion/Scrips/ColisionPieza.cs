using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionPieza : MonoBehaviour
{
    Jugador jugador;
    ControlSalud control;
    TiemblaCamara tiembla;

    public GameObject particulasAvion;


    public float fuerzaImpactoPieza = 2f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        tiembla = TiemblaCamara.Instance;
        jugador = Jugador.Instance;
        control = ControlSalud.Instance;        
        rb = jugador.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!jugador.isInmune)
        {
            control.quitarVida(2);
        }

        tiembla.CamTiembla();
 
        jugador.generarParticulas(particulasAvion, this.transform);

        Debug.Log("IMPACTO!!");
        rb.AddForce(transform.up * -fuerzaImpactoPieza, ForceMode.Impulse);
        gameObject.SetActive(false);
    }

}
