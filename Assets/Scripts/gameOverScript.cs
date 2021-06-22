using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour,ICounterValueContainer
{

    public static GameObject GameOverStatic;
    Partida partida;
    
    public GameController gameController;

    int frames = 0;
    int contadorMonedas = 0;

    public Text scoreMoneda;
    public Text scoreMetros;
    public Text scoreDiamantes;
    MusicaController musicaController;

    float mts = 0;
    void Start()
    {
        partida = Partida.instance;
        musicaController = MusicaController.instance;
        musicaController.audio.Stop();
        partida.actualizarDatosPartida();
        partida.guardarDistancia();

        gameController = GameController.Instance;
        gameController.cargarPuntuacion();

        
        
        if (gameController.ScoreMetros >= 1000)
        {
            mts =gameController.ScoreMetros / 1000;
            scoreMetros.text = mts.ToString("F2") + "km.";
        }
        else
        {
            mts = Mathf.Round(gameController.ScoreMetros);
            scoreMetros.text = mts.ToString() + "m.";
        }
        
        scoreDiamantes.text = gameController.ScoreDiamante.ToString();

       
        Debug.Log(gameController.ScoreMetros);
        Debug.Log(gameController.ScoreDiamante);
        Debug.Log(gameController.Score);
    }




    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
    
    public void musicaMenu()
    {
        musicaController.musicaMenu();

    }

    public int GetValue(string s)
    {
        //You can use the s string in a switch to return different values from the same script
        switch (s)
        {
            case "metros":
                return (int) gameController.ScoreMetros;
                break;

            case "monedas":
                return gameController.Score;
                break;
            case "diamantes":
                return gameController.ScoreDiamante;
                break;

            default:
                return 0;
                break;

        }


    }
}
