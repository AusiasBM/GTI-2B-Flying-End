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
        firestoreManager = FirestoreManager.Instance;
        firestoreManager.guardarInformacionUsuario(firestoreManager.user.Uid, firestoreManager.user);
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
