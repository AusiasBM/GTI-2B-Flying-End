using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlSalud : MonoBehaviour
{
    EfectoDanyo efectoDanyo;
    GameController gameController;
    public GameObject vida;
    private float salud = 10;

    //Metodo para quitar vida cuando impacte un objeto o pajaro
    public void quitarVida(float vidaMenos)
    {
        efectoDanyo.golpe = true;
        salud = salud - vidaMenos;

        if (salud <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }

        vida.GetComponent<Image>().fillAmount = salud/10;
    }

    //Metodo para ganar vida al coger el boost de vida
    public void ganarVida(float vidaMas)
    {
        if (salud < 10)
        {
            if ((salud + vidaMas) < 10)
            {
                salud += vidaMas;
            }
            else
            {
                salud = 10;
            }
            vida.GetComponent<Image>().fillAmount = salud/10;

        }
        Debug.Log(salud);
    }

    private static ControlSalud instance;
    public static ControlSalud Instance { get => instance; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.Instance;
        efectoDanyo = EfectoDanyo.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
}