using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    Partida partida;
    public Text aviso;

    // Start is called before the first frame update
    void Start()
    {
        partida = Partida.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }


    public void cambiarParacaidas(int paracaidas)
    {

        partida.user.paracaidas = paracaidas;

        if (!partida.estaSinConexion)
        {
            partida.actualizarBbdd();
        }
        ponerAviso("Paracaídas obtenido");
        
    }

    public void ponerAviso(string texto)
    {
        aviso.text = texto;
    }

}
