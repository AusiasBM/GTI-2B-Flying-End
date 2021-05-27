using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameOverScript : MonoBehaviour
{
    //public GameObject GameOverText;
    public static GameObject GameOverStatic;

    FirestoreManager firestoreManager;

    public GameController gameController;

    public GameObject scoreMoneda;
    public GameObject scoreMetros;
    public GameObject scoreDiamantes;

    public string scoreMonedaString = "";
    public string scoreMetrosString = "";
    public string scoreDiamantesString = "";

    void Start()
    {
        Debug.Log("HOLA3");
        firestoreManager = FirestoreManager.Instance;
        firestoreManager.guardarInformacionUsuario(firestoreManager.user.Uid, firestoreManager.user);
        
        firestoreManager.guardarPuntosUsuario(firestoreManager.score);
        //gameOverScript.GameOverStatic = GameOverText;
        //gameOverScript.GameOverStatic.SetActive(true);

        gameController = GameController.Instance;
        gameController.cargarPuntuacion();

        scoreMoneda = new GameObject(scoreMonedaString);
        scoreMetros = new GameObject(scoreMetrosString);
        scoreDiamantes = new GameObject(scoreDiamantesString);


        scoreMetrosString = "Metros recorridos: " + gameController.ScoreMetros;
        scoreMonedaString = "Monedas recolectadas: " + gameController.Score;
        scoreMetrosString = "Diamantes recolectados: " + gameController.ScoreDiamante;

        Debug.Log(gameController.ScoreMetros);
        Debug.Log(gameController.ScoreDiamante);
        Debug.Log(gameController.Score);
    }


    void Update()
    {

    }

    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }



}
