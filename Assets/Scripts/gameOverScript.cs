using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour
{
    //public GameObject GameOverText;
    public static GameObject GameOverStatic;

    FirestoreManager firestoreManager;
    
    public GameController gameController;

    public Text scoreMoneda;
    public Text scoreMetros;
    public Text scoreDiamantes;

  

    float mts = 0;
    void Start()
    {
        firestoreManager = FirestoreManager.Instance;
        firestoreManager.guardarInformacionUsuario(firestoreManager.user.Uid, firestoreManager.user);
        
        firestoreManager.guardarPuntosUsuario(firestoreManager.score);
        //gameOverScript.GameOverStatic = GameOverText;
        //gameOverScript.GameOverStatic.SetActive(true);

        gameController = GameController.Instance;
        gameController.cargarPuntuacion();

        scoreMoneda.text = "Monedas recolectadas: " + gameController.Score.ToString();
        
        if (gameController.ScoreMetros >= 1000)
        {
            mts =gameController.ScoreMetros / 1000;
            scoreMetros.text = "Distancia recorrida: " + mts.ToString("F2") + "km.";
        }
        else
        {
            mts = Mathf.Round(gameController.ScoreMetros);
            scoreMetros.text = "Distancia recorrida: " + mts.ToString() + "m.";
        }
        
        scoreDiamantes.text = "Diamantes recolectados: " + gameController.ScoreDiamante.ToString();


       
        Debug.Log(gameController.ScoreMetros);
        Debug.Log(gameController.ScoreDiamante);
        Debug.Log(gameController.Score);
    }


    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }



}
