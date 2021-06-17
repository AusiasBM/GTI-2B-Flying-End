using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public int id, monedas, diamantes, distanciaMaxima;
    public string username;

    public User(string name)
    {
        username = name;
        monedas = 0;
        diamantes = 0;
    }

    public User(int id, string name, int monedas, int diamantes, int distanciaMaxima)
    {
        this.id = id;
        username = name;
        this.monedas = monedas;
        this.diamantes = diamantes;
        this.distanciaMaxima = distanciaMaxima;
        
    }

    public User()
    {
        username = "";
        monedas = 0;
        diamantes = 0;
        distanciaMaxima = 0;
    }

}
