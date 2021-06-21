using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBoostVida : MonoBehaviour
{

    ControlSalud controlSalud;
    private sonidoItem sonidoitem;
    Jugador jugador;

    void Start()
    {
        jugador = Jugador.Instance;
        controlSalud = ControlSalud.Instance;
        sonidoitem = jugador.GetComponent<sonidoItem>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        controlSalud.ganarVida(2);
        gameObject.SetActive(false);
        sonidoitem.emitir();
    }

}
