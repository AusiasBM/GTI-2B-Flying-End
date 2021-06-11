using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTeletransporte : MonoBehaviour
{
    GameController gameController;
    Jugador jugador;
    

    void Start()
    {
        jugador = Jugador.Instance;
        gameController = GameController.Instance;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //gameController.ScoreMetros += 50;
        gameObject.SetActive(false);
    }
}
