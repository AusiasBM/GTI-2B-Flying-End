using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstVolcan : EstadoFSM
{
    //Contador del estado
    float contador;

    protected override void Awake()
    {
        base.Awake();
        Nombre = "Volcan";
        maquina.nombreEstados.Add(Nombre);
    }

    protected override void OnEnable()
    {
        //Cambio del gradiente de color segun cada escenario
        StartCoroutine(maquina.efectos.cambiarParametros(0f, -20f, -40f));

        maquina.nombreEstadoActual = Nombre;

        enableDisableObjectsVolcan();

        if (maquina.estaFondo2 == true)
        {
            maquina.fondo1.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[6];
        }
        else
        {
            maquina.fondo2.GetComponent<SpriteRenderer>().sprite = maquina.listSpritesFondos[6];
        }

        contador = 0f;
    }

    protected override void OnDisable()
    {
        maquina.transicionFondo = false;

    }

    // Update is called once per frame
    void Update()
    {
        contador += maquina.Velocidad * Time.deltaTime;

        // Contador de metros 
        maquina.gameController.ScoreMetros += maquina.Velocidad * Time.deltaTime;

        maquina.cambiarFondos(contador, maquina.listSpritesFondos[6], maquina.listSpritesFondos[6], "Volcan");
    }

    void enableDisableObjectsVolcan()
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
        maquina.CarrilDown.GetComponent<CrearNubesFondo>().activo = false;
        maquina.CarrilDown.GetComponent<CrearNubesFondo>().enabled = false;
        //Nubes Electricas
        maquina.CarrilDown.GetComponent<CrerNubeElectrica>().activo = false;
        maquina.CarrilDown.GetComponent<CrerNubeElectrica>().enabled = false;
        //Lluvia
        maquina.CarrilUp.GetComponent<CrearLluvia>().activo = false;
        maquina.CarrilUp.GetComponent<CrearLluvia>().enabled = false;
        //Niebla
        maquina.CarrilDown.GetComponent<CrearNiebla>().activo = false;
        maquina.CarrilDown.GetComponent<CrearNiebla>().enabled = false;
        //Rocas
        maquina.CarrilDown.GetComponent<CrearRocas>().activo = true;
        maquina.CarrilDown.GetComponent<CrearRocas>().enabled = true;
    }

}
