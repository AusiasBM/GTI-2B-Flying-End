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
    private bool lluviaHecho = false;

    public GameObject CarrilDown;
    public GameObject CarrilUp;
    GameController gameController;

    void Start()
    {
        estaFondo1 = true;
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        fondo1.transform.Translate(fondo1.transform.up * velocidad * Time.deltaTime);
        fondo2.transform.Translate(fondo2.transform.up * velocidad * Time.deltaTime);

        gameController.ScoreMetros += 1f * velocidad * Time.deltaTime;

        if (fondo2.transform.position.y >= 0 && !estaFondo2)
        {
            Debug.Log("CAMBIA DE FONDO");
            fondo1.transform.position = new Vector3(0, posRecolocar, fondo1.transform.position.z);
            estaFondo2 = true;
            estaFondo1 = false;

            if (gameController.ScoreMetros >= 100f && gameController.ScoreMetros <= 200f)
            {
                fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondonoche");
            }
            if (gameController.ScoreMetros >= 200f && gameController.ScoreMetros <= 300f)
            {
                fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoTormenta");
            }
            if (gameController.ScoreMetros >= 300f && gameController.ScoreMetros <= 400f)
            {
                CarrilDown.GetComponent<CrearNubes>().enabled = false;
                CarrilDown.GetComponent<CrearNubes>().activo = false;
                CarrilDown.GetComponent<CrearRocas>().enabled = true;
                CarrilDown.GetComponent<CrearPajaros>().enabled = false;
                CarrilDown.GetComponent<CrearPajaros>().activo = false;

                fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoVolcan1");
            }
        }

        if (fondo1.transform.position.y >= 0 && !estaFondo1)
        {
            Debug.Log("CAMBIA DE FONDO");
            fondo2.transform.position = new Vector3(0, posRecolocar, fondo2.transform.position.z);
            estaFondo1 = true;
            estaFondo2 = false;

            if (gameController.ScoreMetros >= 100f && gameController.ScoreMetros <= 200f)
            {
                fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondonoche");
            }
            if (gameController.ScoreMetros >= 200f && gameController.ScoreMetros <= 300f)
            {
                fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoTormenta");
            }
            if (gameController.ScoreMetros >= 300f && gameController.ScoreMetros <= 400f)
            {
                CarrilDown.GetComponent<CrearNubes>().enabled = false;
                CarrilDown.GetComponent<CrearNubes>().activo = false;
                fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoVolcan2");
            }
        }

        if (gameController.ScoreMetros > 50f && gameController.ScoreMetros < 100f)
        {
            CarrilDown.GetComponent<CrearNiebla>().activo = true;
            CarrilDown.GetComponent<CrearNiebla>().enabled = true;
            nieblaHecho = true;
        }

        if(gameController.ScoreMetros > 100f && nieblaHecho)
        {
            
            CarrilDown.GetComponent<CrearNiebla>().activo = false;
            CarrilDown.GetComponent<CrearNiebla>().enabled = false;
            nieblaHecho = false;
        }

        if (gameController.ScoreMetros >= 247f && gameController.ScoreMetros <= 350f)
        {
            CarrilUp.GetComponent<CrearLluvia>().activo = true;
            CarrilUp.GetComponent<CrearLluvia>().enabled = true;
            lluviaHecho = true;
        }

        if (gameController.ScoreMetros > 350f && lluviaHecho)
        {

            CarrilUp.GetComponent<CrearLluvia>().activo = false;
            CarrilUp.GetComponent<CrearLluvia>().enabled = false;
            lluviaHecho = false;
        }

    }

}
