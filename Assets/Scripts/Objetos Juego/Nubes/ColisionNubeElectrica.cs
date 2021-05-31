using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionNubeElectrica : MonoBehaviour
{
    Jugador jugador;
    ControlSalud control;
    public float fuerzaImpactoPieza = 2f;
    TiemblaCamara tiembla;
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
            control.quitarVida(1);
        }

        tiembla.CamTiembla();

        

        Debug.Log("IMPACTO!!");
        rb.AddForce(transform.right * -fuerzaImpactoPieza, ForceMode.Impulse);
        Destroy(gameObject);
        

    }
}
