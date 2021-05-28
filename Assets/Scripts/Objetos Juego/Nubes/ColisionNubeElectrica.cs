using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionNubeElectrica : MonoBehaviour
{
    Jugador jugador;
    ControlSalud control;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        jugador = Jugador.Instance;
        control = ControlSalud.Instance;
        rb = jugador.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {
        if (!jugador.isInmune)
        {
            control.quitarVida(1);
        }



   
    }
}
