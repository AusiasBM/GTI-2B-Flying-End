using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public float velocidad = 3f;
    public float posRecolocar = -43f;
    public GameObject fondo1;
    public GameObject fondo2;
    private bool estaFondo2 = false;
    private bool estaFondo1 = false;

    private bool nieblaHecho = false;

    public GameObject CarrilDown;


    void Start()
    {
        estaFondo1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
        fondo1.transform.Translate(fondo1.transform.up * velocidad * Time.deltaTime);
        fondo2.transform.Translate(fondo2.transform.up * velocidad * Time.deltaTime);

        GameController.ScoreMetros += 0.1f * velocidad * Time.deltaTime;

        if (fondo2.transform.position.y >= 0 && !estaFondo2)
        {
            Debug.Log("CAMBIA DE FONDO");
            fondo1.transform.position = new Vector3(0, posRecolocar, fondo1.transform.position.z);
            estaFondo2 = true;
            estaFondo1 = false;
            //spriteRenderer1.sprite = sprite1;
            if (GameController.ScoreMetros >= 10f && GameController.ScoreMetros <= 20f)
            {
                fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondonoche");
            }
            if (GameController.ScoreMetros >= 20f && GameController.ScoreMetros <= 30f)
            {
                fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoTormenta");
            }
            if (GameController.ScoreMetros >= 30f && GameController.ScoreMetros <= 40f)
            {
                CarrilDown.GetComponent<CrearNubes>().enabled = false;
                CarrilDown.GetComponent<CrearNubes>().activo = false;
                fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoVolcan1");
            }
        }

        if (fondo1.transform.position.y >= 0 && !estaFondo1)
        {
            Debug.Log("CAMBIA DE FONDO");
            fondo2.transform.position = new Vector3(0, posRecolocar, fondo2.transform.position.z);
            estaFondo1 = true;
            estaFondo2 = false;
            //spriteRenderer2.sprite = sprite2;
            if (GameController.ScoreMetros >= 10f && GameController.ScoreMetros <= 20f)
            {
                fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondonoche");
            }
            if (GameController.ScoreMetros >= 20f && GameController.ScoreMetros <= 30f)
            {
                fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoTormenta");
            }
            if (GameController.ScoreMetros >= 30f && GameController.ScoreMetros <= 40f)
            {
                CarrilDown.GetComponent<CrearNubes>().enabled = false;
                CarrilDown.GetComponent<CrearNubes>().activo = false;
                fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoVolcan2");
            }
        }

        if (GameController.ScoreMetros > 5f && GameController.ScoreMetros < 10f)
        {
            CarrilDown.GetComponent<CrearNiebla>().activo = true;
            CarrilDown.GetComponent<CrearNiebla>().enabled = true;
            nieblaHecho = true;
        }

        if(GameController.ScoreMetros > 10f && nieblaHecho)
        {
            
            CarrilDown.GetComponent<CrearNiebla>().activo = false;
            CarrilDown.GetComponent<CrearNiebla>().enabled = false;
            nieblaHecho = false;
        }



    }

}
