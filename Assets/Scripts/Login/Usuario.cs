using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Usuario
{
    public int id;
    public string nombre;

    public Usuario(string nombre)
    {
        this.nombre = nombre;
    }

    public Usuario(int id, string nombre)
    {
        this.id = id;
        this.nombre = nombre;

    }

    public Usuario()
    {
        nombre = "";
    }

}
