using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlSalud : MonoBehaviour
{
    FirestoreManager firestoreManager;
    EfectoDanyo efectoDanyo;
    GameController gameController;
    public GameObject vida;
    private Image barraSalud;
    private int salud = 9;

    //Metodo para quitar vida cuando impacte un objeto o pajaro
    public void quitarVida(int vidaMenos)
    {
        efectoDanyo.golpe = true;
        salud = salud - vidaMenos;

        if (salud <= 0)
        {
            Destroy(gameObject);
            firestoreManager.user.Monedas += gameController.Score;
            firestoreManager.user.Diamantes += gameController.ScoreDiamante;

            //Si la distancia recorrida es mayor a la última más alta se guarda esta
            if(firestoreManager.user.Distancia < (int)gameController.ScoreMetros)
            {
                firestoreManager.user.Distancia = (int)gameController.ScoreMetros;
            }
            
            firestoreManager.score = new Score
            {
                Username = firestoreManager.user.Username,
                Uid = firestoreManager.user.Uid,
                Puntos = (int)gameController.ScoreMetros
            };
            //firestoreManager.score.Puntos = (int)gameController.ScoreMetros;
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
        efectoDanyo = EfectoDanyo.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
}