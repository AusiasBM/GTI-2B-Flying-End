using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstLluvia : EstadoFSM
{
    float contador;
    MusicaController musicaController;

    protected override void Awake()
    {
        base.Awake();
        Nombre = "Lluvia";
        maquina.nombreEstados.Add(Nombre);
    }

    protected override void OnEnable()
    {
        StartCoroutine(maquina.efectos.cambiarParametros(60f, 0f, 0f));

        musicaController = MusicaController.instance;
        musicaController.musicaLluvia();

        maquina.nombreEstadoActual = Nombre;

        enableDisableObjectsLluvia();

        maquina.jugador.isTormenta = true;

        if (maquina.estaFondo2 == true)
        {
            maquina.fondo1.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[4];
        }
        else
        {
            maquina.fondo2.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[4];
        }

        //maquina.musicalluvia();

        contador = 0f;
    }

    protected override void OnDisable()
    {
        maquina.transicionFondo = false;
        maquina.jugador.isTormenta = false;
    }

    // Update is called once per frame
    void Update()
    {
        contador += maquina.Velocidad * Time.deltaTime;

        // Contador de metros 
        maquina.gameController.ScoreMetros += maquina.Velocidad * Time.deltaTime;

        maquina.cambiarFondos(contador, maquina.listSpritesFondos[4], maquina.listSpritesFondos[5], "Volcan");

        if (contador > 135f)
        {
            maquina.CarrilDown.GetComponent<CrerNubeElectrica>().activo = false;
            maquina.CarrilDown.GetComponent<CrerNubeElectrica>().enabled = false;

            maquina.CarrilUp.GetComponent<CrearLluvia>().activo = false;
            maquina.CarrilUp.GetComponent<CrearLluvia>().enabled = false;

            maquina.CarrilDown.GetComponent<CrearNubesFondo>().activo = false;
            maquina.CarrilDown.GetComponent<CrearNubesFondo>().enabled = false;

            maquina.jugador.isTormenta = false;
        }
    }

    void enableDisableObjectsLluvia()
    {
        //Piezas
        maquina.CarrilUp.GetComponent<CrearPiezas>().activo = true;
        maquina.CarrilUp.GetComponent<CrearPiezas>().enabled = true;
        //pajaros
        maquina.CarrilIzda1.GetComponent<CrearPajaros>().activo = false;
        maquina.CarrilIzda1.GetComponent<CrearPajaros>().enabled = false;
        maquina.CarrilDrcha1.GetComponent<CrearPajaros>().activo = false;
        maquina.CarrilDrcha1.GetComponent<CrearPajaros>().enabled = false;
        //Nubes
        maquina.CarrilDown.GetComponent<CrearNubes>().activo = false;
        maquina.CarrilDown.GetComponent<CrearNubes>().enabled = false;
        //Nubes fondo
        maquina.CarrilDown.GetComponent<CrearNubesFondo>().activo = true;
        maquina.CarrilDown.GetComponent<CrearNubesFondo>().enabled = true;
        //Nubes Electricas
        maquina.CarrilDown.GetComponent<CrerNubeElectrica>().activo = true;
        maquina.CarrilDown.GetComponent<CrerNubeElectrica>().enabled = true;
        //Lluvia
        maquina.CarrilUp.GetComponent<CrearLluvia>().activo = true;
        maquina.CarrilUp.GetComponent<CrearLluvia>().enabled = true;
        //Niebla
        maquina.CarrilDown.GetComponent<CrearNiebla>().activo = false;
        maquina.CarrilDown.GetComponent<CrearNiebla>().enabled = false;
        //Rocas
        maquina.CarrilDown.GetComponent<CrearRocas>().activo = false;
        maquina.CarrilDown.GetComponent<CrearRocas>().enabled = false;
    }
}
