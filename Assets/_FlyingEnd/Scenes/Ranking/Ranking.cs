using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Text[] nombres;
    public Text[] distancias;
    public Text errorConexion;
    Partida partida;
    List<Distancia> distanciasList = new List<Distancia>();


    // Start is called before the first frame update
    void Start()
    {
        partida = Partida.instance;
        cargarRanking();
    }

    void cargarRanking()
    {
        if (partida.saveLoad.completado)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    nombres[i].text = partida.saveLoad.distancias[i].nombre;
                    distancias[i].text = partida.saveLoad.distancias[i].distancia.ToString();
                    Debug.Log(partida.saveLoad.user[i].nombre);
                }
                catch
                {
                    nombres[i].text = "";
                    distancias[i].text = "";
                }

            }
            
        }
        else
        {
            for(int i = 0; i < 10; i++)
            {    
                nombres[i].text = "";
                distancias[i].text = "";
            }
            Debug.Log("Error en la conexi?n");
            errorConexion.text = "ERROR DE CONEXI?N CON EL SERVIDOR WEB";
            errorConexion.color = Color.red;
        }
        
    }

    public void CargarEscena(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}
