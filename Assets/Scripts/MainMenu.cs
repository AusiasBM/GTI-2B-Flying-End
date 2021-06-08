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

    void Start()
    {

        partida = Partida.instance;
        Username.text = partida.user.username;
        Monedas.text = partida.user.monedas.ToString();
        Diamantes.text = partida.user.diamantes.ToString();

    }


    void Update()
    {

    }
    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

}
