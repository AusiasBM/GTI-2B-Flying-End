using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColisionDiamante : MonoBehaviour
{
    public GameObject particulasDiamante;
    public int puntuacion = 1;
    private sonidoDiamante sonidodiamante;

    Jugador jugador;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        jugador = Jugador.Instance;
        gameController = GameController.Instance;
        sonidodiamante= jugador.GetComponent<sonidoDiamante>();
    }

        private void OnCollisionEnter(Collision collision)
    {
        gameController.ScoreDiamante += puntuacion;
        jugador.generarParticulas(particulasDiamante, this.transform);
        gameObject.SetActive(false);
        sonidodiamante.emitir();
    }
}
