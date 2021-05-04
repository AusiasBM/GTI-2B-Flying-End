using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int Score = 0;
    public static int ScoreDiamante = 0;
    public static float ScoreMetros = 0f;
    public Text TextScore;
    public Text TextScoreDiamante;
    public Text TextScoreMetros;
    public static GameController Gamecontroller;

    void Awake()
    {
        Gamecontroller = this;
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
}
