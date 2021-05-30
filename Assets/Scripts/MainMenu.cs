using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    FirestoreManager firestoreManager;

    public Text user;
    public Text moneda;
    public Text diamante;
    //public Text Distancia;
    void Start()
    {
        firestoreManager = FirestoreManager.Instance;

        Debug.Log(firestoreManager.user.Username + ", " + firestoreManager.user.Monedas.ToString() + ", " + firestoreManager.user.Diamantes.ToString());

        user.text = firestoreManager.user.Username;
        moneda.text = firestoreManager.user.Monedas.ToString();
        diamante.text = firestoreManager.user.Diamantes.ToString();
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
