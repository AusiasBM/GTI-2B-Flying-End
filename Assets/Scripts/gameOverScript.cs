using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameOverScript : MonoBehaviour
{
    public GameObject GameOverText;
    public static GameObject GameOverStatic;

    void Start()
    {
        gameOverScript.GameOverStatic = GameOverText;
        gameOverScript.GameOverStatic.SetActive(true);
 
    }

   
    void Update()
    {
        
    }

    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }



}
