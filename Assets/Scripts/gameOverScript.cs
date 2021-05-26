using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameOverScript : MonoBehaviour
{
    //public GameObject GameOverText;
    public static GameObject GameOverStatic;

    FirestoreManager firestoreManager;

    void Start()
    {
        Debug.Log("HOLA3");
        firestoreManager = FirestoreManager.Instance;
        firestoreManager.guardarInformacionUsuario(firestoreManager.user.Uid, firestoreManager.user);
        
        firestoreManager.guardarPuntosUsuario(firestoreManager.score);
        //gameOverScript.GameOverStatic = GameOverText;
        //gameOverScript.GameOverStatic.SetActive(true);

    }


    void Update()
    {

    }

    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }



}
