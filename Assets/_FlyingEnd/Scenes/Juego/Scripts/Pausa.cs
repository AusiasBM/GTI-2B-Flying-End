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

    public ControlSalud controlSalud;

    // Start is called before the first frame update
    void Start()
    {
        controlSalud = ControlSalud.Instance;
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
        //Destroy(jugador);
        controlSalud.quitarVida(controlSalud.salud + 1);
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
