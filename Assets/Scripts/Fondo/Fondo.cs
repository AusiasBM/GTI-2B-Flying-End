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

    private bool transDiaNoche = false, transNocheTormenta = false, transTormentaVolcan = false;

    public GameObject CarrilDown;
    public GameObject CarrilUp;
    public GameObject CarrilIzda1;
    public GameObject CarrilDrcha1;
    GameController gameController;
    Jugador jugador;

    EfectosColorGrading efectos;

    void Start()
    {
        estaFondo1 = true;
        gameController = GameController.Instance;
        efectos = EfectosColorGrading.Instance;
        jugador = Jugador.Instance;

        //Cambio del gradiente de color segun cada escenario
        StartCoroutine(efectos.cambiarParametros(100f, 5f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        fondo1.transform.Translate(fondo1.transform.up * velocidad * Time.deltaTime); // Hace que la img del fondo 1 se desplaze arriba
        fondo2.transform.Translate(fondo2.transform.up * velocidad * Time.deltaTime); // lo mismo con el fondo 2

        gameController.ScoreMetros += 1f * velocidad * Time.deltaTime; // Contador de metros

        if (fondo2.transform.position.y >= 0 && !estaFondo2)
        {
            //Debug.Log("CAMBIA DE FONDO");
            fondo1.transform.position = new Vector3(0, posRecolocar, fondo1.transform.position.z);
            estaFondo2 = true;
            estaFondo1 = false;

            if (gameController.ScoreMetros >= 120f && gameController.ScoreMetros < 220f)
            {
                CarrilDown.GetComponent<CrearNubes>().activo = false;
                CarrilDown.GetComponent<CrearNubesFondo>().activo = false;

                if (!transDiaNoche && gameController.ScoreMetros <= 140f)
                {
                    fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/transicionDiaNoche");
                    transDiaNoche = true;
                }
                else
                {
                    //Cambio del gradiente de color segun cada escenario
                    StartCoroutine(efectos.cambiarParametros(80f, -10f, 0f));
                    fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondonoche");
                }
            }
            if (gameController.ScoreMetros >= 220f && gameController.ScoreMetros < 350f)
            {
                CarrilIzda1.GetComponent<CrearPajaros>().activo = false;
                CarrilDrcha1.GetComponent<CrearPajaros>().activo = false;

                if (!transNocheTormenta && gameController.ScoreMetros <= 270f)
                {
                    fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/transicionNocheTormenta");
                    transNocheTormenta = true;
                    jugador.isTormenta = true;
                }
                else
                {
                    //Cambio del gradiente de color segun cada escenario
                    StartCoroutine(efectos.cambiarParametros(60f, 0f, 0f));
                    fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoTormenta");
                }
                CarrilUp.GetComponent<CrearLluvia>().activo = true;
                CarrilUp.GetComponent<CrearLluvia>().enabled = true;
                CarrilDown.GetComponent<CrerNubeElectrica>().enabled = true;
            }
            if (gameController.ScoreMetros >= 350f && gameController.ScoreMetros <= 500f)
            {
                CarrilUp.GetComponent<CrearLluvia>().activo = false;
                CarrilDown.GetComponent<CrerNubeElectrica>().activo = false;
                CarrilDown.GetComponent<CrearRocas>().enabled = true;

                if (!transTormentaVolcan && gameController.ScoreMetros <= 400f)
                {
                    fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/transicionTormentaVolcan");
                    transTormentaVolcan = true;
                    jugador.isTormenta = false;
                }
                else
                {
                    //Cambio del gradiente de color segun cada escenario
                    StartCoroutine(efectos.cambiarParametros(0f, -20f, -40f));
                    fondo1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoVolcan2");
                }
            }
        }

        if (fondo1.transform.position.y >= 0 && !estaFondo1)
        {
            //Debug.Log("CAMBIA DE FONDO");
            fondo2.transform.position = new Vector3(0, posRecolocar, fondo2.transform.position.z);
            estaFondo1 = true;
            estaFondo2 = false;

            if (gameController.ScoreMetros >= 120f && gameController.ScoreMetros < 220f)
            {
                if (!transDiaNoche && gameController.ScoreMetros <= 140f)
                {
                    fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/transicionDiaNoche");
                    transDiaNoche = true;
                }
                else
                {
                    StartCoroutine(efectos.cambiarParametros(80f, -10f, 0f));
                    fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondonoche");
                }
            }
            if (gameController.ScoreMetros >= 220f && gameController.ScoreMetros < 350f)
            {
                CarrilIzda1.GetComponent<CrearPajaros>().activo = false;
                CarrilDrcha1.GetComponent<CrearPajaros>().activo = false;

                if (!transNocheTormenta && gameController.ScoreMetros <= 270f)
                {
                    fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/transicionNocheTormenta");
                    transNocheTormenta = true;
                    jugador.isTormenta = true;
                }
                else
                {
                    StartCoroutine(efectos.cambiarParametros(60f, 0f, 0f));
                    fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoTormenta");
                }
            }
            if (gameController.ScoreMetros >= 350f && gameController.ScoreMetros <= 500f)
            {

                if (!transTormentaVolcan && gameController.ScoreMetros <= 400f)
                {
                    fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/transicionTormentaVolcan");
                    transTormentaVolcan = true;
                    jugador.isTormenta = false;
                }
                else
                {
                    StartCoroutine(efectos.cambiarParametros(0f, -20f, -40f));
                    fondo2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fondos/fondoVolcan1");
                }

                
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

    }

}
