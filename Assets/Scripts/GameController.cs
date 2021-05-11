using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score = 0;
    public int ScoreDiamante = 0;
    public float ScoreMetros = 0f;
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
        /*Score = 0;
        ScoreDiamante = 0;
        ScoreMetros = 0f;*/
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
}
