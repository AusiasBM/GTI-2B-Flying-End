using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text Username;
    public Text Monedas;
    public Text Diamantes;
    Partida partida;
    MusicaController musicaController;

    public GameObject ranking;


    void Start()
    {

        partida = Partida.instance;
        musicaController = MusicaController.instance;
        Username.text = partida.user.nombre;
        cargarRanking();
        //Monedas.text = partida.user.monedas.ToString();
        //Diamantes.text = partida.user.diamantes.ToString();

        if (partida.estaSinConexion)
        {
            ranking.GetComponent<Button>().enabled = false;
            ranking.GetComponent<Image>().color = Color.gray;
        }
    }

    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
    public void musicaJuego()
    {
        musicaController.musicajuego();

    }

    public void cargarRanking()
    {
        partida.cargarRanking();
    }
    public void musicaA()
    {
        musicaController.musicajuego();
    }
}
