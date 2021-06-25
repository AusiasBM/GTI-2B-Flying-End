using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Clase para el power up del teletransporte que hace que el personaje cambie de escenario y sume +100 metros en la puntuacion */

public class CollisionTeletransporte : MonoBehaviour
{
    GameController gameController;
    Jugador jugador;
    MaquinaFSM maquina;
    EfectoTeletransporte efecto;

    void Start()
    {
        jugador = Jugador.Instance;
        efecto = EfectoTeletransporte.Instance;
        gameController = GameController.Instance;
        maquina = MaquinaFSM.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        maquina.desactivarObjetos = true;
        efecto.teletransportando = true;
        gameController.ScoreMetros += 100;
        int num = Random.Range(0, maquina.nombreEstados.Count);
        while (maquina.nombreEstadoActual == maquina.nombreEstados[num])
        {
            Debug.Log(num);
            num = Random.Range(0, maquina.nombreEstados.Count);
            Debug.Log("IGUAL");
        }
        Debug.Log(num);
        cambiarFondoTeletransporte(maquina.nombreEstados[num]);
        maquina.cambioEstado(maquina.nombreEstados[num]);

        
        gameObject.SetActive(false);
    }

    public void cambiarFondoTeletransporte(string nuevoEstado)
    {
        switch (nuevoEstado)
        {
            case "Soleado":
                maquina.fondo1.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[0];
                maquina.fondo2.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[0];
                break;

            case "Niebla":
                maquina.fondo1.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[0];
                maquina.fondo2.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[0];
                break;

            case "Noche":
                maquina.fondo1.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[2];
                maquina.fondo2.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[2];
                break;

            case "Lluvia":
                maquina.fondo1.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[4];
                maquina.fondo2.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[4];
                break;

            case "Volcan":
                maquina.fondo1.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[6];
                maquina.fondo2.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[6];                
                break;

            default:
                break;
        }
    }
}
