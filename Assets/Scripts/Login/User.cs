using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public int id, monedas, diamantes, distanciaMaxima, paracaidas;
    public string nombre;

    public User(string nombre)
    {
        nombre = nombre;
        monedas = 0;
        diamantes = 0;
        paracaidas = 0;
    }

    public User(int id, string nombre, int monedas, int diamantes, int distanciaMaxima, int paracaidas)
    {
        this.id = id;
        this.nombre = nombre;
        this.monedas = monedas;
        this.diamantes = diamantes;
        this.distanciaMaxima = distanciaMaxima;
        this.paracaidas = paracaidas;
        
    }

    public User()
    {
        nombre = "";
        monedas = 0;
        diamantes = 0;
        distanciaMaxima = 0;
        paracaidas = 0;
    }

}
