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
    private  sonidoMoneda sonidomoneda ;


    // Start is called before the first frame update
    void Start()
    {
        jugador = Jugador.Instance;
      
        gameController = GameController.Instance;
        sonidomoneda = jugador.GetComponent<sonidoMoneda>();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameController.Score += puntuacion;
        jugador.generarParticulas(particulasMoneda, this.transform);
        gameObject.SetActive(false);
        sonidomoneda.emitir();

     
    }
  
}
