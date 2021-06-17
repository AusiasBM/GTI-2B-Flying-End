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
    void Start()
    {

        partida = Partida.instance;
        musicaController = MusicaController.instance;
        Username.text = partida.user.username;
        Monedas.text = partida.user.monedas.ToString();
        Diamantes.text = partida.user.diamantes.ToString();

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
