using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static bool gameP;
    public static bool boolSeguroP;

    public GameObject menuP, seguroP;

    public GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        menuP.SetActive(false);
        seguroP.SetActive(false);
    }

    public void SwitchPause()
    {
        if (gameP)
        {
            btnResume();
        }
        else
        {
            btnPause();
        }
    }

    void btnResume()
    {
        menuP.SetActive(false);
        Time.timeScale = 1;
        gameP = false;
    }

    void btnPause()
    {
        menuP.SetActive(true);
        Time.timeScale = 0;
        gameP = true;
    }

    public void mPrincipal(string name)
    {
        Destroy(jugador);
        SceneManager.LoadScene(name);
    }

    public void panel2()
    {
        seguroP.SetActive(true);
    }

    public void salirPno()
    {
        seguroP.SetActive(false);
    }

    public void salirPsi()
    {
        Application.Quit();
    }
}
