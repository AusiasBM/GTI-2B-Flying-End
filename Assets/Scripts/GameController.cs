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
 
    }

    // Update is called once per frame
    void Update()
    {
        if (TextScore != null)
        {
            TextScore.text = Score.ToString();
            TextScoreDiamante.text = ScoreDiamante.ToString();
            TextScoreMetros.text = Mathf.Round(ScoreMetros).ToString() + " M";
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
    }

    public void cargarPuntuacion()
    {
        Score = PlayerPrefs.GetInt(scoreSave, 0);
        ScoreDiamante = PlayerPrefs.GetInt(scoreDiamanteSave, 0);
        ScoreMetros = PlayerPrefs.GetFloat(scoreMetrosSave, 0);

        
    }
}
