using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public float ms = 4f;
    //public float msUp = 2f;

    public Transform jugador;
    public Transform camara;
    public float limJugadorPos = 0.22f;
    public float limJugadorNeg =  (-0.22f);

    void Update()
    {
       transform.Translate(Vector3.up * ms * Time.deltaTime);
    }

}
