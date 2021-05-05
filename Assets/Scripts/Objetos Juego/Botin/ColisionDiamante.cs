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
    // Start is called before the first frame update
    void Start()
    {
        jugador = Jugador.Instance;
    }

        private void OnCollisionEnter(Collision collision)
    {
        GameController.ScoreDiamante += puntuacion;
        jugador.generarParticulas(particulasDiamante, this.transform);
        Destroy(gameObject);
    }
}
