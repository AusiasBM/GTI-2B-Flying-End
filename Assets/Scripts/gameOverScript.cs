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
        scoreMetros.text = "Metros recorridos: " + gameController.ScoreMetros.ToString();
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
