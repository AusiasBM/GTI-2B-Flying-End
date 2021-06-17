using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Distancia
{
    public int id, distancia;
    public string username;

    public Distancia()
    {

    }

    public Distancia(int id, string username, int distancia)
    {
        this.id = id;
        this.username = username;
        this.distancia = distancia;
    }

    public Distancia(string username, int distancia)
    {
        this.username = username;
        this.distancia = distancia;
    }
}
