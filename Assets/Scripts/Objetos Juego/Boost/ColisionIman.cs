using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionIman : MonoBehaviour
{
    Jugador jugador;

    void Start()
    {
        jugador = Jugador.Instance;
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        jugador.isMagnetic = true;
        jugador.efectoTemporal(10);
        Destroy(gameObject);
    }
}