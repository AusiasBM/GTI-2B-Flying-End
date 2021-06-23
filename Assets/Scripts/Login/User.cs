using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public int id, monedas, diamantes, distanciaMaxima;
    public string nombre;

    public User(string nombre)
    {
        nombre = nombre;
        monedas = 0;
        diamantes = 0;
    }

    public User(int id, string nombre, int monedas, int diamantes, int distanciaMaxima)
    {
        this.id = id;
        nombre = nombre;
        this.monedas = monedas;
        this.diamantes = diamantes;
        this.distanciaMaxima = distanciaMaxima;
        
    }

    public User()
    {
        nombre = "";
        monedas = 0;
        diamantes = 0;
        distanciaMaxima = 0;
    }

}
