using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public float velocidad = 3f;
    public float posRecolocar = -43f;
    public Transform fondo1;
    public Transform fondo2;
    private bool estaFondo2 = false;
    private bool estaFondo1 = false;

    void Start()
    {
        estaFondo1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
        fondo1.position += fondo1.up * velocidad * Time.deltaTime;
        fondo2.position += fondo2.up * velocidad * Time.deltaTime;

        if (fondo2.position.y >= 0 && !estaFondo2)
        {
            Debug.Log("CAMBIA DE FONDO");
            fondo1.position = new Vector3(0, posRecolocar, fondo1.position.z);
            estaFondo2 = true;
            estaFondo1 = false;
        }
        if (fondo1.position.y >= 0 && !estaFondo1)
        {
            Debug.Log("CAMBIA DE FONDO");
            fondo2.position = new Vector3(0, posRecolocar, fondo1.position.z);
            estaFondo1 = true;
            estaFondo2 = false;
        }
    }

}
