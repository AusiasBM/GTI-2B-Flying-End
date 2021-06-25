using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionIman : MonoBehaviour
{
    Jugador jugador;
    private sonidoItem sonidoitem;
    void Start()
    {
        jugador = Jugador.Instance;
        sonidoitem = jugador.GetComponent<sonidoItem>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        jugador.isMagnetic = true;
        jugador.efectoTemporal(10, 1);
        gameObject.SetActive(false);
        sonidoitem.emitir();
    }
}
