using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Distancia
{
    public int id, distancia;
    public string nombre;

    public Distancia()
    {

    }

    public Distancia(int id, string nombre, int distancia)
    {
        this.id = id;
        this.nombre = nombre;
        this.distancia = distancia;
    }

    public Distancia(string nombre, int distancia)
    {
        this.nombre = nombre;
        this.distancia = distancia;
    }
}
