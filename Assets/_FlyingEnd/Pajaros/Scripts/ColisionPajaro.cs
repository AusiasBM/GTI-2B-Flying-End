using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionPajaro : MonoBehaviour
{
    Jugador jugador;
    ControlSalud control;
    MovimientoObjeto movimiento;
    public GameObject particulasPajaro;

    public float fuerzaImpactoPajaro = 3f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        control = ControlSalud.Instance;
        jugador = Jugador.Instance;
        rb = jugador.GetComponent<Rigidbody>();
        movimiento = GetComponent<MovimientoObjeto>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (!jugador.isInmune)
        {
            control.quitarVida(1);
        }

       // GameObject particulas = generarParticulas(particulasPajaro, this.transform);
        if (movimiento.objetoBase.moveLeftToRight)
        {
            rb.AddForce(transform.right * fuerzaImpactoPajaro, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(transform.right * -fuerzaImpactoPajaro, ForceMode.Impulse);
        }

        jugador.generarParticulas(particulasPajaro, this.transform);

        gameObject.SetActive(false);
    }



}
