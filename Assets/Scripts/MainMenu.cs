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
    public static MusicaController instance;
    void Start()
    {

        partida = Partida.instance;
        musicaController = MusicaController.instance;
       
        /* Username.text = partida.user.username;
         Monedas.text = partida.user.monedas.ToString();
         Diamantes.text = partida.user.diamantes.ToString();*/

    }


    public MusicaController Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        else
        {
            instance = MusicaController.instance;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {

    }
    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
    public void musicaJuego()
    {
        musicaController.musicajuego();

    }
}
