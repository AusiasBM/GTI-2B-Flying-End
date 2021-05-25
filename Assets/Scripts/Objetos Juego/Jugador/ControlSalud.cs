using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlSalud : MonoBehaviour
{
    FirestoreManager firestoreManager;
    GameController gameController;
    public GameObject vida;
    private Image barraSalud;
    private int salud = 9;

    //Metodo para quitar vida cuando impacte un objeto o pajaro
    public void quitarVida(int vidaMenos)
    {

        salud = salud - vidaMenos;

        if (salud <= 0)
        {
            Destroy(gameObject);
            firestoreManager.user.Monedas += gameController.Score;
            firestoreManager.user.Diamantes += gameController.ScoreDiamante;
            SceneManager.LoadScene("GameOver");
        }

        barraSalud.sprite = Resources.Load<Sprite>("Sprites/Hud/Vida/vida" + salud);
    }

    //Metodo para ganar vida al coger el boost de vida
    public void ganarVida(int vidaMas)
    {
        if (salud < 9)
        {
            if ((salud + vidaMas) < 9)
            {
                salud += vidaMas;
            }
            else
            {
                salud = 9;
            }
            barraSalud.sprite = Resources.Load<Sprite>("Sprites/Hud/Vida/vida" + salud);

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
        barraSalud = vida.GetComponent<Image>();
        firestoreManager = FirestoreManager.Instance;
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
}