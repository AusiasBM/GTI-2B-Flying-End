using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public int Score = 0;
    public int ScoreDiamante = 0;
    public float ScoreMetros = 0f;

    private string scoreSave="Score";
    private string scoreDiamanteSave="Diamantes";
    private string scoreMetrosSave="Metros";

    public Text TextScore;
    public Text TextScoreDiamante;
    public Text TextScoreMetros;

    public Text Username;

    MusicaController musicaController;

    Partida partida;

    public GameObject paracaidas0;
    public GameObject paracaidas1;
    public GameObject paracaidas2;

    private static GameController instance;
    public static GameController Instance { get => instance; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        paracaidas0.SetActive(false);
        paracaidas1.SetActive(false);
        paracaidas2.SetActive(false);

        musicaController = MusicaController.instance;

        partida = Partida.instance;
        Username.text = partida.user.nombre;

        
        if (partida.user.paracaidas == 0)
        {
            paracaidas0.SetActive(true);
        }
        if (partida.user.paracaidas == 1)
        {
            paracaidas1.SetActive(true);
        }
        if (partida.user.paracaidas == 2)
        {
            paracaidas2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TextScore != null)
        {
            TextScore.text = Score.ToString();
            TextScoreDiamante.text = ScoreDiamante.ToString();
            if (ScoreMetros >= 10000)
            {
                TextScoreMetros.text = Mathf.Round(ScoreMetros/1000).ToString() + " Km";
            }
            else
            {
                TextScoreMetros.text = Mathf.Round(ScoreMetros).ToString() + " M";
            }
            
        }
    }

    private void OnDestroy()
    {
        guardarPuntuacion();
    }

    
    public void guardarPuntuacion()
    {
        PlayerPrefs.SetInt(scoreSave, Score);
        PlayerPrefs.SetInt(scoreDiamanteSave, ScoreDiamante);
        PlayerPrefs.SetFloat(scoreMetrosSave, ScoreMetros);
        partida.user.monedas += Score;
        partida.user.diamantes += ScoreDiamante;

        if(ScoreMetros > partida.user.distanciaMaxima)
        {
            partida.user.distanciaMaxima = (int)ScoreMetros;
            partida.recordRoto = true;
        }

        partida.distancia.nombre = partida.user.nombre;
        partida.distancia.distancia = (int)ScoreMetros;
    }

    public void cargarPuntuacion()
    {
        Score = PlayerPrefs.GetInt(scoreSave, 0);
        ScoreDiamante = PlayerPrefs.GetInt(scoreDiamanteSave, 0);
        ScoreMetros = PlayerPrefs.GetFloat(scoreMetrosSave, 0);

        
    }

    public void musicaMenu()
    {
        musicaController.musicaMenu();
    }
}
