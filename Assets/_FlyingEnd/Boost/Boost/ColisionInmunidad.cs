using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionInmunidad : MonoBehaviour
{
    Jugador jugador;
    private sonidoItem sonidoitem;
    void Start()
    {
        jugador = Jugador.Instance;

        sonidoitem = jugador.GetComponent<sonidoItem>();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        jugador.isInmune = true;
        jugador.efectoTemporal(10, 2);
        gameObject.SetActive(false);
       sonidoitem.emitir();
    }
}
