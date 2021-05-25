using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    FirestoreManager firestoreManager;

    void Start()
    {
        firestoreManager = FirestoreManager.Instance;
    }


    void Update()
    {

    }
    public void CargarEscena(string nombreNivel)
    {
        Debug.Log(firestoreManager.user.Monedas);
        Debug.Log(firestoreManager.user.Diamantes);
        SceneManager.LoadScene(nombreNivel);
    }

}
