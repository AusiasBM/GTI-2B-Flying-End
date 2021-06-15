using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColisionDiamante : MonoBehaviour
{
    public GameObject particulasDiamante;
    public int puntuacion = 1;


    Jugador jugador;
    GameController gameController;
    MusicaController musicaController;
    // Start is called before the first frame update
    void Start()
    {
        jugador = Jugador.Instance;
        gameController = GameController.Instance;
        musicaController = MusicaController.instance;
    }

        private void OnCollisionEnter(Collision collision)
    {
        gameController.ScoreDiamante += puntuacion;
        jugador.generarParticulas(particulasDiamante, this.transform);
        musicadiamante();
        gameObject.SetActive(false);
    }
    public void musicadiamante()
    {
        musicaController.musicaDiamante() ;
    }
}
