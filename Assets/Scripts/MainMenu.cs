using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    FirestoreManager firestoreManager;

    public Text Username;
    public string user;
    //public Text Distancia;
    void Start()
    {
        firestoreManager = FirestoreManager.Instance;
        Debug.Log(string.Format("Nom usuari", firestoreManager.user.Username));

        Username.text = firestoreManager.user.Username;
        user = firestoreManager.user.Username;
        //Distancia.text = firestoreManager.user.Distancia.ToString();
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
