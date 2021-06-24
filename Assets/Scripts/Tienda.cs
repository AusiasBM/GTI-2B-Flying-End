using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    Partida partida;
    public Text aviso;

    public Image paracaidasSeleccionado;
    public Text Monedas;
    public Text Diamantes;
    
    void Start()
    {
        partida = Partida.instance;

        Monedas.text = partida.user.monedas.ToString();
        Diamantes.text = partida.user.diamantes.ToString();
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
