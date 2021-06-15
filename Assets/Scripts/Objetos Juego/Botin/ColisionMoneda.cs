using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColisionMoneda : MonoBehaviour
{
    public int puntuacion = 20;
    public GameObject particulasMoneda;

    Jugador jugador;
    GameController gameController;
    MusicaController musicaController;


    // Start is called before the first frame update
    void Start()
    {
        jugador = Jugador.Instance;
        musicaController = MusicaController.instance;
        gameController = GameController.Instance;
       
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameController.Score += puntuacion;
        jugador.generarParticulas(particulasMoneda, this.transform);
        musicamoneda();
        gameObject.SetActive(false);
     
    }
    public void musicamoneda()
    {
        musicaController.musicaMoneda();
    }
}
