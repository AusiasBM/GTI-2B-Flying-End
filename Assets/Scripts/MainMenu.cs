using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    FirestoreManager firestoreManager;

    public Text Username;
    public Text Monedas;
    public Text Diamantes;

    void Start()
    {
        firestoreManager = FirestoreManager.Instance;
        Debug.Log(string.Format("Nom usuari", firestoreManager.user.Username));

        Username.text = firestoreManager.user.Username;
        Monedas.text = firestoreManager.user.Monedas.ToString();
        Diamantes.text = firestoreManager.user.Diamantes.ToString();

    }


    void Update()
    {

    }
    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

}
